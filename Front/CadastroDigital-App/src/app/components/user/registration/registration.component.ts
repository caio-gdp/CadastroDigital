import { Component } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Pessoa } from '@app/models/Pessoa';
import { PessoaService } from '@app/services/pessoa.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss'],
})
export class RegistrationComponent {

  pessoa: Pessoa;
  form!: FormGroup;

  get f() : any{
    return this.form.controls;
  }

  constructor(public fb : FormBuilder,
    private pessoaService : PessoaService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService){}

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

  // public mask = {
  //   guide: true,
  //   showMask : true,
  //   mask: [/\d/, /\d/, '/', /\d/, /\d/, '/',/\d/, /\d/,/\d/, /\d/]
  // };

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
      senha : ['', [Validators.required, Validators.minLength(6)]],
      confirmaSenha : ['', [Validators.required]],
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


  public ajusteCssValor(campo: FormControl) : void{
    // if (campo.value != "")
        // alert(campo.value);


  }

  public readonlyDatePicker(e : any) : Boolean{
     if (e.keyCode > 0) return false;

     return true;
  }

  public dataMask() : void{

    alert()
  }
}
