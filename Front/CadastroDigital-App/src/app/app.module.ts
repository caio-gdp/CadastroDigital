import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PessoaComponent } from './components/pessoa/pessoa.component';
import { PessoaListaComponent } from './components/pessoa/pessoa-lista/pessoa-lista.component';
import { PessoaDetalheComponent } from './components/pessoa/pessoa-detalhe/pessoa-detalhe.component';
import { HttpClientModule } from '@angular/common/http';
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
import { registerLocaleData } from '@angular/common';
import localePT from '@angular/common/locales/pt';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
import { RECAPTCHA_V3_SITE_KEY, ReCaptchaV3Service, RecaptchaV3Module } from 'ng-recaptcha';
import { PersonalDataComponent } from './components/user/personalData/personalData.component';
import { OrgaoExpedidorService } from './services/orgaoexpedidor.service';
import { EstadoService } from './services/estado.service';
import { CidadeService } from './services/cidade.service';
import { PaisService } from './services/Pais.service';
import { EstadoCivilService } from './services/estadocivil.service';
import { SexoService } from './services/sexo.service';
import { TipoRedeSocialService } from './services/tiporedesocial.service';
import { EnderecoService } from './services/endereco.service';
import { ProfissionalDataComponent } from './components/user/profissionalData/profissionalData.component';
import { DependentComponent } from './components/user/dependent/dependentcomponent';
import { AgregateComponent } from './components/user/agregate/agregate.component';

defineLocale('pt-br', ptBrLocale);
registerLocaleData(localePT);
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
      ProfissionalDataComponent
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
              OrgaoExpedidorService,
              EstadoService,
              CidadeService,
              PaisService,
              EstadoCivilService,
              SexoService,
              TipoRedeSocialService,
              EnderecoService,
              ReCaptchaV3Service,
              provideNgxMask(),
              {provide: RECAPTCHA_V3_SITE_KEY, useValue: '6LemiK8mAAAAADxKrc0KtYeWBNkzQsSXi4ujzh-E'}],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
