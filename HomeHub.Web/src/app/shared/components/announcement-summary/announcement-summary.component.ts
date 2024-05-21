import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { Gallery, GalleryModule, ImageItem } from 'ng-gallery';
import { LightboxModule } from 'ng-gallery/lightbox';
import { combineLatest, Observable, shareReplay } from 'rxjs';
import { Announcement } from 'src/app/core/models/announcements/announcement.model';
import { AdditionalDetail } from 'src/app/core/models/lookups/additional-detail.model';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';
import { LookupService } from 'src/app/core/services/lookup.service';

import { SharedModule } from '../../shared.module';

@Component({
    selector: 'hh-announcement-summary',
    standalone: true,
    imports: [
        CommonModule,
        TranslateModule,
        SharedModule,
        GalleryModule,
        LightboxModule
    ],
    templateUrl: './announcement-summary.component.html',
    styleUrls: ['./announcement-summary.component.scss']
})
export class AnnouncementSummaryComponent implements OnInit {
    @Input() announcement: Announcement;
    galleryId = 'myLightbox';
    details$: Observable<AdditionalDetail[]>;

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

    constructor(private _lookupService: LookupService, private _gallery: Gallery) { }

    ngOnInit(): void {
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

        const galleryRef = this._gallery.ref(this.galleryId, { autoHeight: true });
        galleryRef.load(this.announcement.photos.map(photo => new ImageItem({ src: photo.url, thumb: photo.url })));
    }
}
