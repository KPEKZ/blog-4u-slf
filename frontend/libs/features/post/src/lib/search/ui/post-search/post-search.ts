import {
  ChangeDetectionStrategy,
  Component,
  effect,
  inject,
} from '@angular/core';
import { FormField } from '@angular/forms/signals';
import { TuiTextfield } from '@taiga-ui/core/components/textfield';
import { PostSearchStore } from '../../model';
import { PostSearchForm } from '../../model/post-search-form';

@Component({
  selector: 'lib-post-search',
  imports: [TuiTextfield, FormField],
  providers: [PostSearchForm],
  templateUrl: './post-search.html',
  styleUrl: './post-search.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PostSearch {
  private readonly _postSearchForm = inject(PostSearchForm);

  protected readonly store = inject(PostSearchStore);

  public readonly form = this._postSearchForm.searchQueryForm;

  constructor() {
    effect(() => {
      const searchTerm = this.form.searchTerm().value();

      this.store.patchQuery({ searchTerm, pageIndex: 1 });
    });
  }
}
