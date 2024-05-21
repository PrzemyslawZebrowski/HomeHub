import { Component, Input } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { AnnouncementPhoto } from 'src/app/core/models/announcements/announcement-form.model';
import { environment } from 'src/environments/environment';

@Component({
    selector: 'hh-photos-uploader',
    templateUrl: './photos-uploader.component.html',
    styleUrls: ['./photos-uploader.component.scss']
})
export class PhotosUploaderComponent {
    @Input() photos: FormArray<FormGroup<TypedFormControls<AnnouncementPhoto>>>;

    constructor(private _fb: FormBuilder) { }

    async onImageUplod(event: Event): Promise<void> {
        const { files } = event.target as HTMLInputElement;

        if (files && files.length > 0) {

            for (let i = 0; i < files.length; i++) {
                if (i >= 25) {
                    break;
                }

                const file = files.item(i) as File;
                if (file.size > environment.maxUploadedFileSizeInBytes) {
                    continue;
                }

                this.photos.push(this._fb.group<TypedFormControls<AnnouncementPhoto>>({
                    id: this._fb.control(null),
                    file: this._fb.control(file),
                    url: this._fb.nonNullable.control(await this.getBase64ImageFromUrl(file)),
                    isMainPhoto: this._fb.control(this.photos.length === 0)
                }));
            }
        }
    }

    setAsMainPhoto(index: number): void {
        this.photos.controls.forEach((photo, i) => photo.get('isMainPhoto')?.setValue(index === i));
    }

    removePhoto(index: number): void {
        const isProfilePhoto = this.photos.at(index).value.isMainPhoto && this.photos.length > 1;

        this.photos.removeAt(index);

        if (isProfilePhoto) {
            this.photos.at(0).get('isMainPhoto')?.setValue(true);
        }
    }

    private getBase64ImageFromUrl(file: File): Promise<string> {
        return new Promise<string>((resolve, reject) => {
            const reader = new FileReader();

            reader.onload = (): void => resolve(reader.result as string);
            reader.onerror = (error): void => reject(error);
            reader.readAsDataURL(file);
        });
    }
}
