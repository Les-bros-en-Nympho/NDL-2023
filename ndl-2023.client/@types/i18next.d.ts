// import the original type declarations
import "i18next";
// import all namespaces (for the default language, only)
import fr from '../src/locales/fr.json'
import en from '../src/locales/en.json'

declare module "i18next" {
  // Extend CustomTypeOptions
  interface CustomTypeOptions {
    defaultNS: 'fr';
    resources: {
      fr: typeof fr;
      en: typeof en;
    };
  }
}