import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material/material.module';
import { SharedModule } from 'src/app/shared/shared.module';

import { UserRoleDialogComponent } from './dialogs/user-role-dialog/user-role-dialog.component';
import { UsersComponent } from './pages/users.component';
import { UsersRoutingModule } from './users-routing.module';


@NgModule({
    declarations: [UsersComponent, UserRoleDialogComponent],
    imports: [
        CommonModule,
        UsersRoutingModule,
        MaterialModule,
        TranslateModule,
        FormsModule,
        ReactiveFormsModule,
        SharedModule
    ]
})
export class UsersModule { }
