import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function urlValidator(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        if (!control.value) {
            return null;
        }

        const urlPattern = /^(ftp|http|https):\/\/[^ "]+$/;

        if (!urlPattern.test(control.value)) {
            return { invalidUrl: true };
        }

        return null;
    };
}
