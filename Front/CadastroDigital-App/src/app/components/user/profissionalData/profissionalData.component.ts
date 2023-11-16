import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Cargo } from '@app/models/Cargo';
import { Categoria } from '@app/models/Categoria';
import { Diretoria } from '@app/models/Diretoria';
import { Funcao } from '@app/models/Funcao';
import { CargoService } from '@app/services/cargo.service';
import { CategoriaService } from '@app/services/categoria.service';
import { DiretoriaService } from '@app/services/diretoria.service';
import { FuncaoService } from '@app/services/funcao.service';
import { isUndefined } from 'ngx-bootstrap/chronos/utils/type-checks';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profissionalData',
  templateUrl: './profissionalData.component.html',
  styleUrls: ['./profissionalData.component.scss']
})
export class ProfissionalDataComponent implements OnInit {

  form : FormGroup;
  diretores: Diretoria[] = [];
  categorias: Categoria[] = [];
  funcoes: Funcao[] = [];
  cargo : Cargo;
  codigolocaltrabalho: string;

  get f() : any{
    return this.form.controls;
  }

  constructor(private fb : FormBuilder,
              private diretoriaService : DiretoriaService,
              private categoriaService : CategoriaService,
              private funcaoService : FuncaoService,
              private cargoService : CargoService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.codigolocaltrabalho = ""
    this.validation();
    this.getDiretor();
    this.getCategoria();
    this.form = new FormGroup({
      categoria : new FormControl(),
      centroCusto : new FormControl(),
      indicacao : new FormControl(),
      localTrabalho : new FormControl(),
      funcao : new FormControl()
    })
  }

  cssValidation(filedForm: FormControl | AbstractControl | null): any {
    return {'is-invalid': filedForm?.errors && filedForm?.touched};
  }

  private validation() : void{
    this.form = this.fb.group({
      indicacao : ['', [Validators.required]],
      categoria : ['', [Validators.required]],
      centroCusto : ['', [Validators.required, Validators.minLength(8), Validators.maxLength(10)]],
      localTrabalho : [''],
      funcao : ['']

    });
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

    var centroCusto = this.form.get('centroCusto');

    if (centroCusto?.value != ""){
      if (centroCusto?.value.length > 3){
        const observer = {
            next : (_cargo : Cargo) => {
                this.cargo = _cargo;
            },
            error : (error : any) =>
            {
              // this.spinner.hide(),
               this.toastr.error('Erro ao carregar os registros.', "Erro!")
            },
            // complete : () => this.spinner.hide()
          };
          this.cargoService.getByCentroCusto(centroCusto?.value).subscribe(observer);
       }
      }
  }

  public saveChange() : void{}

  public addFormCategoria() : void{

    var valor = this.f.categoria.value
    var objCentroCusto = document.getElementById('divCentroCusto');
    var objLocalTrabalho = document.getElementById('divLocalTrabalho');
    var objFuncao = document.getElementById('divFuncao');

    if (objCentroCusto != null && objFuncao != null && objLocalTrabalho != null){

      if (valor == 1)
      {
        objCentroCusto.style.display = '';
        objLocalTrabalho.style.display = '';
        objFuncao.style.display = '';
      }
      else if (valor == 2){
        objCentroCusto.style.display = 'none';
        objLocalTrabalho.style.display = 'none';
        objFuncao.style.display = '';
      }
      else{
        objCentroCusto.style.display = 'none';
        objLocalTrabalho.style.display = 'none';
        objFuncao.style.display = 'none';
      }
      this.getFuncao(valor);
    }
  }
}
