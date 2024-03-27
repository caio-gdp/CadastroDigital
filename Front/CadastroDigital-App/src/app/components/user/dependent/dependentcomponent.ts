import { Component, OnInit, TemplateRef } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CssHelper } from '@app/helpers/CssHelper';
import { Beneficio } from '@app/models/Beneficio';
import { Dependente } from '@app/models/Dependente';
import { TipoParente } from '@app/models/TipoParente';
import { BeneficioService } from '@app/services/beneficio.service';
import { TipoParenteService } from '@app/services/tipoparente.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { BsDatepickerAbstractComponent } from 'ngx-bootstrap/datepicker/base/bs-datepicker-container';

@Component({
  selector: 'app-dependent',
  templateUrl: './dependent.component.html',
  styleUrls: ['./dependent.component.scss']
})
export class DependentComponent implements OnInit {

  form : FormGroup;
  index : number;
  beneficios : Beneficio[] = [];
  tiposParente : TipoParente[] = [];

  get f() : any{
    return this.form.controls;
  }

  get dependentes(): FormArray{
    return this.form.get('dependentes') as FormArray;
  }

  constructor(public fb : FormBuilder,
              private localeService: BsLocaleService,
              private modalService: BsModalService,
              private modalRef : BsModalRef,
              private spinner: NgxSpinnerService,
              private beneficioService : BeneficioService,
              private tipoParenteService: TipoParenteService) {
                this.localeService.use('pt-br');
              }

  ngOnInit() {
    this.validation();
    this.getBeneficio();
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

  public cssValidation(filedForm: FormControl | AbstractControl | null): any {
    return {'is-invalid': filedForm?.errors && filedForm?.touched};
  }

  private validation() : void{
    this.form = this.fb.group({
      dependentes: this.fb.array([])
    });
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

  getTipoParente(data : Event) : void{
      const observer = {
        next : (_tiposParente : TipoParente[]) => {
            this.tiposParente = _tiposParente;
        },
        error : (error : any) =>
        {
          // this.spinner.hide(),
          // this.toastr.error('Erro ao carregar os registros.', "Erro!")
        },
        // complete : () => this.tiposParente.slice(1,1)
      };
      this.tipoParenteService.get().subscribe(observer);
  }

  addDependente() : void{
     this.dependentes.push(this.criarDependente({id: 0} as Dependente));
  }

  criarDependente(dependente : Dependente): FormGroup | null {
    return this.fb.group({
      dataNascimento: [dependente.dataNascimento, [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      grauParentesco : [dependente.grauParentescoId, [Validators.required, this.checkAge]],
      nome: [dependente.nome, Validators.required],
      tipoDocumento:[],
      numeroDocumento:[],
    })
  }

  public checkAge(filedForm: FormControl | AbstractControl){

    if (filedForm.value != ""){

      const objData = <HTMLInputElement>document.getElementById('dataNascimento');

      if (objData?.value != undefined && objData?.value != ""){

         const dateParts = objData?.value.split("/");
         const date = new Date(+dateParts[2], +dateParts[1] - 1, +dateParts[0]);
         const anoNascimento = date.getFullYear();
         const anoAtual = new Date().getFullYear();

         const idade = (anoAtual - anoNascimento) - 1;

         switch (filedForm.value){
            case "1":
              if (idade > 18)
                return { filhoMaior: true };
              break;
            case "2":
              if (idade < 18)
                return { esposoMenor: true };
              break;
            case "3":
              if (idade > 18)
                return { tutelaMaior: true };
              break;
            case "4":
              if (idade > 18)
                return { enteadoMaior: true };
              break;
        }
      }
    }
    return null;
  }

  // public tituloDependente(nome: string) : string{
  //   console.log(nome)
  //    return this.dependentes.get(nome)?.value;

  // }

  openModal(template: TemplateRef<any>, i : number) : void {
    this.index = i;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {

    this.modalRef?.hide();
    this.spinner.show();

    this.removerDependente(this.index)

    this.spinner.hide();
  }

  decline(): void {
     this.modalRef?.hide();
  }

  removerDependente(i : number){
    this.dependentes.removeAt(i);
  }
}
