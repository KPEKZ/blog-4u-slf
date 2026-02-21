import { Route } from '@angular/router';

export const appRoutes: Route[] = [
  {
    path: '',
    loadComponent: () =>
      import('@blog-4u-slf/page/home').then((m) => m.HomePage),
  },
  {
    path: 'posts',
    loadComponent: () =>
      import('@blog-4u-slf/page/posts').then((m) => m.PostPage),
  },
  {
    path: 'not-found',
    loadComponent: () => import('@blog-4u-slf/page/not-found').then((m) => m.NotFound),
  },
  {
    path: '**',
    redirectTo: 'not-found',
    pathMatch: 'full',
  },
];
