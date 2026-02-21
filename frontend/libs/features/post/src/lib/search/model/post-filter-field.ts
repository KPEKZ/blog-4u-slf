import { Post } from "@blog-4u-slf/entities/post";

export type PostFilterField = Capitalize<keyof Omit<Post, 'id' | 'slug'>>;
