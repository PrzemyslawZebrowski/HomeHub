import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { AnnouncementForm } from 'src/app/core/models/announcements/announcement-form.model';
import { Announcement } from 'src/app/core/models/announcements/announcement.model';

@Component({
    selector: 'hh-profile-announcement-summary-form',
    templateUrl: './profile-announcement-summary-form.component.html',
    styleUrls: ['./profile-announcement-summary-form.component.scss']
})
export class ProfileAnnouncementSummaryFormComponent {
    @Input() form: FormGroup<TypedFormControls<AnnouncementForm>>;

    constructor(private _translateService: TranslateService) {
    }

    get flatFormValue(): Announcement {
        const formValue = this.form.value;

        return {
            ...formValue.subjectType,
            ...formValue.basicInformation,
            ...formValue.details,
            ...formValue.multimedia,
            ...formValue.localization,
            ...formValue.contactDetails
        } as Announcement;
    }
}
