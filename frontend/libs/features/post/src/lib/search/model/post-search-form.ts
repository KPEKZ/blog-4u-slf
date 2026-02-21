import { form } from '@angular/forms/signals';
import { Injectable, signal } from '@angular/core';
import { PostQuery } from './post-query';

@Injectable()
export class PostSearchForm {
  private readonly searchQueryModel = signal<PostQuery>({
    pageIndex: 1,
    pageSize: 5,
    searchTerm: '',
    sort: [],
    filters: [],
  });

  public readonly searchQueryForm = form(this.searchQueryModel);
}
