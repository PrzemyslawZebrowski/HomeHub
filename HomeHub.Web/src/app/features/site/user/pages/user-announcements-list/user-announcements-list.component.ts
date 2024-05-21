import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BehaviorSubject, Observable, switchMap } from 'rxjs';
import {
    SearchAnnouncement,
    SearchAnnouncementFilters,
    SearchAnnouncementPaginationCriteria
} from 'src/app/core/models/announcements/search-announcement.model';
import { Page, PaginationCriteria } from 'src/app/core/models/pagination-criteria.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';

@Component({
    selector: 'hh-user-announcements-list',
    templateUrl: './user-announcements-list.component.html',
    styleUrls: ['./user-announcements-list.component.scss']
})
export class UserAnnouncementsListComponent implements OnInit {
    userId: string;
    announcements$: Observable<Page<SearchAnnouncement>>;
    criteria$ = new BehaviorSubject<SearchAnnouncementPaginationCriteria>({
        pageSize: 10,
        pageNumber: 1
    } as SearchAnnouncementPaginationCriteria);

    initCriteriaFormUrl = this.getInitSearchAnnouncementFiltersFromUrl();

    constructor(
        private _route: ActivatedRoute,
        private _announcementService: AnnouncementService,
        private _router: Router
    ) {
        this.userId = this._route.snapshot.params['id'] as string;
    }

    ngOnInit(): void {
        this.announcements$ = this.criteria$.pipe(
            switchMap(criteria => this._announcementService.getAnnouncementsByUser(criteria, this.userId))
        );
    }

    getInitSearchAnnouncementFiltersFromUrl(): SearchAnnouncementPaginationCriteria {
        const paramMap = this._route.snapshot.queryParams;

        return {
            pageSize: paramMap['pageSize'] || 10,
            pageNumber: paramMap['pageNumber'] || 1,
            address: paramMap['address'] || undefined,
            radiusDistance: +paramMap['radiusDistance'] || 5,
            longitude: +paramMap['longitude'] || undefined,
            latitude: +paramMap['latitude'] || undefined,
            subjectTypeId: +paramMap['subjectTypeId'] || undefined,
            announcementTypeId: +paramMap['announcementTypeId'] || undefined,
            advertiserTypeId: +paramMap['advertiserTypeId'] || undefined,
            marketTypeId: +paramMap['marketTypeId'] || undefined,
            priceAmountMin: +paramMap['priceAmountMin'] || undefined,
            priceAmountMax: +paramMap['priceAmountMax'] || undefined,
            areaMin: +paramMap['areaMin'] || undefined,
            areaMax: +paramMap['areaMax'] || undefined,
            numberOfRoomsMin: +paramMap['numberOfRoomsMin'] || undefined,
            numberOfRoomsMax: +paramMap['numberOfRoomsMax'] || undefined
        };
    }

    reloadAnnouncements(): void {
        this.criteria$.next(this.criteria$.value);
    }

    onPageChanged(paginationCriteria: PaginationCriteria): void {
        this.criteria$.next(paginationCriteria);
    }

    onSearch(filters: SearchAnnouncementFilters): void {
        const updatedCriteria = { ...this.criteria$.value, ...filters } as SearchAnnouncementPaginationCriteria;
        this.criteria$.next(updatedCriteria);

        this._router.navigate([], {
            relativeTo: this._route,
            queryParams: updatedCriteria,
            queryParamsHandling: 'merge',
        });
    }
}
