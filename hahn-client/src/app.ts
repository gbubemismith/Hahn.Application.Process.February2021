import { RouterConfiguration, Router } from "aurelia-router";
import { PLATFORM } from 'aurelia-pal';

export class App {
  router: Router;
  
  configureRouter(config: RouterConfiguration, router: Router) {
    config.options.pushState = true;
  
    config.map([
      { route: ['', 'home'], name: 'Home', title: 'Home Page', moduleId: PLATFORM.moduleName('./component/home/home'), nav: true },
      { route: ['success'], name: 'Success', title: 'Success Page', moduleId: PLATFORM.moduleName('./component/success/success'), nav: true }
    ]);  

    this.router = router;
  }

  

}
