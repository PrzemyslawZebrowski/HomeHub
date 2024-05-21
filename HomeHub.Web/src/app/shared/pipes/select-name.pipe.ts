import { Pipe, PipeTransform } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';

@Pipe({
    name: 'selectName'
})
export class SelectNamePipe implements PipeTransform {

    constructor(private _translateService: TranslateService) {
    }

    transform(array: Lookup[], translatePath: string, ids: Nullable<number[]> | Nullable<number>): string {
        if (!ids) {
            return '';
        }

        if (ids instanceof Array) {
            return array.filter(x => ids.includes(x.id))
                .map(x => this._translateService.instant(translatePath + x.name))
                .join(", ");
        }

        return this._translateService.instant(translatePath + array.find(x => x.id === ids)?.name);
    }
}
