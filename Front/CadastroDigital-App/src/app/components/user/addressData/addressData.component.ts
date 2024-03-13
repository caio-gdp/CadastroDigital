import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { AbstractControl, AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { Cidade } from '@app/models/Cidade';
import { Endereco } from '@app/models/Endereco';
import { User } from '@app/models/Identity/User';
import { AccountService } from '@app/services/account.service';
import { CidadeService } from '@app/services/cidade.service';
import { EnderecoService } from '@app/services/endereco.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Toast, ToastrService } from 'ngx-toastr';
import { LoginComponent } from '../login/login.component';

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
    private ref: ChangeDetectorRef,
    private router : Router,
    private loginComponent : LoginComponent) {
      this.currentUser = accountService.currentUser$;

    }

  ngOnInit() : void {
    this.loginComponent.hideLogin();
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
      id: [],
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

    this.spinner.show();

    this.jsonUser = localStorage.getItem('user');
    this.user = JSON.parse(this.jsonUser);

    if (this.user != null){
      this.enderecoService.getEndereco(this.user.id).subscribe(
        (enderecoRetorno: Endereco) => {
          //alert("enderecoRetorno: " + enderecoRetorno)
          if (enderecoRetorno != null){
            this.endereco = enderecoRetorno
            console.log(this.endereco)
            this.form.patchValue(this.endereco);
          }
        },
        (error: any) => {
          console.error(error);
            this.toastr.error('Erro ao tentar carregar o endereço cadastrado.', 'Erro!')
      },
      ).add(() => this.spinner.hide());
    }
  }

  getByCep() : void {

    this.spinner.show();

    if (this.f.cep.value != undefined && this.f.cep.value != '' && this.f.cep.valid){
      var cep : number = this.f.cep.value;

      const observer = {
        next : (_endereco : Endereco) => {
            this.endereco = _endereco;
        },
        error : (error : any) =>
        {
           this.spinner.hide(),
           this.toastr.error('Erro ao carregar o cep.', "Erro!")
        },
         complete : () => this.spinner.hide()
      };
      this.enderecoService.getByCep(cep).subscribe(observer);
    }
  }

  saveChange() : void{

    this.spinner.show();

    if (this.form.valid){

      this.endereco = {...this.form.value};

       if (this.endereco.id == null){
        this.endereco.id = 0;
        this.enderecoService.post(this.user.id, this.endereco).subscribe({
          next: (endereco: Endereco) => {
            this.toastr.success('Registro incluído com sucesso.', 'Sucesso');
            this.router.navigateByUrl('user/profissionalData')
          },
          error: (error: any) => {
            console.error(error);
            this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
          },
        }).add(() => this.spinner.hide());
       }
       else{
        this.enderecoService.put(this.user.id, this.endereco).subscribe({
          next: (endereco: Endereco) => {
            this.toastr.success('Registro alterado com sucesso.', 'Sucesso');
            this.router.navigateByUrl('user/addressData')
          },
          error: (error: any) => {
            console.error(error);
            this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
          },
        }).add(() => this.spinner.hide());
       }
    }
  }

  cancelChange(){
    this.loginComponent.showLogin();
    this.router.navigateByUrl("dashboard")
  }
}
