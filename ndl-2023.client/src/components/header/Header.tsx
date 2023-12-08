import i18n from '../../i18n';
import '../../styles/header/header.scss';
import { Link } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { debounce } from '../../utils/debouce';
import { Fade } from 'react-awesome-reveal';

export const Header = () => {
    const { t } = i18n

    const [isScrolled, setIsScrolled] = useState<boolean>(window.scrollY > 30);
    const [isToggled, setIsToggled] = useState<boolean>(false);
    const mobileBreakpoint = 1450;
    
    const handleToggle = () => {
        setIsToggled(!isToggled);
    }

    const handleScroll = () => {
        if (window.scrollY > 30) setIsScrolled(true);
        else setIsScrolled(false);
    }

    const handleResize = debounce(() => {
            if (window.innerWidth > mobileBreakpoint) setIsToggled(false);
        }, 300);

    useEffect(() => {
        window.addEventListener('scroll', handleScroll as EventListener)
        window.addEventListener('resize', handleResize as EventListener)
        return () => {
            window.removeEventListener('scroll', handleScroll)
            window.removeEventListener('resize', handleResize as EventListener)
        }
    })
    
    return (
        <header className={`${isScrolled ? 'scrolled' : ''} ${isToggled ? 'toggled' : ''}`}>
            <div className="title">
                <Link to="">
                    <img src="/images/logo.png" alt="Logo" />
                    <h1>{ t('title') }</h1>
                </Link>
            </div>
            <nav>
            <Fade cascade direction='up' duration={200}>
                <Link to=""><i className="fa-solid fa-house"></i> {t('header_home')} </Link>
                <Link to="quizz"><i className="fa-solid fa-circle-question"></i> {t('header_quizz')} </Link>
                <Link to="news"><i className="fa-solid fa-newspaper"></i> {t('header_news')} </Link>
                <Link to="leaderboard"><i className="fa-solid fa-trophy"></i>{t('header_leaderboard')}</Link>
                <Link to="login"><i className="fa-solid fa-right-to-bracket"></i>{t('header_login')}</Link>
            </Fade>
            </nav>
            <div className='toggle' onClick={handleToggle}>
                <span></span>
                <span></span>
                <span></span>
            </div>
        </header>
    );
}