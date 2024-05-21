import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { SearchAnnouncement } from 'src/app/core/models/announcements/search-announcement.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';
import {
    AnnouncementSmallTileComponent
} from 'src/app/shared/components/announcement-small-tile/announcement-small-tile.component';

@Component({
    selector: 'hh-recommended-announcements',
    standalone: true,
    imports: [
        CommonModule,
        AnnouncementSmallTileComponent,
        TranslateModule
    ],
    templateUrl: './recommended-announcements.component.html',
    styleUrls: ['./recommended-announcements.component.scss']
})
export class RecommendedAnnouncementsComponent implements OnInit {
    private readonly _announcementService = inject(AnnouncementService);
    announcements$: Observable<SearchAnnouncement[]>;

    ngOnInit(): void {
        this.announcements$ = this._announcementService.getRandomAnnouncements(4);
    }
}
