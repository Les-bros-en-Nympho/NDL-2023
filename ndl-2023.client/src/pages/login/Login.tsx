import i18n from '../../i18n';
import '../../styles/login/login.scss'

export const Login = () => {
    const { t } = i18n;

    return (
        <section id="login">
            <fieldset>
                <legend>{t('login_title')}</legend>

                <form method="post">
                    <label htmlFor="email">{t('login_email')}</label>
                    <input type="email" name="email" id="email" placeholder={t('login_email_placeholder')} />

                    <label htmlFor="password">{t('login_password')}</label>
                    <input type="password" name="password" id="password" placeholder={t('login_password_placeholder')} />

                    <button type="submit">{t('login_submit')}</button>
                </form>
            </fieldset>
        </section>
    )
};