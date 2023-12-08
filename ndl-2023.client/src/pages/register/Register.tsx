import i18n from '../../i18n';
import '../../styles/register/register.scss'
import { Fade, Zoom } from 'react-awesome-reveal';
import { Link } from 'react-router-dom';
import { API } from '../../services/API';
import toast, { Toaster } from 'react-hot-toast';
import { useState } from 'react';

export const Register = () => {
    const { t } = i18n;
    const currentLocale = i18n.language;
    const api = API.getInstance();
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [cpassword, setCPassword] = useState('');
    const [password, setPassword] = useState('');

    const register = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        if (password !== cpassword) {
            toast.error(t('register_passwords_match'));
            return;
        }
        try {
            api.post('/Auth/Register', {
                username,
                email,
                password
            }).then((response) => {
                if (response?.message) {
                    toast.error(response.message);
                } else {
                    toast.success(t('register_success'));
                }
            });
        } catch (error) {
            toast.error(t('register_error'));
        }
    }

    return (
        <section id="register">
            <Zoom duration={200}>
                <fieldset>
                    <legend>{t('register_title')}</legend>

                    <form method="post" onSubmit={register}>
                        <Fade duration={85} cascade direction='up'>

                            <label htmlFor="name">{t('register_username')}</label>
                            <input value={username} onChange={(event) => {
                                setUsername(event.target.value);
                            }}
                            type="text" name="name" id="name" placeholder={t('register_username_placeholder')} />

                            <label htmlFor="email">{t('register_email')}</label>
                            <input value={email} onChange={(event) => {
                                setEmail(event.target.value);
                            }}
                            type="email" name="email" id="email" placeholder={t('register_email_placeholder')} />

                            <label htmlFor="password">{t('register_password')}</label>
                            <input value={password} onChange={(event) => {
                                setPassword(event.target.value);
                            }}
                            type="password" name="password" id="password" placeholder={t('register_password_placeholder')} />

                            <label htmlFor="cpassword">{t('register_password_confirm')}</label>
                            <input value={cpassword} onChange={(event) => {
                                setCPassword(event.target.value);
                            }}
                            type="password" name="cpassword" id="cpassword" placeholder={t('register_password_confirm_placeholder')} />

                            <button type="submit">{t('register_submit')}</button>
                        </Fade>
                    </form>
                    <p>
                        {t('register_login')} <Link to={`/${currentLocale}/login`}>{t('register_login_link')}</Link>
                    </p>
                </fieldset>
            </Zoom>
            <Toaster position='bottom-center'/>
        </section>
    )
};