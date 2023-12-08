import i18n from '../../i18n';
import '../../styles/login/login.scss'
import { Fade, Zoom } from 'react-awesome-reveal';
import { Link } from 'react-router-dom';
import {API} from "../../services/API.ts";
import { useState } from 'react';
import toast, { Toaster } from 'react-hot-toast';
import { useNavigate } from 'react-router';

export const Login = () => {
    const { t } = i18n;
    const currentLocale = i18n.language;
    const navigate = useNavigate();
    const api = API.getInstance();
    const [loading, setLoading] = useState(false);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const login = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        setLoading(true);
        try {
            api.post('/Auth/Login', {
                email,
                password
            }).then((response) => {
                if (response?.message) {
                    toast.error(response.message);
                } else {
                    toast.success(t('register_success'));
                    navigate(`/${currentLocale}/`);
                }
            });
            setLoading(false);
        } catch (error) {
            // toast.error(t('register_error'));
            setLoading(false);
        }
    }
    
    return (
        <section id="login">
            <Zoom duration={200}>
                <fieldset>
                    <legend>{t('login_title')}</legend>

                    <form method="post" onSubmit={login}>
                        <Fade duration={100} cascade direction='up'>
                            <label htmlFor="email">{t('login_email')}</label>
                            <input value={email} onChange={(event) => {
                                setEmail(event.target.value);
                            }}  type="email" name="email" id="email" placeholder={t('login_email_placeholder')} />

                            <label htmlFor="password">{t('login_password')}</label>
                            <input value={password} onChange={(event) => {
                                setPassword(event.target.value);
                            }} type="password" name="password" id="password" placeholder={t('login_password_placeholder')} />

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