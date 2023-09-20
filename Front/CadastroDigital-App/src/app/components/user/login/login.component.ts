import { Component } from '@angular/core';
import { FormControlName, FormGroup } from '@angular/forms';
import { enableDebugTools } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { UserLogin } from '@app/models/Identity/UserLogin';
import { Pessoa } from '@app/models/Pessoa';
import { AccountService } from '@app/services/account.service';
import { PessoaService } from '@app/services/pessoa.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  model = new UserLogin();
  loged = false;
  currentUser : any;

  //form!: FormGroup;

  constructor(private accountService : AccountService,
              private pessoaService : PessoaService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router){
                this.currentUser = accountService.currentUser$;

              }

  public login() : void{

    this.spinner.show();

    this.accountService.login(this.model).subscribe({
      next: () => {
        //this.toastr.success('Registro salvo com sucesso.', 'Sucesso')
        this.loged = true
        //this.router.navigate([`dashboard`]);
        this.router.navigate([`user/registration`]);
      },
      error: (error: any) => {
        console.log(error);
        console.error(error);
        if (error.status == 401)
          this.toastr.error("Usuário ou senha inválido")
      },
    }).add(() => this.spinner.hide());

  //   this.accountService.login(this.model).subscribe({
  //     next: (user : UserLogin)  => {this.router.navigateByUrl('/dashboard'); },
  //     error : (error: any) => {
  //       if (error.status == 401){alert(error.status);
  //         this.toastr.error("Usuário ou senha inválido");}

  //       else
  //         console.error(error);
  //     },
  // });

     //if (this.form.valid){
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
    //}
  }

}
