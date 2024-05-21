import { Injectable, Type } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

import { DialogComponent } from '../../shared/components/dialog/dialog.component';

@Injectable({
    providedIn: 'root'
})
export class DialogService {
    constructor(
        private _matDialog: MatDialog,
    ) { }

    openDialog<T, D>(component: Type<T>, title: string, data: D): MatDialogRef<DialogComponent<T, D>, D> {
        const dialogRef = this._matDialog.open<DialogComponent<T, D>, D>(DialogComponent<T, D>, {
            width: '400px',
            data: data
        });
        dialogRef.componentInstance.dialogSettings = { component, title };
        return dialogRef;
    }
}
