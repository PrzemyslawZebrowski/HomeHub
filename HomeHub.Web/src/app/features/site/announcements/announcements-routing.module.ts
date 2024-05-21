import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AnnouncementsListComponent } from './pages/announcements-list/announcements-list.component';
import { MainAnnouncementComponent } from './pages/main-announcement/main-announcement.component';

const routes: Routes = [
    {
        path: '',
        component: AnnouncementsListComponent
    },
    {
        path: ':id',
        component: MainAnnouncementComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AnnouncementsRoutingModule { }
