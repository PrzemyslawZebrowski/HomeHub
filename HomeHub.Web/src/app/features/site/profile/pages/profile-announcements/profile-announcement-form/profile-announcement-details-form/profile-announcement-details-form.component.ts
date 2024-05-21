import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { combineLatest, map, Observable, shareReplay } from 'rxjs';
import { DetailsGroupEnum } from 'src/app/core/enums/announcements/details-group.enum';
import { AnnouncementDetails } from 'src/app/core/models/announcements/announcement-form.model';
import { AdditionalDetail } from 'src/app/core/models/lookups/additional-detail.model';
import { Lookup } from 'src/app/core/models/lookups/lookup.model';
import { LookupService } from 'src/app/core/services/lookup.service';

@Component({
    selector: 'hh-profile-announcement-details-form',
    templateUrl: './profile-announcement-details-form.component.html',
    styleUrls: ['./profile-announcement-details-form.component.scss']
})
export class ProfileAnnouncementDetailsFormComponent implements OnInit {
    @Input() form: FormGroup<TypedFormControls<AnnouncementDetails>>;
    lookups$: Observable<{
        developments: Lookup[],
        floors: Lookup[],
        buildingMaterials: Lookup[],
        windows: Lookup[],
        heatings: Lookup[],
        buildingFinishConditions: Lookup[],
        ownerships: Lookup[],
        media: AdditionalDetail[],
        security: AdditionalDetail[],
        equipment: AdditionalDetail[],
        additional: AdditionalDetail[],
        remote: AdditionalDetail[],
    }>;

    details$: Observable<AdditionalDetail[]>;

    constructor(private _lookupService: LookupService) { }

    ngOnInit(): void {
        this.details$ = this._lookupService.getAdditionalDetails().pipe(
            shareReplay()
        );

        this.lookups$ = combineLatest({
            developments: this._lookupService.getDevelopmentTypes(),
            floors: this._lookupService.getFloors(),
            buildingMaterials: this._lookupService.getBuildingMaterials(),
            windows: this._lookupService.getWindowTypes(),
            heatings: this._lookupService.getHeatingTypes(),
            buildingFinishConditions: this._lookupService.getBuildingFinishConditions(),
            ownerships: this._lookupService.getOwnershipForms(),
            media: this.details$.pipe(
                map(details => details.filter(detail => DetailsGroupEnum.Media === detail.groupId))
            ),
            security: this.details$.pipe(
                map(details => details.filter(detail => DetailsGroupEnum.Security === detail.groupId))
            ),
            equipment: this.details$.pipe(
                map(details => details.filter(detail => DetailsGroupEnum.Equipment === detail.groupId))
            ),
            additional: this.details$.pipe(
                map(details => details.filter(detail => DetailsGroupEnum.Additional === detail.groupId))
            ),
            remote: this.details$.pipe(
                map(details => details.filter(detail => DetailsGroupEnum.Remote === detail.groupId))
            ),
        }).pipe(
            shareReplay()
        );
    }

    checkboxChanged(id: number, checked: boolean): void {
        if (checked) {
            this.form.controls.additionalDetailIds.setValue([...this.additionalDetailIds!, id]);
        } else {
            const indexOfSelectedId = this.additionalDetailIds?.indexOf(id);
            this.form.controls.additionalDetailIds.setValue(this.additionalDetailIds?.filter(detailId => detailId !== id) ?? []);
        }
    }

    get additionalDetailIds(): Nullable<number[]> {
        return this.form.controls.additionalDetailIds.value;
    }
}
