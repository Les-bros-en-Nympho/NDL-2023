import {Fade} from "react-awesome-reveal";
import {Link} from "react-router-dom";
import i18n from "../../i18n.ts";
import '../../styles/home/home.scss'


export const Home = () => {
    const currentLocale = i18n.language;
    const developers = [
        ["Hugo CASTELL", "https://github.com/Hugo-CASTELL"],
        ["Loan GAYRARD", "https://github.com/Sonixray"],
        ["Matthieu ROBERT", "https://github.com/matthieurobert"],
        ["Marco VALLE WELLMER", "https://github.com/Stemon8"],
        ["Hugo WENDJANEH", "https://github.com/Furiza31"],
        ["Vincent MIQUEU-DENJEAN", "https://github.com/RepliKode"]
    ];
    const {t} = i18n;

    return (
        <>
            <div className="container">
                <div className="title">
                    <Fade cascade direction='up' duration={100}>
                        <h1>
                            <span className="colored">{t('Funnier_way')}</span> {t("to_learn_about")} <span className="colored">{t("climate")}</span>
                        </h1>
                    </Fade>
                </div>
                <div className="desc">
                    <Fade cascade direction='up' duration={300}>
                        <h2><span className="colored">{t("EcoQuizz")}</span> {t("is_an")} <span className="colored">{t("aesthetic_True_or_False_game")}</span> {t('about_climate_changing_with')} <span className="colored">{t('scoring')}</span>.
                        </h2>
                        <p> {t('Developed_by')} {developers.map((developer) => (
                            <Link to={developer[1]} target='_blank' className="link">{developer[0]}</Link>
                        ))}</p>
                    </Fade>
                </div>
                <Fade cascade direction='up' duration={100}>
                    <Link to={`/${currentLocale}/quizz`}>
                        <div className="button">{t('access_the_quizz')}</div>
                    </Link>
                </Fade>
            </div>
        </>
    )
}