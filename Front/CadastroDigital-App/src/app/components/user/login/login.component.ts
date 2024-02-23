import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControlName, FormGroup } from '@angular/forms';
import { enableDebugTools } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { User } from '@app/models/Identity/User';
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
  firstName : string;
  jsonUser: any;
  user: any;


  constructor(public accountService : AccountService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService,
              private router: Router){
                this.currentUser = accountService.currentUser$;
              }

  ngOnInit() : void{

    //this.showLogin();
    this.jsonUser = localStorage.getItem('user');
    this.user = JSON.parse(this.jsonUser);
    this.setFirstName();
  }

  login() : void{

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

  logout() : void{
    this.accountService.logout();
    window.location.reload();
    this.router.navigate(['dashboard']);
  }

  setFirstName() : void{
    if (this.user != null){
      var index = this.user.name.indexOf(' ');
      this.firstName = this.user.name.substring(0,index);
    }
  }

  public showLogin() : void{
    if (this.user != null || this.user == undefined){
      let obj = <HTMLDivElement>document.getElementById("divLogin");
      obj.style.display = "";
    }
  }

  public hideLogin() : void{
    if (this.user != null || this.user == undefined){
      let obj = <HTMLDivElement>document.getElementById("divLogin");
      obj.style.display = "none";
    }
  }
}
