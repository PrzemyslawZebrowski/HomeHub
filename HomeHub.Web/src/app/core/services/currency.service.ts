import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

import { Currency } from '../models/currency.model';

@Injectable({
    providedIn: 'root'
})
export class CurrencyService {

    private _currentCurrency$ = new BehaviorSubject<Currency>('PLN');
    currentCurrency$: Observable<Currency>;

    constructor() {
        this.currentCurrency$ = this._currentCurrency$.asObservable();
    }

    setCurrencyCurrency(currency: Currency): void {
        this._currentCurrency$.next(currency);
    }
}
