import { Component, ElementRef, NgZone, ViewChild } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Pessoa } from '@app/models/Pessoa';
import { PessoaService } from '@app/services/pessoa.service';
import { ReCaptchaV3Service } from 'ng-recaptcha';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss'],
})
export class RegistrationComponent {

  pessoa: Pessoa;
  form!: FormGroup;
  tokenVisible: boolean = false;
  reCAPTCHAToken: string = '';

  get f() : any{
    return this.form.controls;
  }

  constructor(public fb : FormBuilder,
    private pessoaService : PessoaService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private recaptchaV3Service: ReCaptchaV3Service,
    private ngZone: NgZone
    ){}

  ngOnInit() : void {
     this.validation();
  }

  bsConfig() : any{
    return {
      dateInputFormat: 'DD/MM/YYYY',
      adaptivePosition: true,
      isAnimated: true,
      containerClass: 'theme-default',
      location: 'pt-BR'
    };
  }

  public cssValidation(filedForm: FormControl | AbstractControl): any {
    return {'is-invalid': filedForm.errors && filedForm.touched};
  }

  private validation() : void{
    const formOptions : AbstractControlOptions = {
      validators : ValidatorField.MustMatch('senha','confirmaSenha')
    };

    this.form = this.fb.group({
      cpf : ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      dataNascimento : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      nome : ['', [Validators.required, Validators.minLength(2), Validators.maxLength(150)]],
      telefone : ['', [Validators.required]],
      email : ['', [Validators.required, Validators.email]],
      senha : ['', [Validators.required, Validators.minLength(6),Validators.maxLength(15)]],
      confirmaSenha : ['', [Validators.required]]
    }, formOptions);
  }

  public saveChange() : void{

    this.spinner.show();

    if (this.form.valid){

      // this.pessoa = {...this.form.value};

      this.pessoa = {
        id: 0,
        dataCadastro: new Date().toISOString().slice(0,10),
        dataAtualizacao: new Date().toISOString().slice(0,10),
        codigoValidacao: 1234,
        dataHoraCodigoValidacao: new Date().toISOString().slice(0,10),
        senha: this.form.get('senha')?.value,
        confirmaSenha: this.form.get('confirmaSenha')?.value,
        statusCadastroId: 1,
        notificacao: false,
        tipoPessoaId: 2,
        pessoaFisica: {
          id: 0,
          cpf: this.form.get('cpf')?.value,
          dataNascimento: this.form.get('dataNascimento')?.value,
          nome: this.form.get('nome')?.value,
          imagem: 'imagem4.jpg',
          pessoaId: 0,
          sexoId: 1,
          estadoCivilId: 1
        },
        telefone: {
          id: 0,
          tipoTelefoneId: 2,
          ddd: this.form.get('celular')?.value.substring(0,2),
          numero: this.form.get('celular')?.value.substring(3),
          principal: true,
          valido: true,
          pessoaId: 0
        },
        email: {
          id: 0,
          pessoaId: 0,
          tipoEmailId: 1,
          endereco: this.form.get('email')?.value,
          principal: true,
          valido: true
        }
      }

      this.pessoaService.post(this.pessoa).subscribe({
        next: (pessoa: Pessoa) => {
          this.toastr.success('Registro salvo com sucesso.', 'Sucesso')},
        error: (error: any) => {
          console.error(error);
          this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
        },
      }).add(() => this.spinner.hide());
    }
    else{
      this.toastr.error('Preencha os campos obrigatórios.', 'Atenção!')
    }
  }

   public readonlyDatePicker(e : any) : Boolean{
     if (e.keyCode > 0) return false;

     return true;
  }

  public validaSenha(){
     const campo = <HTMLElement>document.getElementById('spansenha');
     const senha = <HTMLElement>document.getElementById('senha');
     campo.className = "fa fa-check";
  }

  public viewPassword(campo1 : string, campo2 : string, i : any)
  {
    const input = <HTMLInputElement>document.getElementById(campo1);
    const span = <HTMLElement>document.getElementById(campo2);

    if (input.type == 'text'){
      input.type = 'password';
      if (i == 1)
        span.className = "fa fa-eye eye-pwd";
      else
        span.className = "fa fa-eye eye-pwd-confirm";
    }
    else{
      input.type = 'text';
      if (i == 1)
        span.className = "fa fa-eye-slash eye-pwd";
      else
        span.className = "fa fa-eye-slash eye-pwd-confirm";
    }
  }

  public confereSenha(e : any){

    const input = <HTMLInputElement>document.getElementById("senha");
    const spansenhaminlen = <HTMLElement>document.getElementById('spansenhaminlen');
    const spansenhaupcase = <HTMLElement>document.getElementById('spansenhaupcase');
    const spansenhanum = <HTMLElement>document.getElementById('spansenhanum');
    var charmaiusculo = false;
    var charnumerico = false;


    if (input.value.length > 5)
      spansenhaminlen.className = "fa fa-check";
    else
      spansenhaminlen.className = "fa fa-times";

    for (var i = 0; i < input.value.length; i++)
    {
      var valorAscii = input.value.charCodeAt(i);

      if (valorAscii >= 65 && valorAscii <= 90)
        charmaiusculo = true;

      if (valorAscii >= 48 && valorAscii <= 57)
        charnumerico = true;

    }

    if (charmaiusculo)
      spansenhaupcase.className = "fa fa-check";
    else
      spansenhaupcase.className = "fa fa-times";

    if (charnumerico)
      spansenhanum.className = "fa fa-check";
    else
      spansenhanum.className = "fa fa-times";
  }

   public send(): void {
     this.recaptchaV3Service.execute('importantAction')
     .subscribe((token: string) => {
      this.tokenVisible = true;
       this.reCAPTCHAToken = `Token [${token}] generated`;
      //  console.debug(`Token [${token}] generated`);
     });
   }

  // errored(e: any){
  //   console.log('erro reCAPTCHA não encontrado');
  // }

  // resolved(e: any){
  //   // this.http;
  // }


}
