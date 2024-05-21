import { Component, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AnnouncementContactDetails } from 'src/app/core/models/announcements/announcement-form.model';

@Component({
    selector: 'hh-profile-announcement-contact-details-form',
    templateUrl: './profile-announcement-contact-details-form.component.html',
    styleUrls: ['./profile-announcement-contact-details-form.component.scss']
})
export class ProfileAnnouncementContactDetailsFormComponent {
    @Input() form: FormGroup<TypedFormControls<AnnouncementContactDetails>>;
    phonePattern = '^[0-9]{9,15}$';
}
