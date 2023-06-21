import { Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';

@Component({
  selector: 'app-personalData',
  templateUrl: './personalData.component.html',
  styleUrls: ['./personalData.component.scss']
})
export class PersonalDataComponent implements OnInit {

  form!: FormGroup;

  get f() : any{
    return this.form.controls;
  }

  constructor(public fb : FormBuilder) { }

  ngOnInit() {
    this.validation();
  }

  public cssValidation(filedForm: FormControl | AbstractControl): any {
    return {'is-invalid': filedForm.errors && filedForm.touched};
  }

  private validation() : void{
    this.form = this.fb.group({
      rg : ['', [Validators.required, Validators.minLength(8), Validators.maxLength(12)]],
      dataEmissao : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      orgaoExpedidor : ['', [Validators.required]],
      telefone : ['', [Validators.required]],
      email : ['', [Validators.required, Validators.email]],
      senha : ['', [Validators.required, Validators.minLength(6),Validators.maxLength(15)]],
      confirmaSenha : ['', [Validators.required]]
    });
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

  public readonlyDatePicker(e : any) : Boolean{
    if (e.keyCode > 0) return false;

    return true;
 }

 public saveChange() : void{

//   this.spinner.show();

//   if (this.form.valid){

//     // this.pessoa = {...this.form.value};

//     this.pessoa = {
//       id: 0,
//       dataCadastro: new Date().toISOString().slice(0,10),
//       dataAtualizacao: new Date().toISOString().slice(0,10),
//       codigoValidacao: 1234,
//       dataHoraCodigoValidacao: new Date().toISOString().slice(0,10),
//       senha: this.form.get('senha')?.value,
//       confirmaSenha: this.form.get('confirmaSenha')?.value,
//       statusCadastroId: 1,
//       notificacao: false,
//       tipoPessoaId: 2,
//       pessoaFisica: {
//         id: 0,
//         cpf: this.form.get('cpf')?.value,
//         dataNascimento: this.form.get('dataNascimento')?.value,
//         nome: this.form.get('nome')?.value,
//         imagem: 'imagem4.jpg',
//         pessoaId: 0,
//         sexoId: 1,
//         estadoCivilId: 1
//       },
//       telefone: {
//         id: 0,
//         tipoTelefoneId: 2,
//         ddd: this.form.get('celular')?.value.substring(0,2),
//         numero: this.form.get('celular')?.value.substring(3),
//         principal: true,
//         valido: true,
//         pessoaId: 0
//       },
//       email: {
//         id: 0,
//         pessoaId: 0,
//         tipoEmailId: 1,
//         endereco: this.form.get('email')?.value,
//         principal: true,
//         valido: true
//       }
//     }

//     this.pessoaService.post(this.pessoa).subscribe({
//       next: (pessoa: Pessoa) => {
//         this.toastr.success('Registro salvo com sucesso.', 'Sucesso')},
//       error: (error: any) => {
//         console.error(error);
//         this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
//       },
//     }).add(() => this.spinner.hide());
//   }
//   else{
//     this.toastr.error('Preencha os campos obrigatórios.', 'Atenção!')
//   }
// }

 }

}
