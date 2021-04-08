import { Router } from 'aurelia-router';
import { ValidationRules } from 'aurelia-validation';
import { autoinject } from 'aurelia-dependency-injection';
import { AssetService } from './../../services/assetService';
import { DialogService } from 'aurelia-dialog';
import './home.css';
import { observable, bindable } from 'aurelia-framework';
import { Asset } from './../../models/asset';
import {ValidationControllerFactory, ValidationController} from 'aurelia-validation';
import { EventAggregator } from 'aurelia-event-aggregator';
import { I18N } from 'aurelia-i18n';
import { BootstrapFormRenderer } from '../../helpers/bootstrap-form-renderer';
import { Prompt } from 'component/modal/my-modal';


@autoinject
export class Home {
  @bindable
  public asset = new Asset();
  isChecked: boolean = false ;
  controller: ValidationController;
  public locales: { key: string; label: string }[];


  @observable currentLocale: string;

  constructor(
    controllerFactory: ValidationControllerFactory, 
    private ea: EventAggregator, 
    private i18n : I18N,
    private dialogService:DialogService,
    private assetService: AssetService,
    private router: Router) {
      // this.canSave = false;
      this.controller = controllerFactory.createForCurrentScope();
      
      this.controller.addRenderer(new BootstrapFormRenderer());
      this.controller.addObject(this);
      this.controller.reset({ object: this.asset, propertyName: 'isBroken' });

      this.locales = [
        { key: "en", label: "English" },
        { key: "de", label: "German" }
      ];

      this.currentLocale = this.i18n.getLocale();

  }

  public bind() {
    // this.controller.validate();

    let validateYear = new Date();
    validateYear.setUTCFullYear(validateYear.getUTCFullYear() - 1);

    ValidationRules
      .ensure('assetName').required().withMessage(this.i18n.tr('assetForm.validationErrors.nameRequiredError'))
                          .minLength(5).withMessage(this.i18n.tr('assetForm.validationErrors.nameLengthError'))
      .ensure('department').required().withMessage(this.i18n.tr('assetForm.validationErrors.departmentError'))
      .ensure('countryOfDepartment').required().withMessage(this.i18n.tr('assetForm.validationErrors.countryRequired'))
      .ensure('eMailAdressOfDepartment').required().withMessage(this.i18n.tr('assetForm.validationErrors.emailRequired'))
                          .email().withMessage(this.i18n.tr('assetForm.validationErrors.emailValid'))
      .ensure('purchaseDate').satisfies(p => new Date(p) > validateYear).withMessage(this.i18n.tr('assetForm.validationErrors.purchaseDate'))
      .on(this.asset);

  }

  public currentLocaleChanged(newValue: string, oldValue: string): void {
    if (newValue) {
      if (newValue !== this.i18n.getLocale()) {
        this.setLocale(newValue);
      }
    }
  }

  //method to disable save button on initial load
  get canSave() {
    // console.log('here in can save');
    return this.controller.errors.length === 0 && this.asset.initialAssetLoad()
  }

  //method to disable reset button on initial load
  get canReset() {
    return this.asset.initialAssetLoad();
  }

  //method to create asset
  createAsset() {
    this.asset.isBroken = this.isChecked;
    this.controller.validate().then((validate) => {
      if (validate.valid) {
        this.assetService.createAsset(this.asset)
        .then(response => {
          console.log(response);
          console.log('here',response?.statusCode);

          if (response?.statusCode != null)
          {
            let error: [] = response?.errors;
            error.forEach((item) => {
              this.showModal(item + '::Bad Request ERROR!!');
            })
            // this.showModal('Bad Request ERROR!!')
            
          }
          else {
            this.router.navigateToRoute("Success");
          }
        })
        .catch(error => {
          this.showModal('ERROR!! today seems like a bad day, try again')
          console.log(error);
        })
      }
    });
  }

  resetData() {
    this.showModal(this.i18n.tr('assetForm.modalMessage'), true,
      () => {
        this.controller.removeObject(this.asset);
        this.asset = new Asset();
        this.bind();
      }
    );
  }


  private setLocale(locale: string): void {
    this.i18n.setLocale(locale).then(() => {
      console.log(`Locale has been set to ${locale}`);
    });
  }

  private showModal(message, confirmation=false, action?, cancelAction?)
  {
    this.dialogService.open({ 
      viewModel: Prompt, 
      model:{ message : message, 
              confirmation: confirmation,
              action: action,
              cancelAction: cancelAction}         
    })
  }
}
