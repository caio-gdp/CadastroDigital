import { AbstractControl, FormGroup, Validators } from "@angular/forms"

export class ValidatorField {

  static MustMatch(controlName : string, matchingControlName : string) : any{
    return (group : AbstractControl) => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.mustMatch){
        return;
      }

      if (control.value != matchingControl.value){
        matchingControl.setErrors({mustMatch : true});
      }else{
        matchingControl.setErrors(null);
      }

      return null;
    };
  }

  static formPMS(controlName0 : string, controlName1 : string, controlName2 : string, controlName3 : string, controlNameDepend : string) : any{
    return (group : AbstractControl) => {
      const formGroup = group as FormGroup;
      const control0 = formGroup.controls[controlName0];
      const control1 = formGroup.controls[controlName1];
      const control2 = formGroup.controls[controlName2];
      const control3 = formGroup.controls[controlName3];
      const controlDepend = formGroup.controls[controlNameDepend];

      control0.setErrors(null);
      control1.setErrors(null);
      control2.setErrors(null);
      control3.setErrors(null);
      control0.markAsUntouched({ onlySelf: true });
      control1.markAsUntouched({ onlySelf: true });
      control2.markAsUntouched({ onlySelf: true });
      control3.markAsUntouched({ onlySelf: true });

      if (controlDepend.value == 1){

        if (control0.value == ""){
          control0.setErrors({invalid: true});
          //control1.markAsTouched({ onlySelf: true });
        }else{
          control0.setErrors(null);
        }

        if (control1.value == ""){
          control1.setErrors({invalid: true});
          //control1.markAsTouched({ onlySelf: true });
        }else{
          control1.setErrors(null);
        }

        if (control1.value.length > 3 && control2.value == ""){
          control2.setErrors({invalid : true});
          control2.touched;

        }else{
          control2.setErrors(null);
        }

        if (control3.value == ""){
          control3.setErrors({invalid : true});
        }else{
          control3.setErrors(null);
        }
      }
      else if(controlDepend.value == 2){

        if (control0.value == ""){
          control0.setErrors({invalid: true});
          //control1.markAsTouched({ onlySelf: true });
        }else{
          control0.setErrors(null);
        }

        if (control3.value == ""){
          control3.setErrors({invalid : true});
        }else{
          control3.setErrors(null);
        }

        control1.setErrors(null);
        control2.setErrors(null);

      }
      else if(controlDepend.value == 3 || controlDepend.value == 4){

        if (control0.value == ""){
          control0.setErrors({invalid: true});
          //control1.markAsTouched({ onlySelf: true });
        }else{
          control0.setErrors(null);
        }

        control1.setErrors(null);
        control2.setErrors(null);
        control3.setErrors(null);

      }
      else{
        control0.setErrors(null);
        control1.setErrors(null);
        control2.setErrors(null);
        control3.setErrors(null);
      }
      return null;
    };
  }
}
