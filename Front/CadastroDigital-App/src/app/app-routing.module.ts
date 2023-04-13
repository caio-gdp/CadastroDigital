import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PessoaComponent } from './components/pessoa/pessoa.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ContatoComponent } from './components/contato/contato.component';
import { PessoaDetalheComponent } from './components/pessoa/pessoa-detalhe/pessoa-detalhe.component';
import { PessoaListaComponent } from './components/pessoa/pessoa-lista/pessoa-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { ProfileComponent } from './components/user/profile/profile.component';

const routes: Routes = [
  {
    path : 'user', component: UserComponent,
    children : [
      {  path : 'login', component: LoginComponent  },
      {  path : 'registration', component: RegistrationComponent  }
    ]
  },
  { path : 'user/profile', component: ProfileComponent  },
  { path : 'pessoa', redirectTo: 'pessoa/lista' },
  {
      path : 'pessoa', component: PessoaComponent,
    children : [
      {  path : 'detalhe/:id', component: PessoaDetalheComponent  },
      {  path : 'pessoa', component: PessoaComponent  },
      {  path : 'lista', component: PessoaListaComponent  }
    ]
  },
  {  path : 'dashboard', component: DashboardComponent  },
  {  path : 'contato', component: ContatoComponent  },
  {  path : '', redirectTo : 'dashboard', pathMatch : 'full'  },
  {  path : '**', redirectTo : 'dashboard', pathMatch : 'full'  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
