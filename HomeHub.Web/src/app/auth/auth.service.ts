import { Injectable } from '@angular/core';
import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import { AuthenticationResult, InteractionStatus } from '@azure/msal-browser';
import { BehaviorSubject, filter, iif, Observable, of, switchMap, tap } from 'rxjs';
import { environment } from 'src/environments/environment';

import { UserInfo } from '../core/models/users/user-info.model';
import { UserService } from '../core/services/user.service';

@Injectable()
export class AuthService {
    authStatus$: Observable<boolean>;
    userInfo$: Observable<UserInfo | null>;

    private _authStatus$ = new BehaviorSubject<boolean>(false);
    private _userInfo$ = new BehaviorSubject<UserInfo | null>(null);

    constructor(
        private _msalService: MsalService,
        private _msalBroadcastService: MsalBroadcastService,
        private _userService: UserService
    ) {
        this.authStatus$ = this._authStatus$.asObservable();
        this.userInfo$ = this._userInfo$.asObservable();

        this._msalBroadcastService.inProgress$.pipe(
            filter((status: InteractionStatus) => status === InteractionStatus.None),
            tap(() => this.checkAndSetActiveAccount()),
            filter(() => this._authStatus$.value),
            switchMap(() => this.getUserInfoAndRegisterUser())
        ).subscribe(userInfo => this._userInfo$.next(userInfo));
    }

    getToken$(): Observable<Nullable<AuthenticationResult>> {
        if (this._authStatus$.value) {
            return this._msalService.acquireTokenSilent({ scopes: environment.auth.scopes, account: this._msalService.instance.getActiveAccount() ?? undefined });
        }

        return of(null);
    }

    login(): void {
        this._msalService.loginRedirect();
    }

    logout(): void {
        this._msalService.logoutRedirect();
    }

    private checkAndSetActiveAccount(): void {
        if (this._msalService.instance.getAllAccounts().length > 0) {
            this._authStatus$.next(true);
            const accounts = this._msalService.instance.getAllAccounts();
            this._msalService.instance.setActiveAccount(accounts[0]);
        }
    }

    private getUserInfoAndRegisterUser(): Observable<UserInfo | null> {
        return this._userService.getCurrentUserInfo().pipe(
            switchMap(userInfo => iif(() => !userInfo,
                this._userService.registerUser().pipe(
                    switchMap(() => this._userService.getCurrentUserInfo())
                ),
                of(userInfo)
            ))
        );
    }
}
