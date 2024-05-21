import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CoreModule } from 'src/app/core/core.module';

import { SiteRoutingModule } from './site-routing.module';
import { SiteComponent } from './site.component';


@NgModule({
    declarations: [
        SiteComponent
    ],
    imports: [
        CommonModule,
        SiteRoutingModule,
        CoreModule
    ]
})
export class SiteModule { }
