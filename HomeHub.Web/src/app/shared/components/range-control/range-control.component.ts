import { CommonModule } from '@angular/common';
import { Component, Input, OnInit, Optional } from '@angular/core';
import { FormGroup, FormGroupDirective, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material/material.module';

@Component({
    selector: 'hh-range-control[minControl][maxControl]',
    standalone: true,
    imports: [
        CommonModule,
        MaterialModule,
        TranslateModule,
        FormsModule,
        ReactiveFormsModule
    ],
    templateUrl: './range-control.component.html',
    styleUrls: ['./range-control.component.scss']
})
export class RangeControlComponent implements OnInit {
    @Input() label = '';
    @Input() unit = '';
    @Input() minControl: string;
    @Input() maxControl: string;
    @Input() minValue: number | null = null;
    @Input() autocompleteOptions: number[] = [];

    form: FormGroup;


    constructor(@Optional() private _formGroup: FormGroupDirective) { }

    ngOnInit(): void {
        this.form = this._formGroup?.form;
    }

    onBlur(controlName: string): void {
        if (this.minValue === null) {
            return;
        }

        const control = this.form.get(controlName);

        if (control && control.value < this.minValue) {
            control.setValue(this.minValue);
        }
    }
}
