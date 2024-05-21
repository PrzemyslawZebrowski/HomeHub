import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ProfileAnnouncementFormComponent } from './profile-announcement-form/profile-announcement-form.component';
import { ProfileAnnouncementsListComponent } from './profile-announcements-list/profile-announcements-list.component';

const routes: Routes = [
    {
        path: '',
        component: ProfileAnnouncementsListComponent
    },
    {
        path: 'new',
        component: ProfileAnnouncementFormComponent
    },
    {
        path: ':id',
        component: ProfileAnnouncementFormComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProfileAnnouncementsRoutingModule { }
