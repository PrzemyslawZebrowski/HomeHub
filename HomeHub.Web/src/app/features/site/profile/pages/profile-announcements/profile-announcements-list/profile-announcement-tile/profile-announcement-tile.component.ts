import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AnnouncementStatusEnum } from 'src/app/core/enums/announcements/announcement-status.enum';
import { ProfileShortAnnouncement } from 'src/app/core/models/announcements/profile-short-announcement.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';
import { DATE_HOUR_FORMAT } from 'src/app/shared/values/date-formats';

@Component({
    selector: 'hh-profile-announcement-tile',
    templateUrl: './profile-announcement-tile.component.html',
    styleUrls: ['./profile-announcement-tile.component.scss']
})
export class ProfileAnnouncementTileComponent {
    @Input() announcement: ProfileShortAnnouncement;
    @Output() announcementClosed: EventEmitter<void> = new EventEmitter<void>;
    dateHourFormat = DATE_HOUR_FORMAT;
    status = AnnouncementStatusEnum;

    constructor(private _translateService: TranslateService, private _router: Router, private _announcementService: AnnouncementService) { }

    editAnnouncement(): void {
        this._router.navigate([`/profile/announcements/${this.announcement.id}`]);
    }

    closeAnnouncement(): void {
        this._announcementService.closeAnnouncement(this.announcement.id!).subscribe(() => {
            this.announcementClosed.emit();
        });
    }
}
