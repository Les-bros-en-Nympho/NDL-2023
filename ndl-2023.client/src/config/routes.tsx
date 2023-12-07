import { Root } from '../layouts/Root';
import { Home } from '../pages/Home';

export const routes = [
    {
        path: '/',
        element: <Root />,
        children: [
            {
                path: '/',
                element: <Home />
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