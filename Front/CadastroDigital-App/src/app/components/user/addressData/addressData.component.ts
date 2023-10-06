import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { Cidade } from '@app/models/Cidade';
import { Endereco } from '@app/models/Endereco';
import { User } from '@app/models/Identity/User';
import { AccountService } from '@app/services/account.service';
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
  currentUser : any;
  jsonUser: any;
  user : User;

  form!: FormGroup;

  get f() : any{
    return this.form.controls;
  }

  constructor(public fb : FormBuilder,
    public accountService: AccountService,
    private spinner: NgxSpinnerService,
    private toastr : ToastrService,
    private enderecoService : EnderecoService,
    private cidadeService: CidadeService,
    private ref: ChangeDetectorRef) {
      this.currentUser = accountService.currentUser$;

    }

  ngOnInit() : void {
    this.validation();
    this.loadAddressData();
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

  loadAddressData() : void{
    this.jsonUser = localStorage.getItem('user');
    this.user = JSON.parse(this.jsonUser);

    if (this.user != null){
      this.spinner.show()
      this.enderecoService.getEndereco(this.user.id).subscribe(
        (enderecoRetorno: Endereco) => {
          this.endereco = enderecoRetorno
          console.log(this.endereco)
          this.form.patchValue(this.endereco);
        },
        (error: any) => {
          console.log(error)
          this.toastr.error('Endereço não carregado')
      },
      ).add(() => this.spinner.hide());
    }



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

       console.log(this.endereco);

        this.enderecoService.post(this.user.id, this.endereco).subscribe({
          next: (endereco: Endereco) => {
            this.toastr.success('Registro salvo com sucesso.', 'Sucesso')},
          error: (error: any) => {
            console.error(error);
            this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
          },
        }).add(() => this.spinner.hide());
    }
  }

}
