import { NgModule } from '@angular/core';

import { SelectNamePipe } from './select-name.pipe';


const pipes = [
    SelectNamePipe
];

@NgModule({
    declarations: pipes,
    exports: pipes
})
export class PipesModule { }
