import {Aurelia} from 'aurelia-framework';
import * as environment from '../config/environment.json';
import {PLATFORM} from 'aurelia-pal';
import { Backend, TCustomAttribute } from 'aurelia-i18n';
// import Backend from "i18next-xhr-backend";

export function configure(aurelia: Aurelia): void {
  aurelia.use
    .standardConfiguration()
    .feature(PLATFORM.moduleName('resources/index'))
    .plugin(PLATFORM.moduleName('aurelia-validation'))
    .plugin(PLATFORM.moduleName('aurelia-configuration'));

  aurelia.use.developmentLogging(environment.debug ? 'debug' : 'warn');

  if (environment.testing) {
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
  }

  aurelia.use 
    .plugin(PLATFORM.moduleName('aurelia-i18n'), (instance) => { 
      const aliases = ['t', 'i18n']; 
      TCustomAttribute.configureAliases(aliases); 
      instance.i18next.use(Backend.with(aurelia.loader)); 
      return instance.setup({ 
        backend: { 
          loadPath: 'locales/{{lng}}/{{ns}}.json'
        }, 
        preload: ['en','de'],
        attributes: aliases, 
        lng : 'en', 
        fallbackLng : 'de',
          debug : false 
      }); 
    })
    .plugin(PLATFORM.moduleName('aurelia-dialog'));

  aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}
