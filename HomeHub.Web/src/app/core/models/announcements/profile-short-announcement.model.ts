import { Currency } from '../currency.model';

export type ProfileShortAnnouncement = {
    id: number;
    photoUrl: string;
    title: string;
    priceAmount: number;
    priceCurrency: Currency;
    area: number;
    address: string;
    statusId: number;
    statusName: string;
    createdOn: Date;
};
