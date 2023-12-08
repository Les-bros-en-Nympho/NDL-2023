import i18n from '../../i18n';
import '../../styles/register/register.scss'
import { Fade } from 'react-awesome-reveal';
import { Link } from 'react-router-dom';

export const Register = () => {
    const { t } = i18n;
    const currentLocale = i18n.language;

    return (
        <section id="register">
            <Fade duration={200}>
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
                        {t('login_register')} <Link to={`/${currentLocale}/login`}>{t('login_register_link')}</Link>
                    </p>
                </fieldset>
            </Fade>
        </section>
    )
};