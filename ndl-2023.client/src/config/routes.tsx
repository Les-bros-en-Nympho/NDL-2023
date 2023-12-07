import { Root } from '../layouts/Root';
import { Home } from '../pages/Home';
import { Navigate, RouteObject } from 'react-router-dom';

export const routes = [
    {
        path: '/:locale',
        element: <Root />,
        children: [
            {
                path: '', // Le chemin vide ici correspond à '/:locale', donc cela pointe vers '/:locale'
                element: <Home />
            },
            {
                path: 'training', // Chemin relatif par rapport à '/:locale'
                element: "" // Assurez-vous de remplir l'élément correspondant
            },
            {
                path: 'account', // Chemin relatif par rapport à '/:locale'
                element: "" // Assurez-vous de remplir l'élément correspondant
            },
            {
                path: 'help', // Chemin relatif par rapport à '/:locale'
                element: "" // Assurez-vous de remplir l'élément correspondant
            },
            {
                path: 'privacy', // Chemin relatif par rapport à '/:locale'
                element: "" // Assurez-vous de remplir l'élément correspondant
            },
            {
                path: 'login', // Chemin relatif par rapport à '/:locale'
                element: "" // Assurez-vous de remplir l'élément correspondant
            }
        ]
    },
    {
        path: '*', // Route par défaut pour les chemins inconnus
        element: <Navigate to="/404" />
    }
] as RouteObject[];
