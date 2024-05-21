import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BehaviorSubject, Observable } from 'rxjs';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';
import { UserDetailsForm } from 'src/app/core/models/users/user-form.model';
import { LookupService } from 'src/app/core/services/lookup.service';
import { UserService } from 'src/app/core/services/user.service';
import { indicate } from 'src/app/shared/operators/indicate';

@Component({
    selector: 'hh-profile-details',
    templateUrl: './profile-details.component.html',
    styleUrls: ['./profile-details.component.scss']
})
export class ProfileDetailsComponent implements OnInit {
    @Input() form: FormGroup<TypedFormControls<UserDetailsForm>>;
    advertisers$: Observable<Lookup[]>;
    isSaving$ = new BehaviorSubject<boolean>(false);
    phonePattern = '^[0-9]{9,15}$';

    constructor(private _lookupService: LookupService,
        private _fb: FormBuilder,
        private _userService: UserService
    ) { }

    ngOnInit(): void {
        this.initForm();

        this.advertisers$ = this._lookupService.getAdvertiserTypes();

        this._userService.getCurrentUserDetails().subscribe(details => {
            this.form.patchValue(details);
        });
    }

    private initForm(): void {
        this.form = this._fb.group<TypedFormControls<UserDetailsForm>>({
            name: this._fb.control(null, [Validators.required, Validators.maxLength(50)]),
            contactEmail: this._fb.control(null, [Validators.maxLength(50), Validators.email]),
            phoneNumber: this._fb.control(null, [Validators.required, Validators.maxLength(15)]),
            advertiserTypeId: this._fb.control(null, [Validators.required])
        });
    }

    save(): void {
        if (this.form.valid) {
            const data = this.form.value as UserDetailsForm;
            this._userService.updateCurrentUserDetails(data).pipe(
                indicate(this.isSaving$)
            ).subscribe(() => this.form.markAsPristine());
        } else {
            this.form.markAllAsTouched();
        }
    }
}
