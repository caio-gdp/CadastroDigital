import { Component } from '@angular/core';
import { FormControlName, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Pessoa } from '@app/models/Pessoa';
import { PessoaService } from '@app/services/pessoa.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  form!: FormGroup;

  constructor(private pessoaService : PessoaService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router){}

  login() : void{

     if (this.form.valid){
      // this.pessoaService.getPessoaByCpf(this.form.controls.login.value).subscribe({
      //   next: (pessoa: Pessoa) => {
      //     // this.toastr.success('Registro salvo com sucesso.', 'Sucesso')
      //     // this.toastr.info('Efetue o login para concluir o cadastro', 'Informação', {extendedTimeOut: 1000})
      //     this.router.navigate([`registration`]);
      //   },
      //   error: (error: any) => {
      //     console.log(error);
      //     console.error(error);
      //     this.toastr.error('Login inválido.', 'Erro!')
      //   },
      // }).add(() => this.spinner.hide());
    }
  }

}
