import { Component, OnInit } from '@angular/core';
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
export class LoginComponent implements OnInit {

  model = {} as UserLogin;
  currentUser : any;

  constructor(public accountService : AccountService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router){
                this.currentUser = accountService.currentUser$;
              }

  ngOnInit() : void{
  }

  public login() : void{

    this.spinner.show();

    this.accountService.login(this.model).subscribe({
      next: () => {
        this.toastr.success('Login efetuado com sucesso.', 'Sucesso');
        this.router.navigateByUrl('dashboard');
      },
      error: (error: any) => {
        console.log(error);
        console.error(error);
        if (error.status == 401)
          this.toastr.error("Usuário ou senha inválido")
        else
          this.toastr.error("Erro ao tentar efetuar login")
      },
    }).add(() => this.spinner.hide());
  }

  public logout() : void{
    this.accountService.logout();
    window.location.reload();
  }
}
