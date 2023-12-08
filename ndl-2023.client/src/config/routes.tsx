import { Root } from '../layouts/Root';
import { Home } from '../pages/home/Home';
import { Navigate, RouteObject } from 'react-router-dom';
import { Login } from '../pages/login/Login';

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
                        element: <Login />
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