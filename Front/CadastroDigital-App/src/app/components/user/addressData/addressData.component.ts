import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { Cidade } from '@app/models/Cidade';
import { Endereco } from '@app/models/Endereco';
import { CidadeService } from '@app/services/cidade.service';
import { EnderecoService } from '@app/services/endereco.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Toast, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-addressData',
  templateUrl: './addressData.component.html',
  styleUrls: ['./addressData.component.scss']
})
export class AddressDataComponent implements OnInit {

  endereco = {} as Endereco;
  cidade = {} as Cidade;

  form!: FormGroup;

  get f() : any{
    return this.form.controls;
  }

  constructor(public fb : FormBuilder,
    private spinner: NgxSpinnerService,
    private toastr : ToastrService,
    private enderecoService : EnderecoService,
    private cidadeService: CidadeService,
    private ref: ChangeDetectorRef) { }

  ngOnInit() : void {
    this.validation();
  }

  cssValidation(filedForm: FormControl | AbstractControl): any {
    return {'is-invalid': filedForm.errors && filedForm.touched};
  }

  ngAfterContentChecked() {
    this.ref.detectChanges();
  }

  private validation() : void{
    this.form = this.fb.group({
      cep : ['', [Validators.required, Validators.minLength(8), Validators.maxLength(9)]],
      localidade: ['', [Validators.required]],
      uf : ['', [Validators.required]],
      logradouro : ['', [Validators.required, Validators.minLength(2), Validators.maxLength(150)]],
      numero : ['', [Validators.required]],
      complemento : [],
      bairro : ['', [Validators.required]]
    });
  }

  getByCep() : void {

    if (this.f.cep.value != undefined && this.f.cep.value != '' && this.f.cep.valid){
      var cep : number = this.f.cep.value;

      const observer = {
        next : (_endereco : Endereco) => {
            this.endereco = _endereco;
        },
        error : (error : any) =>
        {
          // this.spinner.hide(),
          // this.toastr.error('Erro ao carregar os registros.', "Erro!")
        },
        // complete : () => this.spinner.hide()
      };
      this.enderecoService.getByCep(cep).subscribe(observer);
    }
  }

  saveChange() : void{

    this.spinner.show();

    if (this.form.valid){

      this.endereco = {...this.form.value};



      //this.getCidadeByName();


      this.endereco.pessoafisicaId = 1

       console.log(this.endereco);

        this.enderecoService.post(this.endereco).subscribe({
          next: (endereco: Endereco) => {
            this.toastr.success('Registro salvo com sucesso.', 'Sucesso')},
          error: (error: any) => {
            console.error(error);
            this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
          },
        }).add(() => this.spinner.hide());
    }
  }

  // getCidadeByName() : void{

  //    const observer = {
  //      next : (_cidade : Cidade) => {
  //          this.cidade = _cidade;
  //          this.endereco.cidadeId = this.cidade.id;

  //          console.log(this.endereco);
  //      },
  //      error : (error : any) =>
  //      {
  //        // this.spinner.hide(),
  //        // this.toastr.error('Erro ao carregar os registros.', "Erro!")
  //      },
  //      // complete : () => this.spinner.hide()
  //    };
  //   this.cidadeService.getByName(this.f.cidade.value).subscribe(observer);
  // }
}
