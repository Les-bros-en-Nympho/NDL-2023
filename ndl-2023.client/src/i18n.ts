import i18next from 'i18next';
import fr from './locales/fr.json'
import en from './locales/en.json'

i18next.init({
    debug: true,
    fallbackLng: 'fr',
    resources: {
        fr: { translation: fr },
        en: { translation: en },
    },
});

export default i18next;