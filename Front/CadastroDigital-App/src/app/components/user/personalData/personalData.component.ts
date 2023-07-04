import { Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { RedeSocial } from '@app/models/RedeSocial';
import { OrgaoExpedidor } from '@app/models/OrgaoExpedidor';
import { OrgaoExpedidorService } from '@app/services/orgaoexpedidor.service';
import { Estado } from '@app/models/Estado';
import { EstadoService } from '@app/services/estado.service';
import { CidadeService } from '@app/services/cidade.service';
import { Cidade } from '@app/models/Cidade';
import { Pais } from '@app/models/Pais';
import { PaisService } from '@app/services/Pais.service';

@Component({
  selector: 'app-personalData',
  templateUrl: './personalData.component.html',
  styleUrls: ['./personalData.component.scss']
})
export class PersonalDataComponent implements OnInit {

  public orgaosExpedidores: OrgaoExpedidor[] = [];
  public estados: Estado[] = [];
  public cidades: Cidade[] = [];
  public pais : Pais;

  form!: FormGroup;

  get f() : any{
    return this.form.controls;
  }

  get redesSociais(): FormArray{
    return this.form.get('redesSociais') as FormArray;
  }

  constructor(public fb : FormBuilder,
    private orgaoExpedidorService: OrgaoExpedidorService,
    private estadoService: EstadoService,
    private cidadeService: CidadeService,
    private paisService: PaisService) { }

  ngOnInit() {
    this.validation();
    this.getOrgaoExpedidor();
    this.getEstado();
  }

  public cssValidation(filedForm: FormControl | AbstractControl): any {
    return {'is-invalid': filedForm.errors && filedForm.touched};
  }

  private validation() : void{
    this.form = this.fb.group({
      rg : ['', [Validators.required, Validators.minLength(8), Validators.maxLength(12)]],
      dataEmissao : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      orgaoExpedidor : ['', [Validators.required]],
      ufExpedidor : ['', [Validators.required]],
      naturalidade : ['', [Validators.required]],
      nacionalidade : ['', [Validators.required]],
      estadoCivil : ['', [Validators.required]],
      sexo : ['', [Validators.required]],
      redesSociais: this.fb.array([])
    });
  }

  addRedeSocial() : void{
    this.redesSociais.push(this.criarLote({id: 0} as RedeSocial));
  }

  criarLote(redeSocial : RedeSocial): FormGroup {
    return this.fb.group({
      id: [redeSocial.id],
      pessoaId: [redeSocial.pessoaId],
      tipoRedeSocialId: [redeSocial.tipoRedeSocialId],
      endereco: [redeSocial.endereco]
    })
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

 public getOrgaoExpedidor() : void{
  const observer = {
    next : (_orgaosExpedidores : OrgaoExpedidor[]) => {
        this.orgaosExpedidores = _orgaosExpedidores;
    },
    error : (error : any) =>
    {
      // this.spinner.hide(),
      // this.toastr.error('Erro ao carregar os registros.', "Erro!")
    },
    // complete : () => this.spinner.hide()
  };
  this.orgaoExpedidorService.get().subscribe(observer);
}

public getEstado() : void{
  const observer = {
    next : (_estados : Estado[]) => {
        this.estados = _estados;

        this.getPais(this.estados[0].paisId);
    },
    error : (error : any) =>
    {
      // this.spinner.hide(),
      // this.toastr.error('Erro ao carregar os registros.', "Erro!")
    },
    // complete : () => this.spinner.hide()
  };
  this.estadoService.get().subscribe(observer);
}

public getCidade() : void{

  var obj = (<HTMLSelectElement>document.getElementById("ufExpedidor"));
  var estado : number = +(<HTMLOptionElement>obj[obj.options.selectedIndex]).value.replace(":","");

   const observer = {
     next : (_cidades : Cidade[]) => {
         this.cidades = _cidades;
     },
     error : (error : any) =>
     {
       // this.spinner.hide(),
       // this.toastr.error('Erro ao carregar os registros.', "Erro!")
     },
     // complete : () => this.spinner.hide()
   };
  this.cidadeService.get(estado).subscribe(observer);

}

public getPais(id : number) : void{

   const observer = {
     next : (_pais : Pais) => {
         this.pais = _pais;
         alert(this.pais.id)
     },
     error : (error : any) =>
     {
       // this.spinner.hide(),
       // this.toastr.error('Erro ao carregar os registros.', "Erro!")
     },
     // complete : () => this.spinner.hide()
   };
  this.paisService.getById(id).subscribe(observer);
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
