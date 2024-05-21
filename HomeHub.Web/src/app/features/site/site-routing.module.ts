import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MsalGuard } from '@azure/msal-angular';

import { HomeComponent } from './home/home.component';
import { SiteComponent } from './site.component';

const routes: Routes = [
    {
        path: '',
        component: SiteComponent,
        children: [
            {
                path: '',
                component: HomeComponent
            },
            {
                path: 'announcements',
                loadChildren: () => import('./announcements/announcements.module').then(m => m.AnnouncementsModule)
            },
            {
                path: 'profile',
                canActivate: [MsalGuard],
                loadChildren: () => import('./profile/profile.module').then(m => m.ProfileModule)
            },
            {
                path: 'users',
                loadChildren: () => import('./user/user.module').then(m => m.UserModule)
            }
        ],
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SiteRoutingModule { }
