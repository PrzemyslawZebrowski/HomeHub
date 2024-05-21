import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material/material.module';
import { SharedModule } from 'src/app/shared/shared.module';

import { ProfileDetailsComponent } from './profile-details.component';



@NgModule({
    declarations: [
        ProfileDetailsComponent
    ],
    imports: [
        CommonModule,
        MaterialModule,
        TranslateModule,
        SharedModule,
        FormsModule,
        ReactiveFormsModule
    ]
})
export class ProfileDetailsModule { }
