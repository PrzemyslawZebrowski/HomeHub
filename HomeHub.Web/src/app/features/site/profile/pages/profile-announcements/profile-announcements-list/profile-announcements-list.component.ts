import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BehaviorSubject, debounceTime, Observable, Subject, switchMap, takeUntil } from 'rxjs';
import {
    AnnouncementProfileFilters,
    AnnouncementProfilePaginationCriteria
} from 'src/app/core/models/announcements/announcement.model';
import { ProfileShortAnnouncement } from 'src/app/core/models/announcements/profile-short-announcement.model';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';
import { Page, PaginationCriteria } from 'src/app/core/models/pagination-criteria.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';
import { LookupService } from 'src/app/core/services/lookup.service';

@Component({
    selector: 'hh-profile-announcements-list',
    templateUrl: './profile-announcements-list.component.html',
    styleUrls: ['./profile-announcements-list.component.scss']
})
export class ProfileAnnouncementsListComponent implements OnInit, OnDestroy {
    announcements$: Observable<Page<ProfileShortAnnouncement>>;
    criteria$ = new BehaviorSubject<AnnouncementProfilePaginationCriteria>({
        pageSize: 10,
        pageNumber: 1,
        title: '',
        statusId: null
    });
    default = null;
    formGroup: FormGroup<TypedFormControls<AnnouncementProfileFilters>>;
    statuses$: Observable<Lookup[]>;
    private _destroy$ = new Subject<void>();

    constructor(
        private _announcementService: AnnouncementService,
        private _formBuilder: FormBuilder,
        private _lookupService: LookupService
    ) { }

    ngOnInit(): void {
        this.announcements$ = this.criteria$.pipe(
            switchMap(criteria => this._announcementService.getProfileAnnouncements(criteria))
        );

        this.formGroup = this._formBuilder.group<TypedFormControls<AnnouncementProfileFilters>>({
            title: this._formBuilder.nonNullable.control(''),
            statusId: this._formBuilder.control(null)
        });

        this.statuses$ = this._lookupService.getStatuses();

        this.formGroup.valueChanges.pipe(
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
