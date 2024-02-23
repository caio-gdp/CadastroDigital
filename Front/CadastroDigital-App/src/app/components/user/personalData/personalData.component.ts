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
import { EstadoCivil } from '@app/models/EstadoCivil';
import { EstadoCivilService } from '@app/services/estadocivil.service';
import { Sexo } from '@app/models/Sexo';
import { SexoService } from '@app/services/sexo.service';
import { TipoRedeSocial } from '@app/models/TipoRedeSocial';
import { TipoRedeSocialService } from '@app/services/tiporedesocial.service';
import { RedesocialService } from '@app/services/redesocial.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { PessoaFisica } from '@app/models/PessoaFisica';
import { PessoaService } from '@app/services/pessoa.service';
import { HttpEvent } from '@angular/common/http';
import { PessoaFisicaService } from '@app/services/pessoafisica.service';
import { GenericValidator } from '@app/validators/GenericValidator';
import { AccountService } from '@app/services/account.service';
import { User } from '@app/models/Identity/User';
import { InformacaoProfissionalService } from '@app/services/informacaoprofissional.service';
import { PaisService } from '@app/services/pais.service';
import { Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-personalData',
  templateUrl: './personalData.component.html',
  styleUrls: ['./personalData.component.scss']
})
export class PersonalDataComponent implements OnInit {

  user : User;
  pessoaFisica = {} as PessoaFisica;
  orgaosExpedidores: OrgaoExpedidor[] = [];
  estados: Estado[] = [];
  cidades: Cidade[] = [];
  pais : Pais;
  estadosCivil: EstadoCivil[] = [];
  sexos: Sexo[] = [];
  redesSociaisRet: RedeSocial[] = [];
  tiposRedesSociais: TipoRedeSocial[] = [];
  index : number;
  currentUser : any;
  jsonUser: any;
  redeSocialId: number;

  form!: FormGroup;

  get f() : any{
    return this.form.controls;
  }

  get redesSociais(): FormArray{
    return this.form.get('redesSociais') as FormArray;
  }

  constructor(private fb : FormBuilder,
    private localeService: BsLocaleService,
    public accountService: AccountService,
    private pessoaFisicaService : PessoaFisicaService,
    private orgaoExpedidorService: OrgaoExpedidorService,
    private estadoService: EstadoService,
    private cidadeService: CidadeService,
    private paisService: PaisService,
    private estadoCivilService: EstadoCivilService,
    private sexoService: SexoService,
    //private redeSocialService : RedesocialService,
    private tipoRedeSocialService : TipoRedeSocialService,
    private modalService: BsModalService,
    private modalRef : BsModalRef,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router) {
      this.localeService.use('pt-br');
      this.currentUser = accountService.currentUser$;
    }

  ngOnInit() {

    this.validation();
    this.getOrgaoExpedidor();
    this.getEstado();
    this.getEstadoCivil();
    this.getSexo();
    this.getTipoRedeSocial();
    this.loadPersonalData();
  }

  cssValidation(filedForm: FormControl | AbstractControl | null): any {
    return {'is-invalid': filedForm?.errors && filedForm?.touched};
  }

  private validation() : void{
    this.form = this.fb.group({
      id: [],
      rg : ['', [Validators.required, Validators.minLength(8), Validators.maxLength(12)]],
      dataEmissao : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), this.checkDate]],
      orgaoExpedidorId : ['' , [Validators.required]],
      ufExpedidorId : ['', [Validators.required]],
      naturalidadeId : ['', [Validators.required]],
      nacionalidadeId : ['', [Validators.required]],
      estadoCivilId : ['', [Validators.required]],
      sexoId : ['', [Validators.required]],
      redesSociais: this.fb.array([
        // this.fb.group({
        //   id: [],
        //   pessoaId: [],
        //   tipoRedeSocialId: [],
        //   endereco: []
        //})
      ])
    });
  }

  loadPersonalData(): void{

    this.jsonUser = localStorage.getItem('user');
    this.user = JSON.parse(this.jsonUser);

    if (this.user != null){
      this.spinner.show()
      this.pessoaFisicaService.getPessoaByIdUser(this.user.id).subscribe(
        (personalDataRetorno: PessoaFisica) => {
          if (personalDataRetorno != null){
            this.pessoaFisica = personalDataRetorno
            this.pessoaFisica.id = personalDataRetorno.id;
            this.pessoaFisica.dataEmissao = new Date(this.pessoaFisica.dataEmissao).toLocaleDateString('pt-BR');
            this.form.patchValue(this.pessoaFisica);
            this.carregarRedesSociais(this.pessoaFisica.redesSociais);
            this.getCidade();
          }
        },
        (error: any) => {
          this.toastr.error('Erro ao carregar redes sociais.', "Erro!")
          console.log(error);
      },
      ).add(() => this.spinner.hide());
    }
  }

  checkDate(filedForm: FormControl | AbstractControl){

    if (filedForm.value != ""){
      const dateEmissao = new Date(filedForm.value);
      const dateAtual = new Date();

         if (dateEmissao > dateAtual)
           return { invalidDate: true } ;
    }
    return null;
  }

  addRedeSocial() : void{
    this.redesSociais.push(this.criarRedeSocial({id: 0} as RedeSocial));
  }

  criarRedeSocial(redeSocial : RedeSocial): FormGroup | null {
    return this.fb.group({
      id: [redeSocial.id],
      pessoaFisicaId: [redeSocial.pessoaFisicaId],
      tipoRedeSocialId: [redeSocial.tipoRedeSocialId, Validators.required],
      endereco: [redeSocial.endereco, Validators.required]
    })
  }

  carregarRedesSociais(redesSociais : RedeSocial[]): void{
    redesSociais.forEach(redeSocial => {
      this.redesSociais.push(this.criarRedeSocial(redeSocial));
    })
  }

  removerRedeSocial(i : number, redeSocialId: number){

    // this.redeSocialService.deleteRedeSocial(redeSocialId).subscribe(
    //   (result: boolean) => {
    //     if(result){
    //       this.toastr.success('Registro excluído com sucesso.', 'Sucesso');
    //       this.loadPersonalData()
    //     }
    //   },
    //   (error: any) => {
    //     this.toastr.error('Erro ao excluir o registro.', "Erro!")
    //   },
    //   () => {},
    // );

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

getOrgaoExpedidor() : void{
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

getEstado() : void{

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

getCidade() : void{

  var obj = (<HTMLSelectElement>document.getElementById("ufExpedidorId"));
  var estado : number = +(<HTMLOptionElement>obj[obj.options.selectedIndex])?.value;

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
  this.cidadeService.getByEstado(estado).subscribe(observer);

  this.changeCss('ufExpedidorId');
}

getPais(id : number) : void{
   const observer = {
     next : (_pais : Pais) => {
         this.pais = _pais;
     },
     error : (error : any) =>
     {
       // this.spinner.hide(),
       this.toastr.error('Erro ao carregar os registros.', "Erro!")
     },
     // complete : () => this.spinner.hide()
   };
  this.paisService.getById(id).subscribe(observer);
  this.form.controls['nacionalidadeId'].value == id;

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

// getRedeSocial(userId : number) : void{
//   const observer = {
//     next : (_redesSociais : RedeSocial[]) => {
//       this.redesSociais = _redesSociais;

//     },
//     error : (error : any) =>
//     {
//       // this.spinner.hide(),
//       // this.toastr.error('Erro ao carregar os registros.', "Erro!")
//     },
//     // complete : () => this.spinner.hide()
//   };
//   this.redeSocialService.getRedeSocialByUserId(userId).subscribe(observer);
// }

getTipoRedeSocial() : void{

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

openModal(template: TemplateRef<any>, redeSocialId : number) : void {
  //event.stopPropagation();
  //this.redeSocialId = redeSocialId;
  this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
}

changeCss(id: string){
  var obj = <HTMLSelectElement>document.getElementById(id);
  obj.blur();
}

confirm(): void {

  this.modalRef?.hide();
  this.spinner.show();

  this.removerRedeSocial(this.index, this.redeSocialId)

  this.spinner.hide();
}

decline(): void {
   this.modalRef?.hide();
}

 public saveChange() : void{

  this.spinner.show();

  if (this.form.valid){

    this.pessoaFisica = {...this.form.value};
    this.pessoaFisica.orgaoExpedidorId = Number(this.pessoaFisica.orgaoExpedidorId);
    this.pessoaFisica.ufExpedidorId = Number(this.pessoaFisica.ufExpedidorId);
    this.pessoaFisica.naturalidadeId = Number(this.pessoaFisica.naturalidadeId);
    this.pessoaFisica.nacionalidadeId = Number(this.pessoaFisica.nacionalidadeId);
    this.pessoaFisica.estadoCivilId = Number(this.pessoaFisica.estadoCivilId);
    this.pessoaFisica.sexoId = Number(this.pessoaFisica.sexoId);

    if (this.pessoaFisica.redesSociais != undefined){
      for (let i = 0; i < this.pessoaFisica.redesSociais.length; i++){
        this.pessoaFisica.redesSociais[i].pessoaFisicaId = 0;
        this.pessoaFisica.redesSociais[i].tipoRedeSocialId = Number(this.pessoaFisica.redesSociais[i].tipoRedeSocialId);
      }
    }

    if (this.user != null)
      this.pessoaFisica.idUser = this.user.id;

    if (this.pessoaFisica.id == null || this.pessoaFisica.id == 0){
      console.log(this.pessoaFisica)
      this.pessoaFisica.id = 0;
      this.pessoaFisicaService.post(this.pessoaFisica).subscribe({
        next: (pessoa: PessoaFisica) => {
          this.toastr.success('Registro salvo com sucesso.', 'Sucesso');
          this.router.navigateByUrl('user/addressData');
        },
        error: (error: any) => {
          console.error(error);
          this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
        },
      }).add(() => this.spinner.hide());
    }
    else{
      console.log(this.pessoaFisica.redesSociais)
      for(let i = 0; i < this.pessoaFisica.redesSociais.length; i++){

        if(this.pessoaFisica.redesSociais[i].id == null || this.pessoaFisica.redesSociais[i].id == 0){
          this.pessoaFisica.redesSociais[i].id = 0;
          this.pessoaFisica.redesSociais[i].pessoaFisicaId = this.pessoaFisica.id;
        }
      }

      this.pessoaFisicaService.put(this.pessoaFisica).subscribe({
        next: (pessoa: PessoaFisica) => {
          this.toastr.success('Registro atualizado com sucesso.', 'Sucesso');
          this.router.navigateByUrl('user/personalData');
        },
        error: (error: any) => {
          console.error(error);
          this.toastr.error('Erro ao tentar atualizar o registro.', 'Erro!')
        },
      }).add(() => this.spinner.hide());
    }

  }
//   else{
//     this.toastr.error('Preencha os campos obrigatórios.', 'Atenção!')
//   }
// }
 }
}
