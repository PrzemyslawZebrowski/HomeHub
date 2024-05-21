import { CommonModule } from '@angular/common';
import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup, FormsModule, NonNullableFormBuilder, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { combineLatest, Observable, shareReplay } from 'rxjs';
import { SearchAnnouncementFilters } from 'src/app/core/models/announcements/search-announcement.model';
import { AdditionalDetail } from 'src/app/core/models/lookups/additional-detail.model';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';
import { LookupService } from 'src/app/core/services/lookup.service';
import { MaterialModule } from 'src/app/material/material.module';

import { DirectivesModule } from '../../directives/directives.module';
import { RangeControlComponent } from '../range-control/range-control.component';

@Component({
    selector: 'hh-announcement-filters',
    standalone: true,
    imports: [
        CommonModule,
        MaterialModule,
        TranslateModule,
        FormsModule,
        ReactiveFormsModule,
        RangeControlComponent,
        DirectivesModule
    ],
    templateUrl: './announcement-filters.component.html',
    styleUrls: ['./announcement-filters.component.scss']
})
export class AnnouncementFiltersComponent implements OnInit {
    @Output() search = new EventEmitter<SearchAnnouncementFilters>;
    @Input() initCriteria: SearchAnnouncementFilters;

    autocompleteOptions: google.maps.places.AutocompleteOptions = {
        fields: ['formatted_address', 'geometry'],
        strictBounds: false,
        types: ['route', 'locality']
    };

    private _addressElementRef: ElementRef<HTMLInputElement>;

    showMoreDetails = false;

    form: FormGroup<TypedFormControls<SearchAnnouncementFilters>>;
    lookups$: Observable<{
        subjectsTypes: Lookup[],
        announcementTypes: Lookup[],
        advertiserTypes: Lookup[],
        marketTypes: Lookup[],
        developments: Lookup[],
        floors: Lookup[],
        buildingMaterials: Lookup[],
        windows: Lookup[],
        heatings: Lookup[],
        buildingFinishConditions: Lookup[],
        ownerships: Lookup[],
        details: AdditionalDetail[]
    }>;

    constructor(
        private _fb: NonNullableFormBuilder,
        private _lookupService: LookupService
    ) {
    }

    ngOnInit(): void {
        this.initForm();

        if (this.initCriteria) {
            this.form.patchValue(this.initCriteria);
        }

        this.lookups$ = combineLatest({
            subjectsTypes: this._lookupService.getAnnouncementSubjects(),
            announcementTypes: this._lookupService.getAnnouncementTypes(),
            advertiserTypes: this._lookupService.getAdvertiserTypes(),
            marketTypes: this._lookupService.getAnnouncementMarketTypes(),
            developments: this._lookupService.getDevelopmentTypes(),
            floors: this._lookupService.getFloors(),
            buildingMaterials: this._lookupService.getBuildingMaterials(),
            windows: this._lookupService.getWindowTypes(),
            heatings: this._lookupService.getHeatingTypes(),
            buildingFinishConditions: this._lookupService.getBuildingFinishConditions(),
            ownerships: this._lookupService.getOwnershipForms(),
            details: this._lookupService.getAdditionalDetails()
        }).pipe(
            shareReplay()
        );
    }

    @ViewChild('address') set address(address: ElementRef) {
        if (address) {
            this._addressElementRef = address;
            this.setMapAddressAutocomplete();
        }
    }

    onMore(): void {
        this.showMoreDetails = !this.showMoreDetails;
    }

    onSearch(): void {
        this.search.emit(this.form.value as SearchAnnouncementFilters);
    }

    onClear(): void {
        this.form.reset();
        this.search.emit(this.form.value as SearchAnnouncementFilters);
    }

    private initForm(): void {
        this.form = this._fb.group<TypedFormControls<SearchAnnouncementFilters>>({
            radiusDistance: this._fb.control(5),
            longitude: this._fb.control(0),
            latitude: this._fb.control(0),
            address: this._fb.control(undefined),
            subjectTypeId: this._fb.control(undefined),
            announcementTypeId: this._fb.control(undefined),
            advertiserTypeId: this._fb.control(undefined),
            marketTypeId: this._fb.control(undefined),
            floorId: this._fb.control(undefined),
            developmentTypeId: this._fb.control(undefined),
            buildingMaterialId: this._fb.control(undefined),
            buildingFinishConditionId: this._fb.control(undefined),
            priceAmountMin: this._fb.control(undefined),
            priceAmountMax: this._fb.control(undefined),
            areaMin: this._fb.control(undefined),
            areaMax: this._fb.control(undefined),
            numberOfRoomsMin: this._fb.control(undefined),
            numberOfRoomsMax: this._fb.control(undefined),
            numberOfFloorsMin: this._fb.control(undefined),
            numberOfFloorsMax: this._fb.control(undefined),
            buildYearMin: this._fb.control(undefined),
            buildYearMax: this._fb.control(undefined)
        });
    }

    private setMapAddressAutocomplete(): void {
        const autocomplete = new google.maps.places.Autocomplete(this._addressElementRef.nativeElement, this.autocompleteOptions);
        google.maps.event.addListener(autocomplete, 'place_changed', () => {
            const place = autocomplete.getPlace();

            if (place.geometry && place.geometry.location) {
                this.form.patchValue({
                    address: place.formatted_address,
                    latitude: place.geometry.location.lat(),
                    longitude: place.geometry.location.lng()
                });
            }
        });
    }
}
