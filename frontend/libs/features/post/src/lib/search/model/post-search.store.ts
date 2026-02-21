import { PostService as PostApiService } from '@blog-4u-slf/entities/post';
import { computed, inject, InjectionToken } from '@angular/core';
import type { PostSearchState } from './post-search.state';
import {
  patchState,
  signalStore,
  withComputed,
  withMethods,
  withProps,
  withState,
} from '@ngrx/signals';
import { rxMethod } from '@ngrx/signals/rxjs-interop';
import { debounceTime, pipe, switchMap, tap } from 'rxjs';
import { PostQuery } from './post-query';
import { tapResponse } from '@ngrx/operators';

export const POST_SEARCH_STATE = new InjectionToken<PostSearchState>(
  'BookSearchState',
  { factory: () => postSearchInitialState },
);

export const postSearchInitialState: PostSearchState = {
  query: {
    pageIndex: 1,
    pageSize: 5,
    searchTerm: '',
    sort: [],
    filters: [],
  },
  items: [],
  pageData: null,
  loading: false,
  error: null,
};

export const PostSearchStore = signalStore(
  withState(() => inject(POST_SEARCH_STATE)),
  withProps(() => ({
    _postsApi: inject(PostApiService),
  })),
  withComputed((store) => ({
    totalPages: computed(() => store.pageData()?.totalPages ?? 0),
    totalCount: computed(() => store.pageData()?.totalCount ?? 0),
  })),
  withMethods((store) => ({
    setPage: (index: number) => {
      patchState(store, (state) => ({
        query: { ...state.query, pageIndex: index },
      }));
    },

    patchQuery(partialQuery: Partial<PostQuery>) {
      patchState(store, (state) => ({
        query: { ...state.query, ...partialQuery },
      }));
    },

    load: rxMethod<PostQuery>(
      pipe(
        tap(() => patchState(store, { loading: true, error: null })),
        debounceTime(300),
        switchMap((query) =>
          store._postsApi
            .apiV1PostsPageGet(
              query.pageIndex,
              query.pageSize,
              query.searchTerm,
            )
            .pipe(
              tapResponse({
                next: (res) =>
                  patchState(store, {
                    items: res.items,
                    pageData: res.pageData,
                  }),
                error: (error) => patchState(store, { error: error as Error }),
                finalize: () => patchState(store, { loading: false }),
              }),
            ),
        ),
      ),
    ),
  })),
);
