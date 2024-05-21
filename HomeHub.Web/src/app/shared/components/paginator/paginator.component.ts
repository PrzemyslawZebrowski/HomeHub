import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatPaginatorIntl, PageEvent } from '@angular/material/paginator';
import { TranslateModule } from '@ngx-translate/core';
import { Page, PaginationCriteria } from 'src/app/core/models/pagination-criteria.model';
import { MaterialModule } from 'src/app/material/material.module';

import { CustomMatPaginatorIntl } from './custom-mat-paginator-intl';

export type PaginatorOptions = {
    showShadow: boolean;
};

@Component({
    selector: 'hh-paginator',
    templateUrl: './paginator.component.html',
    styleUrls: ['./paginator.component.scss'],
    standalone: true,
    imports: [
        CommonModule,
        MaterialModule,
        TranslateModule
    ],
    providers: [{
        provide: MatPaginatorIntl,
        useClass: CustomMatPaginatorIntl
    }]
})
export class PaginatorComponent<T> {
    @Input() set page(page: Page<T>) {
        if (page && page.totalCount) {
            this.totalCount = page.totalCount;
            this.pageNumber = page.pageNumber - 1;
            this.pageSize = page.pageSize;
        }

        this.hidden = !page.totalCount;
    }

    @Input() options: PaginatorOptions = {
        showShadow: true
    };

    @Output() pageChanged = new EventEmitter<PaginationCriteria>();

    hidden: boolean;
    totalCount: number;
    pageSize: number;
    pageNumber: number;

    handlePageEvent(event: PageEvent): void {
        const searchCriteria = {
            pageSize: event.pageSize,
            pageNumber: event.pageIndex + 1
        } as PaginationCriteria;

        this.pageChanged.emit(searchCriteria);
    }
}
