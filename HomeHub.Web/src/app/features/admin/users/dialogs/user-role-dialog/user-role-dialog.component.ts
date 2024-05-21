import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BehaviorSubject, Observable } from 'rxjs';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';
import { LookupService } from 'src/app/core/services/lookup.service';
import { UserService } from 'src/app/core/services/user.service';
import { indicate } from 'src/app/shared/operators/indicate';

export type UserRoleDialogData = {
    userId: string;
    roleId: number;
};

@Component({
    selector: 'hh-user-role-dialog',
    templateUrl: './user-role-dialog.component.html',
    styleUrls: ['./user-role-dialog.component.scss']
})
export class UserRoleDialogComponent implements OnInit {
    roleFormGroup: FormGroup;
    roles$: Observable<Lookup[]>;
    isSaveing$ = new BehaviorSubject<boolean>(false);

    constructor(
        @Inject(MAT_DIALOG_DATA) public data: UserRoleDialogData,
        private _formBuilder: FormBuilder,
        private _dialogRef: MatDialogRef<UserRoleDialogComponent>,
        private _lookupService: LookupService,
        private _userService: UserService
    ) { }

    ngOnInit(): void {
        this.roleFormGroup = this._formBuilder.group({
            userRoleId: this._formBuilder.control(this.data.roleId)
        });
        this.roles$ = this._lookupService.getRoles();
    }

    onSaveClick(): void {
        this._userService.updateUserRole(this.data.userId, this.roleFormGroup.value.userRoleId)
            .pipe(
                indicate(this.isSaveing$)
            ).subscribe(() => {
                this._dialogRef.close(true);
            });
    }
}
