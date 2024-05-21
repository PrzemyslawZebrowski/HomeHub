import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

import { AnnouncementForm } from '../models/announcements/announcement-form.model';
import {
    Announcement,
    AnnouncementAdminPaginationCriteria,
    AnnouncementForAdminPreview,
    AnnouncementProfilePaginationCriteria
} from '../models/announcements/announcement.model';
import { MainAnnouncement } from '../models/announcements/main-announcement.model';
import { ProfileShortAnnouncement } from '../models/announcements/profile-short-announcement.model';
import { SearchAnnouncement, SearchAnnouncementPaginationCriteria } from '../models/announcements/search-announcement.model';
import { Page, PaginationCriteria } from '../models/pagination-criteria.model';

@Injectable({
    providedIn: 'root'
})
export class AnnouncementService {

    constructor(private _http: HttpClient) { }

    getSearchAnnouncements(criteria: SearchAnnouncementPaginationCriteria): Observable<Page<SearchAnnouncement>> {
        return this._http.get<Page<SearchAnnouncement>>(`${environment.apiUrl}/announcements`, {
            params: criteria
        });
    }

    getLatestAnnouncements(count: number): Observable<SearchAnnouncement[]> {
        return this.getSearchAnnouncements({ pageSize: count, pageNumber: 1, orderBy: "CreatedOn DESC" }).pipe(
            map(p => p.items)
        );
    }

    getRandomAnnouncements(count: number): Observable<SearchAnnouncement[]> {
        return this.getSearchAnnouncements({ pageSize: count, pageNumber: 1, orderBy: "NEWID()" }).pipe(
            map(p => p.items)
        );
    }

    getMainAnnouncement(announcementId: number): Observable<MainAnnouncement> {
        return this._http.get<MainAnnouncement>(`${environment.apiUrl}/announcements/${announcementId}`);
    }

    getProfileAnnouncements(criteria: AnnouncementProfilePaginationCriteria): Observable<Page<ProfileShortAnnouncement>> {
        return this._http.get<Page<ProfileShortAnnouncement>>(`${environment.apiUrl}/profile/announcements`, {
            params: {
                pageSize: criteria.pageSize,
                pageNumber: criteria.pageNumber,
                title: criteria.title,
                statusId: criteria.statusId!
            }
        });
    }

    getAnnouncement(announcementId: number): Observable<Announcement> {
        return this._http.get<Announcement>(`${environment.apiUrl}/profile/announcements/${announcementId}`);
    }

    addAnnouncement(announcement: AnnouncementForm): Observable<void> {
        const data = this.getAnnouncementFormData(announcement);
        return this._http.post<void>(`${environment.apiUrl}/profile/announcements`, data);
    }

    updateAnnouncements(announcementId: number, announcement: AnnouncementForm): Observable<void> {
        const data = this.getAnnouncementFormData(announcement);
        return this._http.put<void>(`${environment.apiUrl}/profile/announcements/${announcementId}`, data);
    }

    closeAnnouncement(announcementId: number): Observable<void> {
        return this._http.put<void>(`${environment.apiUrl}/profile/announcements/${announcementId}/close`, {
            announcementId: announcementId
        });
    }

    refuseAnnouncement(announcementId: number): Observable<void> {
        return this._http.put<void>(`${environment.apiUrl}/admin/announcements/${announcementId}/refuse`, {
            announcementId: announcementId
        });
    }

    approveAnnouncement(announcementId: number): Observable<void> {
        return this._http.put<void>(`${environment.apiUrl}/admin/announcements/${announcementId}/approve`, {
            announcementId: announcementId
        });
    }

    getAdminAnnouncements(criteria: AnnouncementAdminPaginationCriteria): Observable<Page<ProfileShortAnnouncement>> {
        return this._http.get<Page<ProfileShortAnnouncement>>(`${environment.apiUrl}/admin/announcements`, {
            params: criteria
        });
    }

    getAnnouncementForAdminPreview(announcementId: number): Observable<AnnouncementForAdminPreview> {
        return this._http.get<AnnouncementForAdminPreview>(`${environment.apiUrl}/admin/announcements/${announcementId}`);
    }

    addFavoriteAnnouncement(announcementId: number): Observable<void> {
        return this._http.post<void>(`${environment.apiUrl}/profile/announcements/favorite/${announcementId}`, {
            announcementId: announcementId
        });
    }

    removeFavoriteAnnouncement(announcementId: number): Observable<void> {
        return this._http.delete<void>(`${environment.apiUrl}/profile/announcements/favorite/${announcementId}`);
    }

    getFavoriteAnnouncements(criteria: PaginationCriteria): Observable<Page<SearchAnnouncement>> {
        return this._http.get<Page<SearchAnnouncement>>(`${environment.apiUrl}/profile/announcements/favorite`, {
            params: criteria
        });
    }

    getAnnouncementsByUser(criteria: PaginationCriteria, userId: string): Observable<Page<SearchAnnouncement>> {
        return this._http.get<Page<SearchAnnouncement>>(`${environment.apiUrl}/users/${userId}/announcements`, {
            params: criteria
        });
    }

    private getAnnouncementFormData(announcement: AnnouncementForm): FormData {
        const formData = new FormData();

        // Append data from AnnouncementSubjectAndType
        formData.append('subjectType.subjectTypeId', announcement.subjectType.subjectTypeId?.toString() || '');
        formData.append('subjectType.typeId', announcement.subjectType.typeId?.toString() || '');

        // Append data from AnnouncementBasicInformation
        formData.append('basicInformation.title', announcement.basicInformation.title || '');
        formData.append('basicInformation.priceAmount', announcement.basicInformation.priceAmount?.toString() || '');
        formData.append('basicInformation.priceCurrency', announcement.basicInformation.priceCurrency || '');
        formData.append('basicInformation.advertiserTypeId', announcement.basicInformation.advertiserTypeId?.toString() || '');
        formData.append('basicInformation.marketTypeId', announcement.basicInformation.marketTypeId?.toString() || '');
        formData.append('basicInformation.area', announcement.basicInformation.area?.toString() || '');
        formData.append('basicInformation.numberOfRooms', announcement.basicInformation.numberOfRooms?.toString() || '');

        // Append data from AnnouncementDetails
        formData.append('details.description', announcement.details.description || '');
        formData.append('details.developmentTypeId', announcement.details.developmentTypeId?.toString() || '');
        formData.append('details.floorId', announcement.details.floorId?.toString() || '');
        formData.append('details.numberOfFloors', announcement.details.numberOfFloors?.toString() || '');
        formData.append('details.buildingMaterialId', announcement.details.buildingMaterialId?.toString() || '');
        formData.append('details.windowTypeId', announcement.details.windowTypeId?.toString() || '');
        formData.append('details.heatingTypeId', announcement.details.heatingTypeId?.toString() || '');
        formData.append('details.buildYear', announcement.details.buildYear?.toString() || '');
        formData.append('details.buildingFinishConditionId', announcement.details.buildingFinishConditionId?.toString() || '');
        formData.append('details.ownershipFormId', announcement.details.ownershipFormId?.toString() || '');

        formData.append('details.availableFrom', this.getAvailableFromISO(announcement.details.availableFrom) || '');
        announcement.details.additionalDetailIds?.forEach((detailId, index) => {
            formData.append(`details.additionalDetailIds[${index}]`, detailId?.toString() || '');
        });

        // Append data from AnnouncementMultimedia
        formData.append('multimedia.videoUrl', announcement.multimedia.videoUrl || '');
        formData.append('multimedia.virtualWalkUrl', announcement.multimedia.videoUrl || '');

        // Append data from AnnouncementPhoto
        announcement.multimedia.photos.forEach((photo, index) => {
            formData.append(`multimedia.photos[${index}].id`, photo.id?.toString() || '');
            formData.append(`multimedia.photos[${index}].file`, photo.file || '');
            formData.append(`multimedia.photos[${index}].url`, photo.url || '');
            formData.append(`multimedia.photos[${index}].isMainPhoto`, photo.isMainPhoto?.toString() || '');
        });

        // Append data from AnnouncementLocalization
        formData.append('localization.address', announcement.localization.address || '');
        formData.append('localization.latitude', announcement.localization.latitude?.toString().replace('.', ',') || '');
        formData.append('localization.longitude', announcement.localization.longitude?.toString().replace('.', ',') || '');

        // Append data from AnnouncementContactDetails
        formData.append('contactDetails.advertiserName', announcement.contactDetails.advertiserName || '');
        formData.append('contactDetails.advertiserEmail', announcement.contactDetails.advertiserEmail || '');
        formData.append('contactDetails.advertiserPhoneNumber', announcement.contactDetails.advertiserPhoneNumber || '');

        return formData;
    }

    private getAvailableFromISO(availableFromArg: Nullable<Date>): string | undefined {
        const availableFrom = availableFromArg;

        return "string" === typeof (availableFrom)
            ? new Date(availableFrom).toISOString()
            : availableFromArg?.toISOString();
    }
}
