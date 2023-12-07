import { Header } from '../components/header/Header'
import { Footer } from '../components/footer/Footer'
import { Outlet } from 'react-router-dom'
import { useParams } from 'react-router';
import i18n from '../i18n'
import { Navigate } from 'react-router-dom';

export const Root = () => {
    const { locale } = useParams();
    // Check if language is supported
    if (!i18n.languages.includes(locale as string)) return (<Navigate to="/en" />)
    // Set language
    i18n.changeLanguage(locale as string);
    return (
        <main>
            <Header />
            <section>
                <Outlet />
            </section>
            <Footer />
        </main>
    )
}