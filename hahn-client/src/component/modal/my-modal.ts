import { autoinject } from 'aurelia-framework';
import {DialogController} from 'aurelia-dialog';

@autoinject
export class Prompt {
   message?: string;
   action?: (args?: any) => {};
   cancelAction?: (args?: any) => {};
   confirmation: boolean;


   constructor(private controller : DialogController) {
      controller.settings.centerHorizontalOnly = true;
   }

   get isConfirmation(){
      return this.confirmation;
  }

   activate(model: any) {
      this.message = model.message;
      this.action = model.action;
      this.cancelAction = model.cancelAction;
      this.confirmation = model.confirmation;
   }

   ok() : void {
      if(this.action !== undefined){
          this.action();
      } 
      this.controller.ok();
   }

   cancel() : void {
      if(this.cancelAction !== undefined){
          this.cancelAction();
      }
      this.controller.ok();
   }

   
}