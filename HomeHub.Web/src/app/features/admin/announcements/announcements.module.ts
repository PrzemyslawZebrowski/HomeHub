import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material/material.module';
import { AnnouncementSummaryComponent } from 'src/app/shared/components/announcement-summary/announcement-summary.component';
import { BackButtonComponent } from 'src/app/shared/components/back-button/back-button.component';
import { SharedModule } from 'src/app/shared/shared.module';

import { AnnouncementsRoutingModule } from './announcements-routing.module';
import { AnnouncementPreviewComponent } from './pages/announcement-preview/announcement-preview.component';
import {
    AnnouncementAdminTileComponent
} from './pages/announcements/announcement-admin-tile/announcement-admin-tile.component';
import { AnnouncementsComponent } from './pages/announcements/announcements.component';


@NgModule({
    declarations: [
        AnnouncementsComponent,
        AnnouncementAdminTileComponent,
        AnnouncementPreviewComponent
    ],
    imports: [
        CommonModule,
        AnnouncementsRoutingModule,
        MaterialModule,
        TranslateModule,
        SharedModule,
        FormsModule,
        ReactiveFormsModule,
        AnnouncementSummaryComponent,
        BackButtonComponent
    ]
})
export class AnnouncementsModule { }
