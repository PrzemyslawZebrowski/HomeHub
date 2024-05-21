import { Currency } from '../currency.model';

export type AnnouncementForm = {
    subjectType: AnnouncementSubjectAndType;
    basicInformation: AnnouncementBasicInformation;
    multimedia: AnnouncementMultimedia;
    details: AnnouncementDetails;
    localization: AnnouncementLocalization;
    contactDetails: AnnouncementContactDetails;
};

export type AnnouncementSubjectAndType = {
    subjectTypeId: Nullable<number>;
    typeId: Nullable<number>;
};

export type AnnouncementBasicInformation = {
    title: Nullable<string>;
    priceAmount: Nullable<number>;
    priceCurrency: Nullable<Currency>;
    advertiserTypeId: Nullable<number>;
    marketTypeId: Nullable<number>;
    area: Nullable<number>;
    numberOfRooms: Nullable<number>;
};

export type AnnouncementDetails = {
    description: Nullable<string>;
    developmentTypeId: Nullable<number>;
    floorId: Nullable<number>;
    numberOfFloors: Nullable<number>;
    buildingMaterialId: Nullable<number>;
    windowTypeId: Nullable<number>;
    heatingTypeId: Nullable<number>;
    buildYear: Nullable<number>;
    buildingFinishConditionId: Nullable<number>;
    ownershipFormId: Nullable<number>;
    availableFrom: Nullable<Date>;
    additionalDetailIds: Nullable<number[]>;
};

export type AnnouncementPhoto = {
    id: Nullable<number>;
    file: Nullable<File>;
    url: string;
    isMainPhoto: Nullable<boolean>;
};

export type AnnouncementMultimedia = {
    videoUrl: Nullable<string>;
    virtualWalkUrl: Nullable<string>;
    photos: AnnouncementPhoto[];
};

export type AnnouncementLocalization = {
    address: Nullable<string>;
    latitude: Nullable<number>;
    longitude: Nullable<number>;
};

export type AnnouncementContactDetails = {
    advertiserName: Nullable<string>;
    advertiserEmail: Nullable<string>;
    advertiserPhoneNumber: Nullable<string>;
};
