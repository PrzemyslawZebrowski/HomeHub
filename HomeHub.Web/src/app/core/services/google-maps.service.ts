import { Injectable } from '@angular/core';
import { Loader } from '@googlemaps/js-api-loader';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
    providedIn: 'root'
})
export class GoogleMapsService {
    mapLoaded$: Observable<boolean>;

    private _mapLoaded$ = new BehaviorSubject<boolean>(false);

    constructor() {
        this.mapLoaded$ = this._mapLoaded$.asObservable();
    }

    loadGoogleMapsApi(): void {
        const loader = new Loader({
            apiKey: environment.googleMapsApiKey,
            version: 'weekly',
            language: 'en',
        });

        loader.importLibrary('places').then(() => {
            this._mapLoaded$.next(true);
        });
    }
}
