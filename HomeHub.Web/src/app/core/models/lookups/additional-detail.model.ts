import { Lookup } from './lookup.model';

export type AdditionalDetail = {
    groupId: number;
    groupName: string;
} & Lookup;
