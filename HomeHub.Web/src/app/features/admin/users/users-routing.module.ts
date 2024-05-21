import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MsalGuard } from '@azure/msal-angular';
import { UserRoleEnum } from 'src/app/core/enums/users/user-role.enum';
import { HasRoleGuard } from 'src/app/core/guards/has-role.guard';

import { UsersComponent } from './pages/users.component';

const routes: Routes = [
    {
        path: '',
        component: UsersComponent,
        canActivate: [MsalGuard, HasRoleGuard],
        data: { requiredRoles: [UserRoleEnum.Admin] },
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UsersRoutingModule { }
