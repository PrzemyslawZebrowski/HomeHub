import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, switchMap } from 'rxjs';

import { CurrencyService } from '../services/currency.service';

@Injectable()
export class CurrencyInterceptor implements HttpInterceptor {

    constructor(private _currencyService: CurrencyService) { }

    intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
        return this._currencyService.currentCurrency$.pipe(
            switchMap((currentCurrency) => {
                const newRequest = request.clone({
                    headers: request.headers.set('currency', [currentCurrency])
                });
                return next.handle(newRequest);
            })
        );
    }
}
