import { PostSearch, PostSearchStore } from '@blog-4u-slf/features/post';
import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  TuiButton,
  TuiLoader,
  TuiDataList,
  TuiSelect,
  TuiTextfield,
} from '@taiga-ui/core';
import { TuiPagination } from '@taiga-ui/kit';
import { PostList } from '@blog-4u-slf/entities/post';

@Component({
  selector: 'lib-post-page',
  imports: [
    FormsModule,
    TuiButton,
    TuiDataList,
    TuiSelect,
    TuiLoader,
    TuiPagination,
    FormsModule,
    ReactiveFormsModule,
    TuiTextfield,
    PostList,
    PostSearch,
  ],
  providers: [PostSearchStore],
  templateUrl: './post-page.html',
  styleUrl: './post-page.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PostPage {
  public readonly store = inject(PostSearchStore);

  constructor() {
    this.store.load(this.store.query);
  }

  public refresh() {
    this.store.load(this.store.query);
  }
}
