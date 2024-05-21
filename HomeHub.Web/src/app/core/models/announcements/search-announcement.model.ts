import { Currency } from '../currency.model';
import { PaginationCriteria } from '../pagination-criteria.model';

export type SearchAnnouncement = {
    id: number;
    photoUrl: string;
    title: string;
    priceAmount: number;
    priceCurrency: Currency;
    area: number;
    numberOfRooms: number;
    address: string;
    advertiserTypeId: number;
    advertiserTypeName: string;
    isFavorite: boolean;
};

export type SearchAnnouncementFilters = {
    address?: string;
    radiusDistance?: number;
    longitude?: number;
    latitude?: number;
    subjectTypeId?: number;
    announcementTypeId?: number;
    advertiserTypeId?: number;
    marketTypeId?: number;
    floorId?: number;
    developmentTypeId?: number;
    buildingMaterialId?: number;
    buildingFinishConditionId?: number;
    priceAmountMin?: number;
    priceAmountMax?: number;
    areaMin?: number;
    areaMax?: number;
    numberOfRoomsMin?: number;
    numberOfRoomsMax?: number;
    numberOfFloorsMin?: number;
    numberOfFloorsMax?: number;
    buildYearMin?: number;
    buildYearMax?: number;
};

export type SearchAnnouncementPaginationCriteria = SearchAnnouncementFilters & PaginationCriteria;
