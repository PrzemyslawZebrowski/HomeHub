import { PaginationCriteria } from '../pagination-criteria.model';

export type UserPaginationCriteria = PaginationCriteria;

export type User = {
    id: string;
    email: string;
    roleId: number;
    roleName: string;
};

export type UserDetails = {
    contactEmail: string;
    name: string;
    phoneNumber: string;
    advertiserTypeId: number;
    advertiserTypeName: string;
};
