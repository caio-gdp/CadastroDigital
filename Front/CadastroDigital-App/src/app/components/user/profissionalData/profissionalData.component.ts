import { Element } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CssHelper } from '@app/helpers/CssHelper';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { Beneficio } from '@app/models/Beneficio';
import { Cargo } from '@app/models/Cargo';
import { Categoria } from '@app/models/Categoria';
import { Diretoria } from '@app/models/Diretoria';
import { Funcao } from '@app/models/Funcao';
import { User } from '@app/models/Identity/User';
import { InformacaoProfissional } from '@app/models/InformacaoProfissional';
import { AccountService } from '@app/services/account.service';
import { BeneficioService } from '@app/services/beneficio.service';
import { CargoService } from '@app/services/cargo.service';
import { CategoriaService } from '@app/services/categoria.service';
import { DiretoriaService } from '@app/services/diretoria.service';
import { FuncaoService } from '@app/services/funcao.service';
import { InformacaoProfissionalService } from '@app/services/informacaoprofissional.service';
import { isUndefined } from 'ngx-bootstrap/chronos/utils/type-checks';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profissionalData',
  templateUrl: './profissionalData.component.html',
  styleUrls: ['./profissionalData.component.scss']
})
export class ProfissionalDataComponent implements OnInit {

  form!: FormGroup;
  formPMS!: FormGroup;
  diretores: Diretoria[] = [];
  categorias: Categoria[] = [];
  funcoes: Funcao[] = [];
  beneficios : Beneficio[] = [];
  cargo : Cargo;
  localtrabalho: string;
  informacaoProfissional : InformacaoProfissional;
  user : User;
  currentUser : any;
  jsonUser: any;

  get f() : any{
    return this.form.controls;
  }

  constructor(private fb : FormBuilder,
              public accountService: AccountService,
              private diretoriaService : DiretoriaService,
              private categoriaService : CategoriaService,
              private funcaoService : FuncaoService,
              private cargoService : CargoService,
              private beneficioService : BeneficioService,
              private informacaoProfissionalService : InformacaoProfissionalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router : Router) {
                this.currentUser = accountService.currentUser$;
               }

  ngOnInit() {
    this.validation();
    this.localtrabalho = "";
    this.getDiretor();
    this.getCategoria();
    this.getBeneficio();
    this.loadProfissionalData();
  }

  cssValidation(filedForm: FormControl | AbstractControl | null): any {
    return {'is-invalid': filedForm?.errors && filedForm?.touched};
  }

  private validation() : void{

    const formOptions : AbstractControlOptions = {
      validators : ValidatorField.formPMS('registro', 'centroCusto', 'cargoId', 'funcaoId', 'categoriaId')
    }

    this.form = this.fb.group({
      indicacaoId : ['', [Validators.required]],
      categoriaId : ['', [Validators.required]],
      registro : [''],
      centroCusto : [''],
      cargoId : [''],
      funcaoId : ['']
    },formOptions);
  }

  loadProfissionalData() : void{
    this.jsonUser = localStorage.getItem('user');
    this.user = JSON.parse(this.jsonUser);

    if (this.user != null){
      this.informacaoProfissionalService.getInformacaoProfissional(this.user.id).subscribe(
        (retorno: InformacaoProfissional) => {
          this.informacaoProfissional = retorno
          this.form.patchValue(this.informacaoProfissional);
        },
        (error: any) => {
      },
      ).add();
    }
  }

  getDiretor() : void{
    const observer = {
      next : (_diretores : Diretoria[]) => {
          this.diretores = _diretores;
      },
      error : (error : any) =>
      {
        // this.spinner.hide(),
        // this.toastr.error('Erro ao carregar os registros.', "Erro!")
      },
      // complete : () => this.spinner.hide()
    };
    this.diretoriaService.get().subscribe(observer);
  }

  getCategoria() : void{
    const observer = {
      next : (_categorias : Categoria[]) => {
          this.categorias = _categorias;
      },
      error : (error : any) =>
      {
        // this.spinner.hide(),
        // this.toastr.error('Erro ao carregar os registros.', "Erro!")
      },
      // complete : () => this.spinner.hide()
    };
    this.categoriaService.get().subscribe(observer);
  }

  getFuncao(categoria : number) : void{

    const observer = {
      next : (_funcoes : Funcao[]) => {
          if(categoria == 1){

            for(var i = 0; i < _funcoes.length; i++){
              _funcoes[i].descricao = " - " +  _funcoes[i].descricao;
            }
          }
          this.funcoes = _funcoes;
      },
      error : (error : any) =>
      {
        // this.spinner.hide(),
        // this.toastr.error('Erro ao carregar os registros.', "Erro!")
      },
      // complete : () => this.spinner.hide()
    };
    this.funcaoService.getByCategoria(categoria).subscribe(observer);
  }

  getLocalTrabalho() : void{

    let centroCusto = this.form.get('centroCusto')?.value;
    let centroCustoForm = "";

    // if (centroCusto.length < 2)
    //   centroCustoForm = centroCusto

    if (centroCusto.length == 2)
      centroCustoForm = centroCusto + ".";

    if (centroCusto.length == 4)
      centroCustoForm = centroCusto.substring(0,2) + "." + centroCusto.substring(2,4) + ".";

    if (centroCusto.length == 6)
      centroCustoForm = centroCusto.substring(0,2) + "." + centroCusto.substring(2,4) + "." + centroCusto.substring(4,6) + ".";

    if (centroCusto.length == 8)
      centroCustoForm = centroCusto.substring(0,2) + "." + centroCusto.substring(2,4) + "." + centroCusto.substring(4,6) + "." + centroCusto.substring(6,8);

      if (centroCustoForm != ""){
      this.localtrabalho = "";
      if (centroCusto.length > 4){
        this.spinner.show();
        const observer = {
            next : (_cargo : Cargo) => {
                this.cargo = _cargo;
                this.localtrabalho = this.cargo.codigoLocalTrabalho  + " - " + this.cargo.nomeLocalTrabalho
            },
            error : (error : any) =>
            {
              this.localtrabalho = ""
              this.spinner.hide()
              // this.toastr.error('Erro ao carregar os registros.', "Erro!")
            },
            complete : () => this.spinner.hide()
          };
          this.cargoService.getByCentroCusto(centroCustoForm).subscribe(observer);
       }
      }
  }

  getBeneficio() : void{
    const observer = {
      next : (_beneficios : Beneficio[]) => {
          this.beneficios = _beneficios;
      },
      error : (error : any) =>
      {
        // this.spinner.hide(),
        // this.toastr.error('Erro ao carregar os registros.', "Erro!")
      },
      // complete : () => this.spinner.hide()
    };
    this.beneficioService.get().subscribe(observer);
  }

  public saveChange() : void{

    this.spinner.show();

    if (this.form.valid){

      this.informacaoProfissional = {...this.form.value};

      if (this.user != null){
         //this.informacaoProfissional.pessoaFisicaId = this.user.id;

      // console.log(this.pessoaFisica)

        this.informacaoProfissionalService.post(this.user.id, this.informacaoProfissional).subscribe({
          next: (informacaoProfissional: InformacaoProfissional) => {
            this.toastr.success('Registro salvo com sucesso.', 'Sucesso');
            this.router.navigateByUrl('user/dependent');
          },
          error: (error: any) => {
            console.error(error);
            this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
          },
        }).add(() => this.spinner.hide());
     }
     else{
       this.toastr.error('Usuário não logado.', 'Atenção!');
       this.spinner.hide();
     }
    }
  }

  public addFormCategoria() : void{

    let valor = this.f.categoriaId.value
    let objRegistro = document.getElementById('divRegistro');
    let objCentroCusto = document.getElementById('divCentroCusto');
    let objLocalTrabalho = document.getElementById('divLocalTrabalho');
    let objFuncao = document.getElementById('divFuncao');

    if (objRegistro != null && objCentroCusto != null && objFuncao != null && objLocalTrabalho != null){

      if (valor == 1)
      {
        objRegistro.style.display = '';
        objCentroCusto.style.display = '';
        objLocalTrabalho.style.display = '';
        objFuncao.style.display = '';
      }
      else if (valor == 2){
        objRegistro.style.display = '';
        objCentroCusto.style.display = 'none';
        objLocalTrabalho.style.display = 'none';
        objFuncao.style.display = '';
      }
      else if (valor == 3 || valor == 4){
        objRegistro.style.display = '';
        objCentroCusto.style.display = 'none';
        objLocalTrabalho.style.display = 'none';
        objFuncao.style.display = 'none';
      }
      else{
        objRegistro.style.display = 'none';
        objCentroCusto.style.display = 'none';
        objLocalTrabalho.style.display = 'none';
        objFuncao.style.display = 'none';
      }
      this.getFuncao(valor);
    }
  }

  public changeFColor(obj: string){
    CssHelper.changeFColor(obj);
  }

  public changeBColor(obj: string){
    CssHelper.changeBColor(obj);
  }
}
