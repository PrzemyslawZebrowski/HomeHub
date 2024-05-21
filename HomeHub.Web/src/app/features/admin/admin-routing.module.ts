import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MsalGuard } from '@azure/msal-angular';
import { UserRoleEnum } from 'src/app/core/enums/users/user-role.enum';
import { HasRoleGuard } from 'src/app/core/guards/has-role.guard';

import { AdminComponent } from './admin.component';

const routes: Routes = [
    {
        path: '',
        canActivate: [MsalGuard, HasRoleGuard],
        data: { requiredRoles: [UserRoleEnum.Admin, UserRoleEnum.Moderator] },
        component: AdminComponent,
        children: [
            {
                path: '',
                redirectTo: 'announcements',
                pathMatch: 'full'
            },
            {
                path: 'users',
                loadChildren: () => import('./users/users.module').then(m => m.UsersModule)
            },
            {
                path: 'announcements',
                loadChildren: () => import('./announcements/announcements.module').then(m => m.AnnouncementsModule)
            }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AdminRoutingModule { }
