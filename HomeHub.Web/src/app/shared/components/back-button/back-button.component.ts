import { CommonModule, Location } from '@angular/common';
import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material/material.module';

@Component({
    selector: 'hh-back-button',
    standalone: true,
    imports: [
        CommonModule,
        TranslateModule,
        MaterialModule,
        RouterModule
    ],
    templateUrl: './back-button.component.html',
    styleUrls: ['./back-button.component.scss']
})
export class BackButtonComponent {
    private readonly _location = inject(Location);

    back(): void {
        this._location.back();
    }
}
