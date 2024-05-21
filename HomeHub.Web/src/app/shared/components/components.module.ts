import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { GoogleMapsModule } from '@angular/google-maps';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material/material.module';

import { DialogComponent } from './dialog/dialog.component';
import { PaginatorComponent } from './paginator/paginator.component';

const components = [
    DialogComponent
];

@NgModule({
    declarations: components,
    imports: [
        CommonModule,
        MaterialModule,
        TranslateModule,
        PaginatorComponent
    ],
    exports: [...components, PaginatorComponent, GoogleMapsModule]
})
export class ComponentsModule { }
