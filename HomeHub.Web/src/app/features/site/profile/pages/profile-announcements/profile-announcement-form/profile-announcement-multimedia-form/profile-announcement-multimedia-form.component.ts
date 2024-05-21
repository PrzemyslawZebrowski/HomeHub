import { Component, Input } from '@angular/core';
import { FormArray, FormGroup } from '@angular/forms';
import { AnnouncementMultimedia, AnnouncementPhoto } from 'src/app/core/models/announcements/announcement-form.model';

@Component({
    selector: 'hh-profile-announcement-multimedia-form',
    templateUrl: './profile-announcement-multimedia-form.component.html',
    styleUrls: ['./profile-announcement-multimedia-form.component.scss']
})
export class ProfileAnnouncementMultimediaFormComponent {
    @Input() form: FormGroup<TypedFormControls<AnnouncementMultimedia>>;

    get photos(): FormArray<FormGroup<TypedFormControls<AnnouncementPhoto>>> {
        return this.form.controls.photos;
    }
}
