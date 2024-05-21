import { registerLocaleData } from '@angular/common';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import localePl from '@angular/common/locales/pl';
import { DEFAULT_CURRENCY_CODE, LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
    MSAL_GUARD_CONFIG,
    MSAL_INSTANCE,
    MsalBroadcastService,
    MsalGuard,
    MsalGuardConfiguration,
    MsalRedirectComponent,
    MsalService
} from '@azure/msal-angular';
import { InteractionType, IPublicClientApplication, PublicClientApplication } from '@azure/msal-browser';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { environment } from 'src/environments/environment';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { CoreModule } from './core/core.module';
import { CurrencyInterceptor } from './core/interceptors/currency.interceptor';
import { HttpAuthInterceptor } from './core/interceptors/http-auth.interceptor';
import { FeaturesModule } from './features/features.module';

registerLocaleData(localePl);


export function MSALInstanceFactory(): IPublicClientApplication {
    return new PublicClientApplication({
        auth: {
            clientId: environment.auth.clientId,
            authority: environment.auth.authority,
            knownAuthorities: [environment.auth.domain],
            redirectUri: "/",
            postLogoutRedirectUri: "/"
        }
    });
}

export function MSALGuardConfigFactory(): MsalGuardConfiguration {
    return {
        interactionType: InteractionType.Redirect,
        authRequest: {
            scopes: environment.auth.scopes
        }
    };
}

export function HttpLoaderFactory(httpClient: HttpClient): TranslateHttpLoader {
    return new TranslateHttpLoader(httpClient);
}

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        FeaturesModule,
        CoreModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        AuthModule.forRoot(),
        HttpClientModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpClient]
            }
        })
    ],
    providers: [
        MsalGuard,
        MsalBroadcastService,
        MsalService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: CurrencyInterceptor,
            multi: true
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: HttpAuthInterceptor,
            multi: true
        },
        {
            provide: MSAL_INSTANCE,
            useFactory: MSALInstanceFactory
        },
        {
            provide: MSAL_GUARD_CONFIG,
            useFactory: MSALGuardConfigFactory
        },
        { provide: LOCALE_ID, useValue: 'pl' },
        { provide: DEFAULT_CURRENCY_CODE, useValue: 'PLN' }
    ],
    bootstrap: [AppComponent, MsalRedirectComponent],
})
export class AppModule { }
