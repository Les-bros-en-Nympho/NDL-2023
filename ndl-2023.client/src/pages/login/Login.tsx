import i18n from '../../i18n';
import '../../styles/login/login.scss'
import { Fade, Zoom } from 'react-awesome-reveal';
import { Link } from 'react-router-dom';

export const Login = () => {
    const { t } = i18n;
    const currentLocale = i18n.language;

    return (
        <section id="login">
            <Zoom duration={200}>
                <fieldset>
                    <legend>{t('login_title')}</legend>

                    <form method="post">
                        <Fade duration={100} cascade direction='up'>
                            <label htmlFor="email">{t('login_email')}</label>
                            <input type="email" name="email" id="email" placeholder={t('login_email_placeholder')} />

                            <label htmlFor="password">{t('login_password')}</label>
                            <input type="password" name="password" id="password" placeholder={t('login_password_placeholder')} />

                            <button type="submit">{t('login_submit')}</button>
                        </Fade>
                    </form>
                    <p>
                        {t('login_register')} <Link to={`/${currentLocale}/register`}>{t('login_register_link')}</Link>
                    </p>
                </fieldset>
            </Zoom>
        </section>
    )
};