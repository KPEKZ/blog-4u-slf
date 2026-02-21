import { FilterParameter, SortParameter } from '@blog-4u-slf/shared-types';
import { PostSortField } from './post-sort-field';
import { PostFilterField } from './post-filter-field';

export interface PostQuery {
  pageIndex: number;
  pageSize: number;
  searchTerm: string;
  sort: SortParameter<PostSortField>[];
  filters: FilterParameter<PostFilterField>[];
}
