import { Post } from '@blog-4u-slf/entities/post';

export type PostSortField = Capitalize<keyof Pick<Post, 'title' | 'createdAt' | 'updatedAt'>>;
