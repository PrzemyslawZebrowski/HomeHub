import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'isDetailPresent'
})
export class IsDetailPresentPipe implements PipeTransform {

    transform(detailId: number, additionalDetailIds: Nullable<number[]>): boolean {
        return additionalDetailIds != null && additionalDetailIds.includes(detailId);
    }

}
