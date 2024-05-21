import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { DEFAULT_CURRENCY, LOCAL_STORAGE_CURRENCY_KEY } from './core/constants/currencies';
import { DEFAULT_LANGUAGE, LOCAL_STORAGE_LANGUAGE_KEY, SUPPORTED_LANGUAGES } from './core/constants/languages';
import { Currency } from './core/models/currency.model';
import { CurrencyService } from './core/services/currency.service';
import { GoogleMapsService } from './core/services/google-maps.service';

@Component({
    selector: 'hh-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
    constructor(
        private _translateService: TranslateService,
        private _googleMapsService: GoogleMapsService,
        private _currencyService: CurrencyService
    ) { }

    ngOnInit(): void {
        this._translateService.addLangs(SUPPORTED_LANGUAGES);

        const initLanguage = localStorage.getItem(LOCAL_STORAGE_LANGUAGE_KEY) ?? DEFAULT_LANGUAGE;
        this._translateService.setDefaultLang(initLanguage);
        this._translateService.use(initLanguage);

        const initCurrency = (localStorage.getItem(LOCAL_STORAGE_CURRENCY_KEY) ?? DEFAULT_CURRENCY) as Currency;
        this._currencyService.setCurrencyCurrency(initCurrency);

        this._googleMapsService.loadGoogleMapsApi();
    }
}
