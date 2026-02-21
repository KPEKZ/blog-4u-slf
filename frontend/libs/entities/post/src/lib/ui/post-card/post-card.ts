import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { TuiTitle, TuiAppearance } from '@taiga-ui/core/directives';
import { TuiCardLarge, TuiHeader } from '@taiga-ui/layout';
import { Post } from '../../model/post';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'pe-post-card',
  imports: [TuiCardLarge, TuiHeader, TuiTitle, TuiAppearance, RouterLink],
  templateUrl: './post-card.html',
  styleUrl: './post-card.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class PostCard {
  public readonly post = input.required<Post>();
}
