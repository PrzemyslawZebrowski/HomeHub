import { Component } from '@angular/core';
import { UserRoleEnum } from 'src/app/core/enums/users/user-role.enum';

@Component({
    selector: 'hh-admin-side-menu',
    templateUrl: './admin-side-menu.component.html',
    styleUrls: ['./admin-side-menu.component.scss']
})
export class AdminSideMenuComponent {
    userRoleEnum = UserRoleEnum;
}
