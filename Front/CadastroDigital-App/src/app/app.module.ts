import { NgModule, CUSTOM_ELEMENTS_SCHEMA, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule, BsLocaleService } from 'ngx-bootstrap/datepicker';
import { AppRoutingModule } from './app-routing.module';

import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';

import { AppComponent } from './app.component';
import { PessoaComponent } from './components/pessoa/pessoa.component';
import { PessoaListaComponent } from './components/pessoa/pessoa-lista/pessoa-lista.component';
import { PessoaDetalheComponent } from './components/pessoa/pessoa-detalhe/pessoa-detalhe.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './shared/nav/nav.component';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { PessoaService } from './services/pessoa.service';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import { TituloComponent } from './shared/titulo/titulo.component';
import { ContatoComponent } from './components/contato/contato.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';
import { ProfileComponent } from './components/user/profile/profile.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MenuComponent } from './components/user/menu/menu.component';
import { AddressDataComponent } from './components/user/addressData/addressData.component';
//import { registerLocaleData } from '@angular/common';
//import localePT from '@angular/common/locales/pt';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { RECAPTCHA_V3_SITE_KEY, ReCaptchaV3Service, RecaptchaV3Module } from 'ng-recaptcha';
import { PersonalDataComponent } from './components/user/personalData/personalData.component';
import { OrgaoExpedidorService } from './services/orgaoexpedidor.service';
import { EstadoService } from './services/estado.service';
import { CidadeService } from './services/cidade.service';
import { PaisService } from './services/pais.service';
import { EstadoCivilService } from './services/estadocivil.service';
import { SexoService } from './services/sexo.service';
import { TipoRedeSocialService } from './services/tiporedesocial.service';
import { EnderecoService } from './services/endereco.service';
import { ProfissionalDataComponent } from './components/user/profissionalData/profissionalData.component';
import { DependentComponent } from './components/user/dependent/dependentcomponent';
import { AgregateComponent } from './components/user/agregate/agregate.component';
import { PhotoComponent } from './components/user/photo/photo.component';
import { DocumentsComponent } from './components/user/Documents/Documents.component';
import { FileComponent } from './components/user/File/File.component';
import { AssignComponent } from './components/user/assign/assign.component';
import { NoticiaService } from './services/noticia.service';
import { BeneficioService } from './services/beneficio.service';
import { ParceriaService } from './services/parceria.service';
import { PlaylistService } from './services/playlist.service';
import { PlaylistComponent } from './components/playlist/playlist.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { PessoaFisicaService } from './services/pessoafisica.service';
import { DiretoriaService } from './services/diretoria.service';
import { CategoriaService } from './services/categoria.service';
import { CargoService } from './services/cargo.service';
import { InformacaoProfissionalService } from './services/informacaoprofissional.service';

defineLocale('pt', ptBrLocale);
//registerLocaleData(localePT);
@NgModule({
  declarations: [
    AppComponent,
      PessoaComponent,
      PessoaListaComponent,
      PessoaDetalheComponent,
      NavComponent,
      DateTimeFormatPipe,
      ContatoComponent,
      DashboardComponent,
      TituloComponent,
      UserComponent,
      LoginComponent,
      RegistrationComponent,
      PersonalDataComponent,
      DependentComponent,
      AgregateComponent,
      ProfileComponent,
      MenuComponent,
      AddressDataComponent,
      ProfissionalDataComponent,
      PhotoComponent,
      DocumentsComponent,
      FileComponent,
      AssignComponent,
      PlaylistComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar : true
    }),
    NgxSpinnerModule,
    BsDatepickerModule.forRoot(),
    CarouselModule.forRoot(),
    NgxMaskDirective,
    NgxMaskPipe
  ],
  // providers: [{provide: PessoaService, useClass: PessoaService},
  //             {provide: provideNgxMask, useValue: provideNgxMask()},
  //             {provide: ReCaptchaV3Service , useValue: '6LfIjJ8mAAAAAP0yk5n375Dhu6BUnem_vQOeHqh-'}],
  providers: [PessoaService,
              PessoaFisicaService,
              OrgaoExpedidorService,
              EstadoService,
              CidadeService,
              PaisService,
              EstadoCivilService,
              SexoService,
              TipoRedeSocialService,
              EnderecoService,
              NoticiaService,
              BeneficioService,
              ParceriaService,
              DiretoriaService,
              CategoriaService,
              CargoService,
              InformacaoProfissionalService,
              PlaylistService,
              ReCaptchaV3Service,
              provideNgxMask(),
              {provide : HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
              {provide: RECAPTCHA_V3_SITE_KEY, useValue: '6LemiK8mAAAAADxKrc0KtYeWBNkzQsSXi4ujzh-E'}],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {
  constructor(private bsLocaleService: BsLocaleService) {
    this.bsLocaleService.use('pt');
    }
}
