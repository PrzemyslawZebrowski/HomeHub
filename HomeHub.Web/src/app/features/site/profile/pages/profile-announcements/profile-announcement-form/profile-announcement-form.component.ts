import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, iif } from 'rxjs';
import {
    AnnouncementBasicInformation,
    AnnouncementContactDetails,
    AnnouncementDetails,
    AnnouncementForm,
    AnnouncementLocalization,
    AnnouncementMultimedia,
    AnnouncementPhoto,
    AnnouncementSubjectAndType
} from 'src/app/core/models/announcements/announcement-form.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';
import { UserService } from 'src/app/core/services/user.service';
import { indicate } from 'src/app/shared/operators/indicate';
import { urlValidator } from 'src/app/shared/validators/url-validator';

@Component({
    selector: 'hh-profile-announcement-form',
    templateUrl: './profile-announcement-form.component.html',
    styleUrls: ['./profile-announcement-form.component.scss']
})
export class ProfileAnnouncementFormComponent implements OnInit {
    announcementformGroup: FormGroup<TypedFormControls<AnnouncementForm>>;
    announcementId: number;
    isSaveing$ = new BehaviorSubject<boolean>(false);

    constructor(
        private _announcementService: AnnouncementService,
        private _userService: UserService,
        private _fb: FormBuilder,
        private _router: Router,
        route: ActivatedRoute
    ) {
        this.announcementId = route.snapshot.params['id'] as number;
    }

    ngOnInit(): void {
        this.initForm();
        if (this.announcementId) {
            this._announcementService.getAnnouncement(this.announcementId).subscribe(result => {
                this.subjectAndTypeFormGroup.patchValue(result);
                this.basicInformationFormGroup.patchValue(result);
                this.detailsFormGroup.patchValue(result);
                this.contactDetailsFormGroup.patchValue(result);
                this.localizationFormGroup.patchValue(result);
                this.multimediaFormGroup.patchValue(result);

                result.photos.forEach(photo => {
                    this.multimediaFormGroup.controls.photos.push(this._fb.group<TypedFormControls<AnnouncementPhoto>>({
                        id: this._fb.control(photo.id),
                        url: this._fb.nonNullable.control(photo.url),
                        file: this._fb.control(null),
                        isMainPhoto: this._fb.control(photo.isMainPhoto)
                    }));
                });
            });
        } else {
            this._userService.getCurrentUserDetails().subscribe(details => {
                this.basicInformationFormGroup.patchValue({
                    advertiserTypeId: details.advertiserTypeId
                });
                this.contactDetailsFormGroup.patchValue({
                    advertiserEmail: details.contactEmail,
                    advertiserName: details.name,
                    advertiserPhoneNumber: details.phoneNumber
                });
            });
        }
    }

    get subjectAndTypeFormGroup(): FormGroup<TypedFormControls<AnnouncementSubjectAndType>> {
        return this.announcementformGroup.controls.subjectType;
    }

    get basicInformationFormGroup(): FormGroup<TypedFormControls<AnnouncementBasicInformation>> {
        return this.announcementformGroup.controls.basicInformation;
    }

    get detailsFormGroup(): FormGroup<TypedFormControls<AnnouncementDetails>> {
        return this.announcementformGroup.controls.details;
    }

    get multimediaFormGroup(): FormGroup<TypedFormControls<AnnouncementMultimedia>> {
        return this.announcementformGroup.controls.multimedia;
    }

    get localizationFormGroup(): FormGroup<TypedFormControls<AnnouncementLocalization>> {
        return this.announcementformGroup.controls.localization;
    }

    get contactDetailsFormGroup(): FormGroup<TypedFormControls<AnnouncementContactDetails>> {
        return this.announcementformGroup.controls.contactDetails;
    }

    save(): void {
        if (this.subjectAndTypeFormGroup.valid) {
            const data = this.announcementformGroup.value as AnnouncementForm;
            iif(() => !this.announcementId,
                this._announcementService.addAnnouncement(data),
                this._announcementService.updateAnnouncements(this.announcementId, data)
            ).pipe(
                indicate(this.isSaveing$)
            ).subscribe(() => {
                this._router.navigate(['/profile', 'announcements']);
            });

        } else {
            this.subjectAndTypeFormGroup.markAllAsTouched();
        }
    }

    private initForm(): void {
        this.announcementformGroup = this._fb.group<TypedFormControls<AnnouncementForm>>({
            subjectType: this._fb.group<TypedFormControls<AnnouncementSubjectAndType>>({
                subjectTypeId: this._fb.control(null, [Validators.required]),
                typeId: this._fb.control(null, [Validators.required])
            }),
            basicInformation: this._fb.group<TypedFormControls<AnnouncementBasicInformation>>({
                title: this._fb.control(null, [Validators.required, Validators.maxLength(60)]),
                priceAmount: this._fb.control(null, [Validators.required, Validators.min(0)]),
                priceCurrency: this._fb.control(null, [Validators.required]),
                area: this._fb.control(null, [Validators.required, Validators.min(0)]),
                advertiserTypeId: this._fb.control(null, [Validators.required]),
                marketTypeId: this._fb.control(null, [Validators.required]),
                numberOfRooms: this._fb.control(null, [Validators.required, Validators.min(0)]),
            }),
            details: this._fb.group<TypedFormControls<AnnouncementDetails>>({
                description: this._fb.control(null, [Validators.required, Validators.maxLength(10000)]),
                developmentTypeId: this._fb.control(null, [Validators.required]),
                floorId: this._fb.control(null, [Validators.required]),
                numberOfFloors: this._fb.control(null, [Validators.required, Validators.min(0)]),
                buildingMaterialId: this._fb.control(null, [Validators.required]),
                windowTypeId: this._fb.control(null, [Validators.required]),
                heatingTypeId: this._fb.control(null, [Validators.required]),
                buildYear: this._fb.control(null, [Validators.required, Validators.min(1)]),
                buildingFinishConditionId: this._fb.control(null, [Validators.required]),
                ownershipFormId: this._fb.control(null, [Validators.required]),
                availableFrom: this._fb.control(null, [Validators.required]),
                additionalDetailIds: this._fb.control([])
            }),
            multimedia: this._fb.group<TypedFormControls<AnnouncementMultimedia>>({
                videoUrl: this._fb.control(null, [urlValidator()]),
                virtualWalkUrl: this._fb.control(null, [urlValidator()]),
                photos: this._fb.array<FormGroup<TypedFormControls<AnnouncementPhoto>>>([], [Validators.required, Validators.maxLength(25), Validators.minLength(1)]),
            }),
            localization: this._fb.group<TypedFormControls<AnnouncementLocalization>>({
                address: this._fb.control(null, [Validators.required]),
                latitude: this._fb.control(null, [Validators.required]),
                longitude: this._fb.control(null, [Validators.required])
            }),
            contactDetails: this._fb.group<TypedFormControls<AnnouncementContactDetails>>({
                advertiserName: this._fb.control(null, [Validators.required, Validators.maxLength(50)]),
                advertiserEmail: this._fb.control(null, [Validators.maxLength(50), Validators.email]),
                advertiserPhoneNumber: this._fb.control(null, [Validators.required, Validators.maxLength(15)])
            })
        });
    }
}
