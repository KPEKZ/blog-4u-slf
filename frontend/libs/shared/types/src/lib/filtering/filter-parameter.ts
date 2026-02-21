import { FilterOperator } from "./filter-operator";

export interface FilterParameter<TField> {
  field: TField;
  operator: FilterOperator;
  value: string;
}
