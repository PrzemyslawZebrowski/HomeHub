import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProfileDetailsComponent } from './pages/profile-details/profile-details.component';
import { ProfileFavoriteComponent } from './pages/profile-favorite/profile-favorite.component';
import { ProfileComponent } from './profile.component';

const routes: Routes = [
    {
        path: '',
        component: ProfileComponent,
        children: [
            {
                path: '',
                redirectTo: 'details',
                pathMatch: 'full'
            },
            {
                path: 'details',
                component: ProfileDetailsComponent,
            },
            {
                path: 'announcements',
                loadChildren: () => import('./pages/profile-announcements/profile-announcements.module').then(m => m.ProfileAnnouncementsModule)
            },
            {
                path: 'favorite',
                component: ProfileFavoriteComponent
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProfileRoutingModule { }
