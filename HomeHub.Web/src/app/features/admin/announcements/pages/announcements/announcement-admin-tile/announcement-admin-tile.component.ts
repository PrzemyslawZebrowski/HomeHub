import { Component, Input } from '@angular/core';
import { AnnouncementStatusEnum } from 'src/app/core/enums/announcements/announcement-status.enum';
import { ProfileShortAnnouncement } from 'src/app/core/models/announcements/profile-short-announcement.model';
import { DATE_HOUR_FORMAT } from 'src/app/shared/values/date-formats';

@Component({
    selector: 'hh-announcement-admin-tile',
    templateUrl: './announcement-admin-tile.component.html',
    styleUrls: ['./announcement-admin-tile.component.scss']
})
export class AnnouncementAdminTileComponent {
    @Input() announcement: ProfileShortAnnouncement;
    dateHourFormat = DATE_HOUR_FORMAT;
    status = AnnouncementStatusEnum;
}
