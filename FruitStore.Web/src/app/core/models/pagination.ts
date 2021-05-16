export interface Pagination<T> {
  items: T[];
  pageCount: number;
  totalItemCount: number;
  pageSize: number;
  currentPage: number;
}
