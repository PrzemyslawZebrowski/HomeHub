import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { BehaviorSubject, debounceTime, Observable, Subject, switchMap, takeUntil } from 'rxjs';
import { AnnouncementStatusEnum } from 'src/app/core/enums/announcements/announcement-status.enum';
import {
    AnnouncementAdminFilters,
    AnnouncementAdminPaginationCriteria
} from 'src/app/core/models/announcements/announcement.model';
import { ProfileShortAnnouncement } from 'src/app/core/models/announcements/profile-short-announcement.model';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';
import { Page, PaginationCriteria } from 'src/app/core/models/pagination-criteria.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';
import { LookupService } from 'src/app/core/services/lookup.service';

@Component({
    selector: 'hh-announcements-list',
    templateUrl: './announcements.component.html',
    styleUrls: ['./announcements.component.scss']
})
export class AnnouncementsComponent implements OnInit, OnDestroy {
    announcements$: Observable<Page<ProfileShortAnnouncement>>;
    criteria$ = new BehaviorSubject<AnnouncementAdminPaginationCriteria>({
        pageSize: 10,
        pageNumber: 1,
        statusId: AnnouncementStatusEnum.Pending
    });
    statusFormGroup: FormGroup<TypedFormControls<AnnouncementAdminFilters>>;
    statuses$: Observable<Lookup[]>;
    private _destroy$ = new Subject<void>();

    constructor(
        private _announcementService: AnnouncementService,
        private _lookupService: LookupService,
        private _translateService: TranslateService,
        private _formBuilder: FormBuilder
    ) { }

    ngOnInit(): void {
        this.announcements$ = this.criteria$.pipe(
            switchMap(criteria => this._announcementService.getAdminAnnouncements(criteria))
        );

        this.statusFormGroup = this._formBuilder.group<TypedFormControls<AnnouncementAdminFilters>>({
            statusId: this._formBuilder.nonNullable.control(AnnouncementStatusEnum.Pending)
        });

        this.statuses$ = this._lookupService.getStatuses();

        this.statusFormGroup.valueChanges.pipe(
            debounceTime(300),
            takeUntil(this._destroy$)
        ).subscribe((formValue) => {
            this.criteria$.next({
                ...this.criteria$.value,
                ...formValue
            });
        });
    }

    ngOnDestroy(): void {
        this._destroy$.next();
        this._destroy$.complete();
    }

    reloadAnnouncements(): void {
        this.criteria$.next(this.criteria$.value);
    }

    onPageChanged(paginationCriteria: PaginationCriteria): void {
        this.criteria$.next({
            ...this.criteria$.value,
            ...paginationCriteria
        });
    }
}
