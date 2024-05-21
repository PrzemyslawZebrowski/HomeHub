import { Injectable, OnDestroy } from '@angular/core';
import { MatPaginatorIntl } from '@angular/material/paginator';
import { TranslateService } from '@ngx-translate/core';
import { Subject, takeUntil } from 'rxjs';

@Injectable()
export class CustomMatPaginatorIntl extends MatPaginatorIntl implements OnDestroy {
    private _destroy$ = new Subject<void>();

    constructor(private _translateService: TranslateService) {
        super();
        this._translateService.onLangChange.pipe(
            takeUntil(this._destroy$)
        ).subscribe(() => {
            this.getTranslations();
        });
    }

    ngOnDestroy(): void {
        this._destroy$.next();
        this._destroy$.complete();
    }

    getTranslations(): void {
        this._translateService.get([
            'Paginator.ItemsPerPageLabel',
            'Paginator.NextPageLabel',
            'Paginator.PreviousPageLabel',
            'Paginator.FirstPageLabel',
            'Paginator.LastPageLabel'
        ]).subscribe(transitions => {
            this.itemsPerPageLabel = transitions['Paginator.ItemsPerPageLabel'];
            this.nextPageLabel = transitions['Paginator.NextPageLabel'];
            this.previousPageLabel = transitions['Paginator.PreviousPageLabel'];
            this.firstPageLabel = transitions['Paginator.FirstPageLabel'];
            this.lastPageLabel = transitions['Paginator.LastPageLabel'];
            this.changes.next();
        });
    }


    override getRangeLabel = (page: number, pageSize: number, length: number): string => {
        if (length === 0 || pageSize === 0) {
            return this._translateService.instant('Paginator.RangePageLabel1', { length });
        }
        length = Math.max(length, 0);
        const startIndex = page * pageSize;
        const endIndex = startIndex < length ? Math.min(startIndex + pageSize, length) : startIndex + pageSize;
        return this._translateService.instant('Paginator.RangePageLabel2', { startIndex: startIndex + 1, endIndex, length });
    };
}
