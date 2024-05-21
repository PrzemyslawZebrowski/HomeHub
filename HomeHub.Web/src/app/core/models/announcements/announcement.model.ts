import { PaginationCriteria } from '../pagination-criteria.model';
import {
    AnnouncementBasicInformation,
    AnnouncementContactDetails,
    AnnouncementDetails,
    AnnouncementLocalization,
    AnnouncementMultimedia,
    AnnouncementSubjectAndType
} from './announcement-form.model';

export type Announcement = AnnouncementSubjectAndType & AnnouncementBasicInformation & AnnouncementDetails & AnnouncementLocalization & AnnouncementContactDetails & AnnouncementMultimedia;

export type AnnouncementProfileFilters = {
    title: string;
    statusId: Nullable<number>;
};

export type AnnouncementAdminFilters = {
    statusId: number
};

export type AnnouncementAdminPaginationCriteria = PaginationCriteria & AnnouncementAdminFilters;

export type AnnouncementProfilePaginationCriteria = PaginationCriteria & AnnouncementProfileFilters;

export type AnnouncementForAdminPreview = Announcement & {
    statusId: number;
    statusName: string;
};
