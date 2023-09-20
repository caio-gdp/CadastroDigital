import { AbstractControl, FormControl } from "@angular/forms";

export class GenericValidator {

  static onlyNumbers(e : any){

    if (e.keyCode >= 48 && e.keyCode >= 57)
      return false;

      return true;
  }
}
