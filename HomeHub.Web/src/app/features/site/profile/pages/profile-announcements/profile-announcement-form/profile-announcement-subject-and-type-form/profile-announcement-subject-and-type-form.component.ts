import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { combineLatest, Observable } from 'rxjs';
import { AnnouncementSubjectAndType } from 'src/app/core/models/announcements/announcement-form.model';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';
import { LookupService } from 'src/app/core/services/lookup.service';

@Component({
    selector: 'hh-profile-announcement-subject-and-type-form',
    templateUrl: './profile-announcement-subject-and-type-form.component.html',
    styleUrls: ['./profile-announcement-subject-and-type-form.component.scss']
})
export class ProfileAnnouncementSubjectAndTypeFormComponent implements OnInit {
    @Input() form: FormGroup<TypedFormControls<AnnouncementSubjectAndType>>;
    lookups$: Observable<{ subjects: Lookup[], types: Lookup[] }>;

    constructor(private _lookupService: LookupService) { }

    ngOnInit(): void {
        this.lookups$ = combineLatest({
            subjects: this._lookupService.getAnnouncementSubjects(),
            types: this._lookupService.getAnnouncementTypes()
        });
    }
}
