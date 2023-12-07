import { Header } from '../components/header/Header'
import { Footer } from '../components/footer/Footer'

import { Outlet } from 'react-router-dom'

export const Root = () => {
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