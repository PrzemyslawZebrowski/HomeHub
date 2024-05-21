import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AnnouncementPreviewComponent } from './pages/announcement-preview/announcement-preview.component';
import { AnnouncementsComponent } from './pages/announcements/announcements.component';

const routes: Routes = [
    {
        path: '',
        component: AnnouncementsComponent,
    },
    {
        path: ':id',
        component: AnnouncementPreviewComponent,
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AnnouncementsRoutingModule { }
