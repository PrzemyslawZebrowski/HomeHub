import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { AnnouncementTileComponent } from 'src/app/shared/components/announcement-tile/announcement-tile.component';
import { SharedModule } from 'src/app/shared/shared.module';

import { ProfileFavoriteComponent } from './profile-favorite.component';

@NgModule({
    declarations: [
        ProfileFavoriteComponent
    ],
    imports: [
        CommonModule,
        SharedModule,
        AnnouncementTileComponent
    ]
})
export class ProfileFavoriteModule { }
