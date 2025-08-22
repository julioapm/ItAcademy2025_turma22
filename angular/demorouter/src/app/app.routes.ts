import { Routes } from '@angular/router';
import { Home } from './home/home';
import { User } from './user/user';
import { Pagenotfound } from './pagenotfound/pagenotfound';

export const routes: Routes = [
    {
        path: 'home',
        component: Home,
        title: 'Home Page'
    },
    {
        path: 'user',
        component: User,
        title: 'User Page'
    },
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: '**',
        component: Pagenotfound,
        title: '404'
    }
];
