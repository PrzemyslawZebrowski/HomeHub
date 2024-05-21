import { NgIf } from '@angular/common';
import { Directive, Input, OnDestroy, TemplateRef, ViewContainerRef } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';
import { UserRoleEnum } from 'src/app/core/enums/users/user-role.enum';

@Directive({
    selector: '[hhHasRole]'
})
export class HasRoleDirective extends NgIf implements OnDestroy {
    private _destroy$ = new Subject<void>();

    constructor(
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        templateRef: TemplateRef<any>,
        viewContainerRef: ViewContainerRef,
        private _authService: AuthService
    ) {
        super(viewContainerRef, templateRef);
    }

    ngOnDestroy(): void {
        this._destroy$.next();
        this._destroy$.complete();
    }

    @Input() set hhHasRole(requiredRoles: UserRoleEnum[]) {
        this.ngIf = false;
        this._authService.userInfo$.pipe(
            takeUntil(this._destroy$),
        ).subscribe((user) => {
            if (user) {
                this.ngIf = requiredRoles.includes(user.roleId);
            } else {
                this.ngIf = false;
            }
        });
    }
}
