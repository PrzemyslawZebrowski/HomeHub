import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { AuthService } from 'src/app/auth/auth.service';
import { SearchAnnouncement } from 'src/app/core/models/announcements/search-announcement.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';
import { MaterialModule } from 'src/app/material/material.module';

@Component({
    selector: 'hh-announcement-tile',
    standalone: true,
    imports: [
        CommonModule,
        TranslateModule,
        MaterialModule,
        RouterLink
    ],
    templateUrl: './announcement-tile.component.html',
    styleUrls: ['./announcement-tile.component.scss']
})
export class AnnouncementTileComponent {
    @Input() announcement: SearchAnnouncement;
    isLoggedIn$: Observable<boolean>;

    constructor(private _announcementService: AnnouncementService, private _authService: AuthService) {
        this.isLoggedIn$ = this._authService.authStatus$;
    }

    handleFavoriteAnnouncement(): void {
        const action = this.announcement.isFavorite
            ? this._announcementService.removeFavoriteAnnouncement(this.announcement.id)
            : this._announcementService.addFavoriteAnnouncement(this.announcement.id);

        action.subscribe(() => {
            this.announcement.isFavorite = !this.announcement.isFavorite;
        });
    }
}
