import { ChangeDetectionStrategy, Component } from '@angular/core';
import {TuiBlockStatus} from '@taiga-ui/layout';

@Component({
  selector: 'lib-not-found',
  imports: [TuiBlockStatus],
  templateUrl: './not-found.html',
  styleUrl: './not-found.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NotFound {}
