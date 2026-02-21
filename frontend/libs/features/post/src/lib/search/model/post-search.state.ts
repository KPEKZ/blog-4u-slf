import { Post } from "@blog-4u-slf/entities/post";
import { PostQuery } from "./post-query";
import { PageData } from "@blog-4u-slf/shared-types";

export interface PostSearchState {
  query: PostQuery;
  items: Post[];
  pageData: PageData | null;
  loading: boolean;
  error: Error | null;
}
