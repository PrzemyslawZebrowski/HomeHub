import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { CoreModule } from 'src/app/core/core.module';
import { MaterialModule } from 'src/app/material/material.module';
import { SharedModule } from 'src/app/shared/shared.module';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminSideMenuComponent } from './admin-side-menu/admin-side-menu.component';
import { AdminComponent } from './admin.component';

@NgModule({
    declarations: [
        AdminComponent,
        AdminSideMenuComponent
    ],
    imports: [
        CommonModule,
        AdminRoutingModule,
        CoreModule,
        MaterialModule,
        TranslateModule,
        SharedModule
    ]
})
export class AdminModule { }
