import { ComponentFixture, TestBed } from '@angular/core/testing';
import { jest } from '@jest/globals';
import { PostPage } from './post-page';
import { OrderBy, PostSortField } from '../../model/post.types';
import { PostPageStore } from '../../model/post.store';

describe('PostPage', () => {
  let component: PostPage;
  let fixture: ComponentFixture<PostPage>;
  const mockStore: Partial<Record<keyof PostPageStore, unknown>> = {
    filtersForm: () => ({ title: '', content: '', createdAfter: null }),
    items: () => [],
    pageData: () => null,
    loading: () => false,
    error: () => null,
    query: () => ({
      pageIndex: 1,
      pageSize: 10,
      searchTerm: '',
      sort: [{ field: 'CreatedAt' as PostSortField, orderBy: 'Desc' as OrderBy }],
    }),
    totalPages: () => 0,
    totalCount: () => 0,
    sortField: () => 'CreatedAt' as PostSortField,
    sortOrder: () => 'Desc' as OrderBy,
    updateSearchTerm: jest.fn(),
    changeSort: jest.fn(),
    changeOrder: jest.fn(),
    changePage: jest.fn(),
    changePageSize: jest.fn(),
    setFilterTitle: jest.fn(),
    setFilterContent: jest.fn(),
    setFilterCreatedAfter: jest.fn(),
    resetFilters: jest.fn(),
    reload: jest.fn(),
  };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PostPage],
      providers: [{ provide: PostPageStore, useValue: mockStore }],
    })
      .overrideComponent(PostPage, {
        set: {
          imports: [],
          template: '<div>stub</div>',
        },
      })
      .compileComponents();

    fixture = TestBed.createComponent(PostPage);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
