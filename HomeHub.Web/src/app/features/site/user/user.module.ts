import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material/material.module';
import { AnnouncementFiltersComponent } from 'src/app/shared/components/announcement-filters/announcement-filters.component';
import { AnnouncementTileComponent } from 'src/app/shared/components/announcement-tile/announcement-tile.component';
import { SharedModule } from 'src/app/shared/shared.module';

import { UserBarComponent } from './components/user-bar/user-bar.component';
import { UserAnnouncementsListComponent } from './pages/user-announcements-list/user-announcements-list.component';
import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';


@NgModule({
    declarations: [
        UserAnnouncementsListComponent,
        UserComponent,
        UserBarComponent
    ],
    imports: [
        CommonModule,
        UserRoutingModule,
        MaterialModule,
        SharedModule,
        TranslateModule,
        AnnouncementTileComponent,
        AnnouncementFiltersComponent
    ]
})
export class UserModule { }
