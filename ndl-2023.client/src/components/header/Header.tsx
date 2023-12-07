import i18n from '../../i18n';
import '../../styles/header/header.scss';

export const Header = () => {
    const { t } = i18n
    
    return (
        <header>
            <div className="title">
                <img src="/images/logo.png" alt="Logo" />
                <h1>{ t('title') }</h1>
            </div>
            <nav>
                <a href="">Home</a>
                <a href="">Quizz</a>
                <a href="">News</a>
                <a href="">Leader board</a>
                <a href="">Login</a>
            </nav>
        </header>
    );
}