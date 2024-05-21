import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GoogleMapsModule } from '@angular/google-maps';
import { TranslateModule } from '@ngx-translate/core';
import { GalleryModule } from 'ng-gallery';
import { LightboxModule } from 'ng-gallery/lightbox';
import { MaterialModule } from 'src/app/material/material.module';
import { AnnouncementFiltersComponent } from 'src/app/shared/components/announcement-filters/announcement-filters.component';
import { AnnouncementTileComponent } from 'src/app/shared/components/announcement-tile/announcement-tile.component';
import { BackButtonComponent } from 'src/app/shared/components/back-button/back-button.component';
import { SharedModule } from 'src/app/shared/shared.module';

import { AnnouncementsRoutingModule } from './announcements-routing.module';
import { AnnouncementsListComponent } from './pages/announcements-list/announcements-list.component';
import { MainAnnouncementComponent } from './pages/main-announcement/main-announcement.component';


@NgModule({
    declarations: [
        AnnouncementsListComponent,
        MainAnnouncementComponent
    ],
    imports: [
        CommonModule,
        AnnouncementsRoutingModule,
        MaterialModule,
        SharedModule,
        TranslateModule,
        GoogleMapsModule,
        GalleryModule,
        LightboxModule,
        AnnouncementTileComponent,
        AnnouncementFiltersComponent,
        BackButtonComponent
    ]
})
export class AnnouncementsModule { }
