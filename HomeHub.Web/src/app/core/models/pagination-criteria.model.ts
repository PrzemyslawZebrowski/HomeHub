export type PaginationCriteria = {
    pageSize: number;
    pageNumber: number;
    orderBy?: string;
};

export type Page<T> = {
    items: T[];
    pageSize: number;
    pageNumber: number;
    totalCount: number;
};
