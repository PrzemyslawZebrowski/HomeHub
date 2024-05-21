import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { SearchAnnouncement } from 'src/app/core/models/announcements/search-announcement.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';
import { MaterialModule } from 'src/app/material/material.module';
import {
    AnnouncementSmallTileComponent
} from 'src/app/shared/components/announcement-small-tile/announcement-small-tile.component';

@Component({
    selector: 'hh-latest-announcements',
    standalone: true,
    imports: [
        CommonModule,
        AnnouncementSmallTileComponent,
        MaterialModule,
        TranslateModule
    ],
    templateUrl: './latest-announcements.component.html',
    styleUrls: ['./latest-announcements.component.scss']
})
export class LatestAnnouncementsComponent implements OnInit {
    private readonly _announcementService = inject(AnnouncementService);
    announcements$: Observable<SearchAnnouncement[]>;

    ngOnInit(): void {
        this.announcements$ = this._announcementService.getLatestAnnouncements(6);
    }
}
