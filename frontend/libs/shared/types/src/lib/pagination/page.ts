import type { PageData } from "./page-data";

export interface Page<TItem extends object> {
  readonly items: TItem[];
  readonly pageData: PageData;
}
