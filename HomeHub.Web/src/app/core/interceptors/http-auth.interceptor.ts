import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, Observable, switchMap, throwError } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

@Injectable()
export class HttpAuthInterceptor implements HttpInterceptor {

    constructor(
        private _authService: AuthService,
        private _router: Router,
    ) { }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        return this._authService.getToken$().pipe(
            switchMap((token) => {
                const newRequest = token ? request.clone({ setHeaders: { 'Authorization': `${token.tokenType} ${token.accessToken}` } }) : request;
                return next.handle(newRequest);
            }),
            catchError((error: HttpErrorResponse) => {
                switch (error.status) {
                    case 401:
                        this.handle401Error(error);
                        break;
                    case 403:
                        this.handle403Error(error);
                        break;
                    case 404:
                        this.handle404Error(error);
                        break;
                    case 500:
                        this.handle500Error(error);
                        break;
                    default:
                        this.handleElseError(error);
                }
                return throwError(() => error);
            })
        );
    }

    private handle401Error(error: HttpErrorResponse): void {
        this._authService.login();
    }

    private handle403Error(error: HttpErrorResponse): void {
        this._authService.authStatus$.subscribe(authStatus => {
            if (authStatus) {
                this._router.navigate(['access-denied']);
            }
        });
    }

    private handle404Error(error: HttpErrorResponse): void {
        this._router.navigate(['not-found']);
    }

    private handle500Error(error: HttpErrorResponse): void {
        this._router.navigate(['not-found']);
    }

    private handleElseError(error: HttpErrorResponse): void {
        this._router.navigate(['not-found']);
    }
}
