import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, shareReplay } from 'rxjs';
import { environment } from 'src/environments/environment';

import { AnnouncementDetails } from '../models/announcements/announcement-form.model';
import { Currency } from '../models/currency.model';
import { AdditionalDetail } from '../models/lookups/additional-detail.model';
import { Lookup } from '../models/lookups/lookup.model';

@Injectable({
    providedIn: 'root'
})
export class LookupService {
    _cache: { [path: string]: Observable<Array<Lookup | Currency | AnnouncementDetails>> } = {};

    constructor(private _http: HttpClient) { }

    getRoles(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/users/roles');
    }

    getAnnouncementSubjects(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/subject-types');
    }

    getAnnouncementTypes(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/types');
    }

    getAnnouncementMarketTypes(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/market-types');
    }

    getAdvertiserTypes(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/advertiser-types');
    }

    getBuildingFinishConditions(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/building-finish-conditions');
    }

    getBuildingMaterials(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/building-materials');
    }

    getDevelopmentTypes(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/development-types');
    }

    getFloors(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/floors');
    }

    getHeatingTypes(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/heating-types');
    }

    getOwnershipForms(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/ownership-forms');
    }

    getWindowTypes(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/window-types');
    }

    getCurrencies(): Observable<Currency[]> {
        return this.getAndCacheLookup('/lookups/currencies');
    }

    getAdditionalDetails(): Observable<AdditionalDetail[]> {
        return this.getAndCacheLookup('/lookups/announcements/details');
    }

    getStatuses(): Observable<Lookup[]> {
        return this.getAndCacheLookup('/lookups/announcements/statuses');
    }

    private getAndCacheLookup<T extends Lookup | Currency | AnnouncementDetails>(path: string): Observable<Array<T>> {
        if (!this._cache[path]) {
            this._cache[path] = this._http.get<T[]>(`${environment.apiUrl}${path}`).pipe(
                shareReplay({ refCount: true, bufferSize: 1 })
            );
        }

        return this._cache[path] as Observable<Array<T>>;
    }
}
