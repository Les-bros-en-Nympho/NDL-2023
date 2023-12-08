import i18n from '../../i18n';
import '../../styles/header/header.scss';
import { Link } from 'react-router-dom';
import { useState, useEffect } from 'react';
import { debounce } from '../../utils/debouce';
import { Fade } from 'react-awesome-reveal';
import { DISPATCHER } from '../../services/DISPATCHER';

export const Header = () => {
    const { t } = i18n

    const [isScrolled, setIsScrolled] = useState<boolean>(window.scrollY > 30);
    const [isToggled, setIsToggled] = useState<boolean>(false);
    const mobileBreakpoint = 1450;
    const currentLocale = i18n.language;
    const [isLogged, setIsLogged] = useState<boolean>(false);

    const getNextLanguage = () => {
        const index = i18n.languages.indexOf(i18n.language);
        return i18n.languages[(index + 1) % i18n.languages.length];
    }

    const changeLocal = () => {
        handleToggle();
        window.location.href = `/${getNextLanguage()}`;
    }
    
    const handleToggle = () => {
        setIsToggled(!isToggled);
    }

    const toggleLogin = () => {
        setIsLogged(!isLogged);
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
        DISPATCHER.on('login', toggleLogin);
        return () => {
            window.removeEventListener('scroll', handleScroll)
            window.removeEventListener('resize', handleResize as EventListener)
            DISPATCHER.remove('login', toggleLogin);
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
                <Link to={`/${currentLocale}`} onClick={handleToggle}><i className="fa-solid fa-house"></i> {t('header_home')} </Link>
                <Link to={`/${currentLocale}/quizz`} onClick={handleToggle}><i className="fa-solid fa-circle-question"></i> {t('header_quizz')} </Link>
                <Link to={`/${currentLocale}/leaderboard`} onClick={handleToggle}><i className="fa-solid fa-trophy"></i>{t('header_leaderboard')}</Link>
                {!isLogged && <Link to={`/${currentLocale}/login`} onClick={handleToggle}><i className="fa-solid fa-right-to-bracket"></i>{t('header_login')}</Link>}
                {isLogged && <button onClick={() => {
                    localStorage.removeItem('token');
                    setIsLogged(false);
                    handleToggle();
                }}><i className="fa-solid fa-right-to-bracket"></i>{t('header_logout')}</button>}
                <button onClick={changeLocal}><i className="fa-solid fa-globe"></i>{getNextLanguage()}</button>
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