import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UserAnnouncementsListComponent } from './pages/user-announcements-list/user-announcements-list.component';
import { UserComponent } from './user.component';

const routes: Routes = [
    {
        path: ':id',
        component: UserComponent,
        children: [
            {
                path: '',
                component: UserAnnouncementsListComponent
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UserRoutingModule { }
