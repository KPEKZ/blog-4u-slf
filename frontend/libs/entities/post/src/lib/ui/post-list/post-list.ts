import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { Post } from '../../model';
import { PostCard } from '../post-card/post-card';

@Component({
  selector: 'pe-post-list',
  imports: [PostCard],
  templateUrl: './post-list.html',
  styleUrl: './post-list.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PostList {
  public readonly posts = input.required<Post[]>();
}
