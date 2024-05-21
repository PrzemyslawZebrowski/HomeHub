import { Component, OnInit } from '@angular/core';
import { BehaviorSubject, Observable, switchMap } from 'rxjs';
import { SearchAnnouncement } from 'src/app/core/models/announcements/search-announcement.model';
import { Page, PaginationCriteria } from 'src/app/core/models/pagination-criteria.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';

@Component({
    selector: 'hh-profile-favorite',
    templateUrl: './profile-favorite.component.html',
    styleUrls: ['./profile-favorite.component.scss']
})
export class ProfileFavoriteComponent implements OnInit {
    announcements$: Observable<Page<SearchAnnouncement>>;
    criteria$ = new BehaviorSubject<PaginationCriteria>({
        pageSize: 10,
        pageNumber: 1
    });

    constructor(
        private _announcementService: AnnouncementService
    ) { }

    ngOnInit(): void {
        this.announcements$ = this.criteria$.pipe(
            switchMap(criteria => this._announcementService.getFavoriteAnnouncements(criteria))
        );
    }

    reloadAnnouncements(): void {
        this.criteria$.next(this.criteria$.value);
    }

    onPageChanged(paginationCriteria: PaginationCriteria): void {
        this.criteria$.next(paginationCriteria);
    }
}
