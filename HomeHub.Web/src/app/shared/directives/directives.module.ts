import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { HasRoleDirective } from './has-role.directive';
import { MatButtonLoadingDirective } from './mat-button-loading.directive';

const directives = [
    HasRoleDirective,
    MatButtonLoadingDirective
];

@NgModule({
    declarations: directives,
    imports: [
        CommonModule
    ],
    exports: directives
})
export class DirectivesModule { }
