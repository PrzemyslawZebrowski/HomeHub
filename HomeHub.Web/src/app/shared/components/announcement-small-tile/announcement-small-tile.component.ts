import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { SearchAnnouncement } from 'src/app/core/models/announcements/search-announcement.model';
import { MaterialModule } from 'src/app/material/material.module';

@Component({
    selector: 'hh-announcement-small-tile',
    standalone: true,
    imports: [
        CommonModule,
        MaterialModule,
        RouterLink,
        TranslateModule
    ],
    templateUrl: './announcement-small-tile.component.html',
    styleUrls: ['./announcement-small-tile.component.scss']
})
export class AnnouncementSmallTileComponent {
    @Input() announcement: SearchAnnouncement;
}
