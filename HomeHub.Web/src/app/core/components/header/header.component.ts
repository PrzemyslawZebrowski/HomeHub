import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';

import { LOCAL_STORAGE_CURRENCY_KEY } from '../../constants/currencies';
import { LOCAL_STORAGE_LANGUAGE_KEY } from '../../constants/languages';
import { UserRoleEnum } from '../../enums/users/user-role.enum';
import { Currency } from '../../models/currency.model';
import { CurrencyService } from '../../services/currency.service';
import { LookupService } from '../../services/lookup.service';

@Component({
    selector: 'hh-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
    userRoleEnum = UserRoleEnum;

    isLoggedIn$: Observable<boolean>;
    currencies$: Observable<Currency[]>;
    languages: string[];
    currentLanguage: string;
    currentCurrency$: Observable<Currency>;

    constructor(
        private _authService: AuthService,
        private _translateService: TranslateService,
        private _lookupService: LookupService,
        private _currencyService: CurrencyService
    ) { }

    ngOnInit(): void {
        this.isLoggedIn$ = this._authService.authStatus$;
        this.languages = this._translateService.getLangs();
        this.currentLanguage = this._translateService.currentLang;

        this.currencies$ = this._lookupService.getCurrencies();
        this.currentCurrency$ = this._currencyService.currentCurrency$;
    }

    login(): void {
        this._authService.login();
    }

    logout(): void {
        this._authService.logout();
    }

    setLanguage(lang: string): void {
        this._translateService.use(lang);
        this.currentLanguage = lang;
        localStorage.setItem(LOCAL_STORAGE_LANGUAGE_KEY, lang);
    }

    setCurrency(currency: Currency): void {
        this._currencyService.setCurrencyCurrency(currency);
        this.currentCurrency$ = this._currencyService.currentCurrency$;
        localStorage.setItem(LOCAL_STORAGE_CURRENCY_KEY, currency);
    }
}
