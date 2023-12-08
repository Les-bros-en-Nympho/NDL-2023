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
                    <legend>{t('register_title')}</legend>

                    <form method="post">
                        <Fade duration={100} cascade direction='up'>

                            <label htmlFor="name">{t('register_username')}</label>
                            <input type="text" name="name" id="name" placeholder={t('register_username_placeholder')} />

                            <label htmlFor="email">{t('register_email')}</label>
                            <input type="email" name="email" id="email" placeholder={t('register_email_placeholder')} />

                            <label htmlFor="password">{t('register_password')}</label>
                            <input type="password" name="password" id="password" placeholder={t('register_password_placeholder')} />

                            <label htmlFor="cpassword">{t('register_password_confirm')}</label>
                            <input type="password" name="cpassword" id="cpassword" placeholder={t('register_password_confirm_placeholder')} />

                            <button type="submit">{t('register_submit')}</button>
                        </Fade>
                    </form>
                    <p>
                        {t('register_login')} <Link to={`/${currentLocale}/login`}>{t('register_login_link')}</Link>
                    </p>
                </fieldset>
            </Fade>
        </section>
    )
};