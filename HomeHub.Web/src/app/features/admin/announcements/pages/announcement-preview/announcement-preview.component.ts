import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject, Observable, switchMap } from 'rxjs';
import { AnnouncementStatusEnum } from 'src/app/core/enums/announcements/announcement-status.enum';
import { AnnouncementForAdminPreview } from 'src/app/core/models/announcements/announcement.model';
import { AnnouncementService } from 'src/app/core/services/announcement.service';
import { indicate } from 'src/app/shared/operators/indicate';

@Component({
    selector: 'hh-announcement-preview',
    templateUrl: './announcement-preview.component.html',
    styleUrls: ['./announcement-preview.component.scss']
})
export class AnnouncementPreviewComponent implements OnInit {
    announcementId: number;
    announcementStatus = AnnouncementStatusEnum;
    announcement$: Observable<AnnouncementForAdminPreview>;
    isLoading$ = new BehaviorSubject<boolean>(false);
    isStatusChanging$ = new BehaviorSubject<boolean>(false);
    reload$ = new BehaviorSubject<void>(undefined);

    constructor(
        private _announcementService: AnnouncementService,
        route: ActivatedRoute
    ) {
        this.announcementId = route.snapshot.params['id'] as number;
    }

    ngOnInit(): void {
        this.announcement$ = this.reload$.pipe(
            switchMap(() => this._announcementService.getAnnouncementForAdminPreview(this.announcementId).pipe(
                indicate(this.isLoading$)
            ))
        );
    }

    onRefuse(): void {
        this._announcementService.refuseAnnouncement(this.announcementId).pipe(
            indicate(this.isStatusChanging$)
        ).subscribe(() => {
            this.reload();
        });
    }

    onApprove(): void {
        this._announcementService.approveAnnouncement(this.announcementId).pipe(
            indicate(this.isStatusChanging$)
        ).subscribe(() => {
            this.reload();
        });
    }

    reload(): void {
        this.reload$.next();
    }
}
