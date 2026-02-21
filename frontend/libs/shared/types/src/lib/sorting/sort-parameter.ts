import { OrderBy } from "../pagination";

export interface SortParameter<TField> {
  field: TField;
  orderBy: OrderBy;
  priority?: number;
}
