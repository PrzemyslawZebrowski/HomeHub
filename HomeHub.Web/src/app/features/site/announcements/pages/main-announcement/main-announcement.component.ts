import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { GalleryItem, ImageItem } from 'ng-gallery';
import { Observable, tap } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';
import { AdditionalDetailEnum } from 'src/app/core/enums/announcements/additional-detail.enum';
import { DetailsGroupEnum } from 'src/app/core/enums/announcements/details-group.enum';
import { MainAnnouncement } from 'src/app/core/models/announcements/main-announcement.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';
import { GoogleMapsService } from 'src/app/core/services/google-maps.service';
import { DATE_FORMAT } from 'src/app/shared/values/date-formats';

@Component({
    selector: 'hh-main-announcement',
    templateUrl: './main-announcement.component.html',
    styleUrls: ['./main-announcement.component.scss']
})
export class MainAnnouncementComponent implements OnInit {
    isLoggedIn$: Observable<boolean>;
    announcementId: number;
    outGoingPossible: boolean;
    parkingPossible: boolean;
    isElevator: boolean;
    media: string[];
    security: string[];
    equipment: string[];
    additional: string[];
    galleryItems: GalleryItem[];

    dateFormat = DATE_FORMAT;

    mapOptions: google.maps.MapOptions = {
        zoom: 3,
        center: {
            lat: 40,
            lng: 10
        }
    };

    markerOptions: google.maps.MarkerOptions = {
        draggable: true,
        visible: false,
        position: {
            lat: 0,
            lng: 0
        }
    };

    markerPosition: google.maps.LatLng;

    mapLoaded$: Observable<boolean>;
    announcement$: Observable<MainAnnouncement>;

    constructor(
        private _route: ActivatedRoute,
        private _announcementService: AnnouncementService,
        private _translateService: TranslateService,
        private _googleMapsService: GoogleMapsService,
        private _authService: AuthService
    ) {
        this.announcementId = this._route.snapshot.params['id'] as number;
        this.isLoggedIn$ = _authService.authStatus$;
    }

    ngOnInit(): void {
        this.mapLoaded$ = this._googleMapsService.mapLoaded$;

        if (this.announcementId) {
            this.announcement$ = this._announcementService.getMainAnnouncement(this.announcementId).pipe(
                tap(announcement => {
                    const detailIds = announcement.additionalDetails.map(detail => detail.id);
                    this.outGoingPossible = detailIds.some(detailId => detailId === AdditionalDetailEnum.Garden
                        || detailId === AdditionalDetailEnum.Terrace
                        || detailId === AdditionalDetailEnum.Balcony);

                    this.parkingPossible = detailIds.includes(AdditionalDetailEnum.ParkingSpace);
                    this.isElevator = detailIds.includes(AdditionalDetailEnum.Elevator);

                    this.media = announcement.additionalDetails
                        .filter(detail => detail.groupId === DetailsGroupEnum.Media)
                        .map(detail => this._translateService.instant("Lookup.AdditionalDetail." + detail.name));

                    this.security = announcement.additionalDetails
                        .filter(detail => detail.groupId === DetailsGroupEnum.Security)
                        .map(detail => this._translateService.instant("Lookup.AdditionalDetail." + detail.name));

                    this.equipment = announcement.additionalDetails
                        .filter(detail => detail.groupId === DetailsGroupEnum.Equipment)
                        .map(detail => this._translateService.instant("Lookup.AdditionalDetail." + detail.name));

                    this.additional = announcement.additionalDetails
                        .filter(detail => detail.groupId === DetailsGroupEnum.Additional)
                        .map(detail => this._translateService.instant("Lookup.AdditionalDetail." + detail.name));

                    if (announcement.latitude && announcement.longitude) {
                        const position = {
                            lat: announcement.latitude,
                            lng: announcement.longitude
                        };

                        this.markerOptions.visible = true;
                        this.markerOptions.position = position;
                        this.mapOptions.center = position;
                        this.mapOptions.zoom = 13;
                    }

                    if (announcement.photos.length > 0) {
                        this.galleryItems = announcement.photos.sort(p1 => p1.isMainPhoto ? -1 : 1).map(p => new ImageItem({ src: p.url, thumb: p.url }));
                    }
                })
            );
        }
    }

    handleFavoriteAnnouncement(announcement: MainAnnouncement): void {
        const action = announcement.isFavorite
            ? this._announcementService.removeFavoriteAnnouncement(announcement.id)
            : this._announcementService.addFavoriteAnnouncement(announcement.id);

        action.subscribe(() => {
            announcement.isFavorite = !announcement.isFavorite;
        });
    }
}
