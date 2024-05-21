import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material/material.module';

import { ProfileMenuComponent } from './components/profile-menu/profile-menu.component';
import { ProfileDetailsModule } from './pages/profile-details/profile-details.module';
import { ProfileFavoriteModule } from './pages/profile-favorite/profile-favorite.module';
import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileComponent } from './profile.component';


@NgModule({
    declarations: [
        ProfileComponent,
        ProfileMenuComponent
    ],
    imports: [
        CommonModule,
        ProfileRoutingModule,
        MaterialModule,
        TranslateModule,
        ProfileFavoriteModule,
        ProfileDetailsModule
    ]
})
export class ProfileModule { }
