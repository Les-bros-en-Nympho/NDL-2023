import { Root } from '../layouts/Root';
import { Home } from '../pages/Home';
import { Navigate, RouteObject } from 'react-router-dom';

export const routes = [
    {
        path: '/',
        children: [
            {
                path: '/:locale',
                element: <Root />,
                children: [
                    {
                        path: '',
                        element: <Home />
                    },
                    {
                        path: 'training',
                        element: <Home />
                    },
                    {
                        path: 'account',
                        element: <Home />
                    },
                    {
                        path: 'help',
                        element: <Home />
                    },
                    {
                        path: 'privacy',
                        element: <Home />
                    },
                    {
                        path: 'login',
                        element: <Home />
                    }
                ]
            },
            {
                path: '/',
                element: <Navigate to="/en" />
            }
        ]
    }
] as RouteObject[];