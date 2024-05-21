import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';

import { MaterialModule } from '../material/material.module';
import { SharedModule } from '../shared/shared.module';
import { AccessDeniedComponent } from './components/access-denied/access-denied.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';



@NgModule({
    declarations: [
        HeaderComponent,
        PageNotFoundComponent,
        AccessDeniedComponent,
        FooterComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        TranslateModule,
        RouterModule,
        SharedModule
    ],
    exports: [
        HeaderComponent,
        FooterComponent
    ]

})
export class CoreModule { }
