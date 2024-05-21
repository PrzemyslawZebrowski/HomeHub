import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SearchAnnouncementFilters } from 'src/app/core/models/announcements/search-announcement.model';
import { AnnouncementFiltersComponent } from 'src/app/shared/components/announcement-filters/announcement-filters.component';

import { LatestAnnouncementsComponent } from './latest-announcements/latest-announcements.component';
import { RecommendedAnnouncementsComponent } from './recommended-announcements/recommended-announcements.component';

@Component({
    selector: 'hh-home',
    templateUrl: './home.component.html',
    imports: [
        CommonModule,
        AnnouncementFiltersComponent,
        LatestAnnouncementsComponent,
        RecommendedAnnouncementsComponent
    ],
    standalone: true,
    styleUrls: ['./home.component.scss']
})
export class HomeComponent {
    constructor(private _router: Router) { }

    onSearch(filters: SearchAnnouncementFilters): void {
        this._router.navigate(['announcements'], {
            queryParams: filters,
            queryParamsHandling: 'merge',
        });
    }
}
