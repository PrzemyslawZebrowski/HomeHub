import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { combineLatest, Observable, shareReplay } from 'rxjs';
import { AnnouncementBasicInformation } from 'src/app/core/models/announcements/announcement-form.model';
import { Currency } from 'src/app/core/models/currency.model';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';
import { LookupService } from 'src/app/core/services/lookup.service';

@Component({
    selector: 'hh-profile-announcement-basic-information-form',
    templateUrl: './profile-announcement-basic-information-form.component.html',
    styleUrls: ['./profile-announcement-basic-information-form.component.scss']
})
export class ProfileAnnouncementBasicInformationFormComponent implements OnInit {
    @Input() form: FormGroup<TypedFormControls<AnnouncementBasicInformation>>;
    lookups$: Observable<{ advertisers: Lookup[], markets: Lookup[], currency: Currency[] }>;

    constructor(private _lookupService: LookupService) { }

    ngOnInit(): void {
        this.lookups$ = combineLatest({
            advertisers: this._lookupService.getAdvertiserTypes(),
            markets: this._lookupService.getAnnouncementMarketTypes(),
            currency: this._lookupService.getCurrencies()
        }).pipe(
            shareReplay()
        );
    }
}
