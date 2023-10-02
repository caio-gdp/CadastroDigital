import { Component, ElementRef, NgZone, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, AbstractControlOptions, CheckboxRequiredValidator, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Pessoa } from '@app/models/Pessoa';
import { PessoaService } from '@app/services/pessoa.service';
import { ReCaptchaV3Service } from 'ng-recaptcha';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { PaisService } from '@app/services/Pais.service';
import { User } from '@app/models/Identity/User';
import { AccountService } from '@app/services/account.service';
import { GenericValidator } from '@app/validators/GenericValidator';
import { UserLogin } from '@app/models/Identity/UserLogin';
import { Observable } from 'rxjs';
import { DateTimeFormatPipe } from '@app/helpers/DateTimeFormat.pipe';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss'],
})
export class RegistrationComponent implements OnInit {

  user = {} as User;
  form = {} as FormGroup;
  tokenVisible: boolean = false;
  reCAPTCHAToken: string = '';
  teste = false;
  model = {} as UserLogin;
  currentUser : any;

  get f() : any{
    return this.form.controls;
  }

  constructor(private fb : FormBuilder,
    public accountService : AccountService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private recaptchaV3Service: ReCaptchaV3Service,
    //private ngZone: NgZone,
    private router: Router
    ){
        this.currentUser = accountService.currentUser$;
    }

  ngOnInit() : void {
    this.validation();
    //Depois da validação preencher os campos
    this.fillField();

  }

  fillField(){
    var jsonUser: any;
    jsonUser = localStorage.getItem('user');
    this.user = JSON.parse(jsonUser);

    if (this.user != null){
      var cpf = <HTMLInputElement>document.getElementById("userId");
      this.f.userId.hidden;
      this.f.userId.value = this.user.userId;
      this.f.phoneNumber.value = this.user.phoneNumber;
      //this.f.dateOfBirth.value = this.user.dateOfBirth | DateTimeFormatPipe;
      this.f.name.value = this.user.name;
      this.f.email.value = this.user.email;
      this.f.confirmaEmail.value = this.user.email;
      this.f.noticia.value = this.user.noticia;

      alert(this.user.noticia)

      var divpass = <HTMLDivElement>document.getElementById('divPass');
      divpass.hidden = true;
    }
  }

  bsConfig() : any{
    return {
      dateInputFormat: 'DD/MM/YYYY',
      adaptivePosition: true,
      isAnimated: true,
      //containerClass: 'theme-default',
      location: 'pt'
    };
  }

  public cssValidation(filedForm: FormControl | AbstractControl): any {
    return {'is-invalid': filedForm.errors && filedForm.touched};
  }

  private validation() : void{
    const formOptions : AbstractControlOptions = {
      validators : ValidatorField.MustMatch('passwordReg','confirmaPassword')
    }

    this.form = this.fb.group({
      userId : ['', [Validators.required, Validators.maxLength(14), this.checkCpf]],
      dateOfBirth : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), this.checkAge]],
      name : ['', [Validators.required, Validators.minLength(3), Validators.maxLength(150)]],
      phoneNumber : ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      email : ['', [Validators.required, Validators.email]],
      passwordReg : ['', [Validators.required, Validators.minLength(6),Validators.maxLength(15), this.checkPassword]],
      confirmaPassword : ['', [Validators.required, this.checkConfirmedPassword]],
      confirmaEmail : ['', [Validators.required, this.checkEmail]],
      noticia : [],
    }, formOptions);
  }

  public register() : void{

    if (this.form.valid){
      this.spinner.show();

      this.user = {...this.form.value}

      this.accountService.register(this.user).subscribe({
        next : () => {
            this.toastr.success("Pré cadastro realizado. Efetue o login para finalizar o cadastro.", "Informação", {extendedTimeOut: 1000})
            this.router.navigateByUrl('dashboard')
        },
        error: (error: any) => {
            console.log(error)
            this.toastr.error(error.error)
        },
      }).add(() => this.spinner.hide())
    }
  }

  public validaSenha(){
     const campo = <HTMLElement>document.getElementById('spansenha');
     const senha = <HTMLElement>document.getElementById('passwordReg');
     campo.className = "fa fa-check";
  }

  public viewPassword(campo1 : string, campo2 : string, i : any)
  {
    const input = <HTMLInputElement>document.getElementById(campo1);
    const span = <HTMLSpanElement>document.getElementById(campo2);

    if (input.type == 'text'){

      input.type = 'password';

      if (i == 1)
        span.className = "fa fa-eye eye-pwd float-end";
      else
        span.className = "fa fa-eye eye-pwd float-end";
    }
    else{

      input.type = 'text';

      if (i == 1)
        span.className = "fa fa-eye-slash eye-pwd float-end";
      else
        span.className = "fa fa-eye-slash eye-pwd float-end";
    }
  }

  public checkCpf(filedForm: FormControl | AbstractControl){

    if (filedForm.value != ""){
      var Soma;
      var Resto;
      var strCPF = filedForm.value;
      var valid = true;
      Soma = 0;

      if (strCPF == "00000000000" || strCPF == "11111111111" || strCPF == "22222222222" || strCPF == "33333333333" ||
      strCPF == "44444444444" || strCPF == "55555555555" || strCPF == "66666666666" || strCPF == "77777777777" || strCPF == "88888888888" ||
      strCPF == "99999999999")
        valid = false;
        //return { invalid : true };

      for (var i=1; i<=9; i++)
        Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (11 - i);

      Resto = (Soma * 10) % 11;

      if ((Resto == 10) || (Resto == 11))
        Resto = 0;

      if (Resto != parseInt(strCPF.substring(9, 10)))
        valid = false;
        //return { invalid : true };

      Soma = 0;

      for (i = 1; i <= 10; i++)
        Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (12 - i);

      Resto = (Soma * 10) % 11;

      if ((Resto == 10) || (Resto == 11))
        Resto = 0;

      if (Resto != parseInt(strCPF.substring(10, 11)))
        valid = false
        //return { invalid : true };

      if (valid)
        return null;
      else
        return { invalidCheckCpf: true };
    }
    return null;
  }

  public checkConfirmedPassword(filedForm: FormControl | AbstractControl){

    const pass = <HTMLInputElement>document.getElementById("passwordReg");
    const chkpass = filedForm.value;

    if (pass.value != '' && chkpass != ''){
      if (pass.value != chkpass)
        return { invalidCheckConfirmedPassword : true }
      else
      return null;
    }
    return null;
  }

  public checkPassword(filedForm: FormControl | AbstractControl){

    if (filedForm.value != ""){

      const spansenhaminlen = <HTMLElement>document.getElementById('spansenhaminlen');
      const spansenhaupcase = <HTMLElement>document.getElementById('spansenhaupcase');
      const spansenhanum = <HTMLElement>document.getElementById('spansenhanum');
      const spansenhaesp = <HTMLElement>document.getElementById('spansenhaesp');

      var minLen = false;
      var charmaiusculo = false;
      var charnumerico = false;
      var charespecial = false;

      var input = document.querySelector("#passwordReg")

      if (filedForm.value.length > 5)
        minLen = true;

      for (var i = 0; i < filedForm.value.length; i++)
      {
        var valorAscii = filedForm.value.charCodeAt(i);1

        if (valorAscii >= 65 && valorAscii <= 90)
          charmaiusculo = true;

        if (valorAscii >= 48 && valorAscii <= 57)
          charnumerico = true;

        if (valorAscii >= 33 && valorAscii <= 47)
          charespecial = true;

        if (valorAscii >= 58 && valorAscii <= 62)
          charespecial = true;

        if (valorAscii == 64 || valorAscii == 91 || valorAscii == 93 || valorAscii == 94 || valorAscii == 95 ||
          valorAscii == 123 || valorAscii == 125 || valorAscii == 126 || valorAscii == 162 || valorAscii == 163 ||
          valorAscii == 172 || valorAscii == 178 || valorAscii == 179 || valorAscii == 180 || valorAscii == 185)
          charespecial = true;
      }

      if (minLen)
        spansenhaminlen.className = "fa fa-check";
      else
        spansenhaminlen.className = "fa fa-times";

      if (charmaiusculo)
        spansenhaupcase.className = "fa fa-check";
      else
        spansenhaupcase.className = "fa fa-times";

      if (charnumerico)
        spansenhanum.className = "fa fa-check";
      else
        spansenhanum.className = "fa fa-times";

      if (charespecial)
        spansenhaesp.className = "fa fa-check";
      else
        spansenhaesp.className = "fa fa-times";

      if (!minLen || !charmaiusculo || !charnumerico || !charespecial)
        return { invalidPassword : true };

    }
    return null
  }

  public checkAge(filedForm: FormControl | AbstractControl){

    if (filedForm.value != ""){
      const date = new Date(filedForm.value);
      const anoNascimento = date.getFullYear();
      const anoAtual = new Date().getFullYear();

      const idade = (anoAtual - anoNascimento) - 1;

         if (idade < 18)
           return { menorIdade: true } ;
    }
    return null;
  }

  public send(): void {
    this.recaptchaV3Service.execute('importantAction')
    .subscribe((token: string) => {
    this.tokenVisible = true;
      this.reCAPTCHAToken = `Token [${token}] generated`;
    //  console.debug(`Token [${token}] generated`);
    });
  }

   public checkEmail(filedForm: FormControl | AbstractControl){

    const email = <HTMLInputElement>document.getElementById("email");
    const chkemail = filedForm.value;

    if (email.value != '' && chkemail != ''){
      if (email.value != chkemail)
        return { invalidCheckEmail : true }
      else
        return null;
    }
    return null;
  }

  // errored(e: any){
  //   console.log('erro reCAPTCHA não encontrado');
  // }

  // resolved(e: any){
  //   // this.http;
  // }

  public onlyNumbers(e: any){
    GenericValidator.onlyNumbers(e);
  }

}
