import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PessoaComponent } from './components/pessoa/pessoa.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ContatoComponent } from './components/contato/contato.component';
import { PerfilComponent } from './components/perfil/perfil.component';

const routes: Routes = [
  {  path : 'pessoa', component: PessoaComponent  },
  {  path : 'dashboard', component: DashboardComponent  },
  {  path : 'contato', component: ContatoComponent  },
  {  path : 'perfil', component: PerfilComponent  },
  {  path : '', redirectTo : 'dashboard', pathMatch : 'full'  }//,
  //{  path : '**', redirectTo : 'dashboard', pathMatch : 'full'  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
