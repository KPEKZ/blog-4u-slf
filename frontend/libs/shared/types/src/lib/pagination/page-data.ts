export interface PageDataBase {
  pageIndex: number;
  totalPages: number;
  totalCount: number;
  hasPreviousPage: boolean;
  hasNextPage: boolean;
}

export type PageData = Readonly<PageDataBase>;
