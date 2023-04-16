import { Component } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent {

  form!: FormGroup;

  get f() : any{
    return this.form.controls;
  }

  constructor(public fb : FormBuilder){}

  ngOnInit() : void {
    this.validation();
  }

  private validation() : void{

    const formOptions : AbstractControlOptions = {
      validators : ValidatorField.MustMatch('senha','conformaSenha')
    };

    this.form = this.fb.group({
      cpf : ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      dataNascimento : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      nome : ['', [Validators.required, Validators.minLength(2), Validators.maxLength(150)]],
      telefone : ['', [Validators.required]],
      email :['', [Validators.required, Validators.email]],
    }, formOptions);
  }
}
