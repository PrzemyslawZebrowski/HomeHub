import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GoogleMapsModule } from '@angular/google-maps';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material/material.module';
import { AnnouncementSummaryComponent } from 'src/app/shared/components/announcement-summary/announcement-summary.component';
import { SharedModule } from 'src/app/shared/shared.module';

import {
    ProfileAnnouncementBasicInformationFormComponent
} from './profile-announcement-form/profile-announcement-basic-information-form/profile-announcement-basic-information-form.component';
import {
    ProfileAnnouncementContactDetailsFormComponent
} from './profile-announcement-form/profile-announcement-contact-details-form/profile-announcement-contact-details-form.component';
import {
    ProfileAnnouncementDetailsFormComponent
} from './profile-announcement-form/profile-announcement-details-form/profile-announcement-details-form.component';
import { ProfileAnnouncementFormComponent } from './profile-announcement-form/profile-announcement-form.component';
import {
    ProfileAnnouncementLocalizationFormComponent
} from './profile-announcement-form/profile-announcement-localization-form/profile-announcement-localization-form.component';
import {
    PhotosUploaderComponent
} from './profile-announcement-form/profile-announcement-multimedia-form/photos-uploader/photos-uploader.component';
import {
    ProfileAnnouncementMultimediaFormComponent
} from './profile-announcement-form/profile-announcement-multimedia-form/profile-announcement-multimedia-form.component';
import {
    ProfileAnnouncementSubjectAndTypeFormComponent
} from './profile-announcement-form/profile-announcement-subject-and-type-form/profile-announcement-subject-and-type-form.component';
import {
    ProfileAnnouncementSummaryFormComponent
} from './profile-announcement-form/profile-announcement-summary-form/profile-announcement-summary-form.component';
import {
    ProfileAnnouncementTileComponent
} from './profile-announcements-list/profile-announcement-tile/profile-announcement-tile.component';
import { ProfileAnnouncementsListComponent } from './profile-announcements-list/profile-announcements-list.component';
import { ProfileAnnouncementsRoutingModule } from './profile-announcements-routing.module';
import { IsDetailPresentPipe } from './profile-announcement-form/profile-announcement-details-form/is-detail-present.pipe';


@NgModule({
    declarations: [
        ProfileAnnouncementsListComponent,
        ProfileAnnouncementFormComponent,
        ProfileAnnouncementBasicInformationFormComponent,
        ProfileAnnouncementLocalizationFormComponent,
        ProfileAnnouncementDetailsFormComponent,
        ProfileAnnouncementContactDetailsFormComponent,
        ProfileAnnouncementSubjectAndTypeFormComponent,
        ProfileAnnouncementSummaryFormComponent,
        ProfileAnnouncementMultimediaFormComponent,
        PhotosUploaderComponent,
        ProfileAnnouncementTileComponent,
        IsDetailPresentPipe
    ],
    imports: [
        CommonModule,
        ProfileAnnouncementsRoutingModule,
        ReactiveFormsModule,
        MaterialModule,
        TranslateModule,
        SharedModule,
        GoogleMapsModule,
        AnnouncementSummaryComponent,
        FormsModule
    ]
})
export class ProfileAnnouncementsModule { }
