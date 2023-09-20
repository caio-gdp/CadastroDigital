import { Component, OnInit, TemplateRef } from '@angular/core';
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
import { EstadoCivil } from '@app/models/EstadoCivil';
import { EstadoCivilService } from '@app/services/estadocivil.service';
import { Sexo } from '@app/models/Sexo';
import { SexoService } from '@app/services/sexo.service';
import { TipoRedeSocial } from '@app/models/TipoRedeSocial';
import { TipoRedeSocialService } from '@app/services/tiporedesocial.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { PessoaFisica } from '@app/models/PessoaFisica';
import { PessoaService } from '@app/services/pessoa.service';
import { HttpEvent } from '@angular/common/http';

@Component({
  selector: 'app-personalData',
  templateUrl: './personalData.component.html',
  styleUrls: ['./personalData.component.scss']
})
export class PersonalDataComponent implements OnInit {

  pessoaFisica = {} as PessoaFisica;
  public orgaosExpedidores: OrgaoExpedidor[] = [];
  public estados: Estado[] = [];
  public cidades: Cidade[] = [];
  public pais : Pais;
  public estadosCivil: EstadoCivil[] = [];
  public sexos: Sexo[] = [];
  public tiposRedesSociais: TipoRedeSocial[] = [];
  i : number;

  form!: FormGroup;

  get f() : any{
    return this.form.controls;
  }

  get redesSociais(): FormArray{
    return this.form.get('redesSociais') as FormArray;
  }

  constructor(public fb : FormBuilder,
    private pessoaService : PessoaService,
    private orgaoExpedidorService: OrgaoExpedidorService,
    private estadoService: EstadoService,
    private cidadeService: CidadeService,
    private paisService: PaisService,
    private estadoCivilService: EstadoCivilService,
    private sexoService: SexoService,
    private tipoRedeSocialService : TipoRedeSocialService,
    private modalService: BsModalService,
    private modalRef : BsModalRef,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.validation();
    this.getOrgaoExpedidor();
    this.getEstado();
    this.getEstadoCivil();
    this.getSexo();
    this.getTipoRedeSocial();
  }

  public cssValidation(filedForm: FormControl | AbstractControl): any {
    return {'is-invalid': filedForm.errors && filedForm.touched};
  }

  private validation() : void{
    this.form = this.fb.group({
      rg : ['', [Validators.required, Validators.minLength(8), Validators.maxLength(12)]],
      dataEmissao : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), this.checkDate]],
      orgaoExpedidor : ['', [Validators.required]],
      ufExpedidor : ['', [Validators.required]],
      naturalidade : ['', [Validators.required]],
      nacionalidade : ['', [Validators.required]],
      estadoCivil : ['', [Validators.required]],
      sexo : ['', [Validators.required]],
      redesSociais: this.fb.array([])
    });
  }

  public checkDate(filedForm: FormControl | AbstractControl){

    if (filedForm.value != ""){
      const dateEmissao = new Date(filedForm.value);
      const dateAtual = new Date();

      console.log(dateEmissao + '-' + dateAtual)

         if (dateEmissao > dateAtual)
           return { invalidDate: true } ;
    }
    return null;
  }

  addRedeSocial() : void{
    this.redesSociais.push(this.criarRedeSocial({id: 0} as RedeSocial));
  }

  criarRedeSocial(redeSocial : RedeSocial): FormGroup {
    return this.fb.group({
      id: [redeSocial.id],
      pessoaId: [redeSocial.pessoaId],
      tipoRedeSocialId: [redeSocial.tipoRedeSocialId],
      endereco: [redeSocial.endereco]
    })
  }

  removerRedeSocial(i : number){
    this.redesSociais.removeAt(i);
  }

  bsConfig() : any{
    return {
      dateInputFormat: 'DD/MM/YYYY',
      adaptivePosition: true,
      isAnimated: true,
      //containerClass: 'theme-default',
      location: 'pt-BR'
    };
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
  var estado : number = +(<HTMLOptionElement>obj[obj.options.selectedIndex]).value;

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

  this.changeCss('ufExpedidor');
}

public getPais(id : number) : void{
   const observer = {
     next : (_pais : Pais) => {
         this.pais = _pais;
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

public getEstadoCivil() : void{
  const observer = {
    next : (_estadosCivil : EstadoCivil[]) => {
        this.estadosCivil = _estadosCivil;
    },
    error : (error : any) =>
    {
      // this.spinner.hide(),
      // this.toastr.error('Erro ao carregar os registros.', "Erro!")
    },
    // complete : () => this.spinner.hide()
  };
  this.estadoCivilService.get().subscribe(observer);
}

public getSexo() : void{
  const observer = {
    next : (_sexos : Sexo[]) => {
        this.sexos = _sexos;
    },
    error : (error : any) =>
    {
      // this.spinner.hide(),
      // this.toastr.error('Erro ao carregar os registros.', "Erro!")
    },
    // complete : () => this.spinner.hide()
  };
  this.sexoService.get().subscribe(observer);
}

public getTipoRedeSocial() : void{

  const observer = {
    next : (_tiposredessociais : TipoRedeSocial[]) => {
        this.tiposRedesSociais = _tiposredessociais;
    },
    error : (error : any) =>
    {
      // this.spinner.hide(),
      // this.toastr.error('Erro ao carregar os registros.', "Erro!")
    },
    // complete : () => this.spinner.hide()
  };
  this.tipoRedeSocialService.get().subscribe(observer);
}

openModal(template: TemplateRef<any>, i : number) : void {
  this.i = i;
  this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
}

changeCss(id: string){
  var obj = <HTMLSelectElement>document.getElementById(id);
  obj.blur();
}

confirm(): void {

  this.modalRef?.hide();
  this.spinner.show();

  this.removerRedeSocial(this.i)

  this.spinner.hide();
}

decline(): void {
   this.modalRef?.hide();
}

 public saveChange() : void{

  this.spinner.show();

  if (this.form.valid){

    this.pessoaFisica = {...this.form.value};

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

    this.pessoaFisica.idUser = 6

    console.log(this.pessoaFisica)

     this.pessoaService.post(this.pessoaFisica).subscribe({
       next: (pessoa: PessoaFisica) => {
         this.toastr.success('Registro salvo com sucesso.', 'Sucesso')},
       error: (error: any) => {
         console.error(error);
         this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
       },
     }).add(() => this.spinner.hide());
   }
//   else{
//     this.toastr.error('Preencha os campos obrigatórios.', 'Atenção!')
//   }
// }

 }

}
