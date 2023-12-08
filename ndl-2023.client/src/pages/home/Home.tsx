import {Fade} from "react-awesome-reveal";
import {Link} from "react-router-dom";
import i18n from "../../i18n.ts";
import {t} from "i18next";
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

    return (
        <>
            <div className="container">
                <div className="title">
                    <Fade cascade direction='up' duration={100}>
                        <h1>
                            <span className="colored">Funnier way</span> to learn about <span className="colored">climate</span>
                        </h1>
                    </Fade>
                </div>
                <div className="desc">
                    <Fade cascade direction='up' duration={300}>
                        <h2><span className="colored">EcoQuizz</span> is an <span className="colored">aesthetic True or False game</span> about climate changing with <span className="colored">scoring</span>.
                        </h2>
                        <p>Developed by {developers.map((developer) => (
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