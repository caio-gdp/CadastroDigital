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
import { NavComponent } from './shared/nav/nav.component';
import { AddressDataComponent } from './components/user/addressData/addressData.component';
import { SobreComponent } from './components/sobre/sobre.component';
import { NoticiaComponent } from './components/noticia/noticia.component';
import { BeneficioComponent } from './components/beneficio/beneficio.component';
import { ConvenioComponent } from './components/convenio/convenio.component';
import { ServicoComponent } from './components/servico/servico.component';
import { PersonalDataComponent } from './components/user/personalData/personalData.component';
import { ProfissionalDataComponent } from './components/user/profissionalData/profissionalData.component';
import { DependentComponent } from './components/user/dependent/dependentcomponent';
import { AgregateComponent } from './components/user/agregate/agregate.component';
import { PhotoComponent } from './components/user/photo/photo.component';
import { DocumentsComponent } from './components/user/Documents/Documents.component';
import { FileComponent } from './components/user/File/File.component';
import { AssignComponent } from './components/user/assign/assign.component';

const routes: Routes = [
  {
    path : 'user', component: UserComponent,
    children : [
      {  path : 'login', component: LoginComponent  },
      {  path : 'registration', component: RegistrationComponent  },
      {  path : 'personalData', component: PersonalDataComponent  },
      {  path : 'addressData', component: AddressDataComponent  },
      {  path : 'profissionalData', component: ProfissionalDataComponent  },
      {  path : 'dependent', component: DependentComponent  },
      {  path : 'agregate', component: AgregateComponent },
      {  path : 'photo', component: PhotoComponent },
      {  path : 'documents', component: DocumentsComponent },
      {  path : 'file', component: FileComponent },
      {  path : 'assign', component: AssignComponent },
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
  {  path : 'sobre', component: SobreComponent  },
  {  path : 'noticia', component: NoticiaComponent  },
  {  path : 'beneficio', component: BeneficioComponent  },
  {  path : 'convenio', component: ConvenioComponent  },
  {  path : 'servico', component: ServicoComponent  },
  {  path : 'contato', component: ContatoComponent  },
  {  path : '', redirectTo : 'dashboard', pathMatch : 'full'  },
  {  path : '**', redirectTo : 'dashboard', pathMatch : 'full'  },
  {  path : 'nav', component: NavComponent  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
