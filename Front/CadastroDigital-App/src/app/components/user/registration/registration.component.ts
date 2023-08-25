import { Component, ElementRef, NgZone, ViewChild } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Pessoa } from '@app/models/Pessoa';
import { PessoaService } from '@app/services/pessoa.service';
import { ReCaptchaV3Service } from 'ng-recaptcha';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { PaisService } from '@app/services/Pais.service';

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
    private ngZone: NgZone,
    private router: Router
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

  private Maior18Anos(filedForm: FormControl | AbstractControl){

      if (filedForm.value != ""){
        const anoNascimento = filedForm.value.getFullYear();
        const anoAtual = new Date().getFullYear();

        const idade = (anoAtual - anoNascimento) - 1;

           if (idade < 18)
             return { menorIdade: true } ;
      }
    return null;
  }

  private CpfInvalido(filedForm: FormControl | AbstractControl){

    if (filedForm.value != ""){
      var Soma;
      var Resto;
      var strCPF = filedForm.value;
      Soma = 0;

      if (strCPF == "00000000000")
        return { invalido : true };

      for (var i=1; i<=9; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (11 - i);
        Resto = (Soma * 10) % 11;

        if ((Resto == 10) || (Resto == 11))
          Resto = 0;

        if (Resto != parseInt(strCPF.substring(9, 10)) )
          return { invalido : true };

        Soma = 0;

        for (i = 1; i <= 10; i++)
          Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (12 - i);

        Resto = (Soma * 10) % 11;

        if ((Resto == 10) || (Resto == 11))
          Resto = 0;

          if (Resto != parseInt(strCPF.substring(10, 11) ) )
            return { invalido : true };

        return { invalido : false };
      }
    return null;
  }

  private checkPassword(filedForm: FormControl | AbstractControl){

    const pass = filedForm.get('senha')?.value;
    const chcpass = filedForm.value;

     if (pass != '' && chcpass != ''){
       if (pass != chcpass)
         return { invalidCheckPassword : true }
       else
         return { invalidCheckPassword : false }
     }
    return null;
  }

  private validation() : void{
    const formOptions : AbstractControlOptions = {
      validators : ValidatorField.MustMatch('senha','confirmaSenha')
    }
    this.form = this.fb.group({
      cpf : ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11), this.CpfInvalido]],
      dataNascimento : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), this.Maior18Anos]],
      nome : ['', [Validators.required, Validators.minLength(2), Validators.maxLength(150)]],
      telefone : ['', [Validators.required]],
      email : ['', [Validators.required, Validators.email]],
      senha : ['', [Validators.required, Validators.minLength(6),Validators.maxLength(15)]],
      confirmaSenha : ['', [Validators.required, this.checkPassword]],
      confirmaEmail : ['', [Validators.required]],
      confirmaNoticia : [],
    }, formOptions);

  }

  public saveChange() : void{

    this.spinner.show();
    let chk = <HTMLInputElement>document.getElementById('confirmaNoticia')

    if (this.form.valid){

      // this.pessoa = {...this.form.value};

      this.pessoa = {
        id: 0,
        dataCadastro: new Date().toISOString().slice(0,10),
        dataAtualizacao: '',
        codigoValidacao: 0,
        dataHoraCodigoValidacao: new Date().toISOString().slice(0,10),
        senha: this.form.get('senha')?.value,
        confirmaSenha: this.form.get('confirmaSenha')?.value,
        statusCadastroId: 3,
        passoCadastroId: 1,
        enderecoIp: '',
        notificacao: chk.checked,
        tipoPessoaId: 2,
        pessoaFisica: {
          id: 0,
          cpf: this.form.get('cpf')?.value,
          dataNascimento: this.form.get('dataNascimento')?.value,
          nome: this.form.get('nome')?.value,
          rg: '',
          dataEmissao: '',
          orgaoExpedidorId: null,
          ufId: null,
          imagem: '',
          pessoaId: 0,
          sexoId: null,
          estadoCivilId: null
        },
        telefone: {
          id: 0,
          pessoaId: 0,
          tipoTelefoneId: 2,
          ddd: this.form.get('celular')?.value.substring(0,2),
          numero: this.form.get('celular')?.value.substring(3),
          dataInclusao: new Date().toISOString().slice(0,10),
          usuarioInclusao: 'web'
        },
        email: {
          id: 0,
          pessoaId: 0,
          tipoEmailId: 1,
          endereco: this.form.get('email')?.value,
          dataInclusao: new Date().toISOString().slice(0,10),
          usuarioInclusao: 'web'
        }
      }

      this.pessoaService.post(this.pessoa).subscribe({
        next: (pessoa: Pessoa) => {
          this.toastr.success('Registro salvo com sucesso.', 'Sucesso')
          this.toastr.info('Efetue o login para concluir o cadastro', 'Informação', {extendedTimeOut: 1000})
          this.router.navigate([`dashboard`]);
        },
        error: (error: any) => {
          console.log(error);
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
