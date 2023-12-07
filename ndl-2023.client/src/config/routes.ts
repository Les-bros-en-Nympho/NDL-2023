import { Root } from '../layouts/Root';

export const routes = [
    {
        path: '/',
        element: Root,
        children: [
            {
                path: '/',
                element: ""
            },
            {
                path: '/training',
                element: ""
            },
            {
                path: '/account',
                element: ""
            },
            {
                path: '/help',
                element: ""
            },
            {
                path: '/privacy',
                element: ""
            },
            {
                path: '/login',
                element: ""
            }
        ]
    },
];