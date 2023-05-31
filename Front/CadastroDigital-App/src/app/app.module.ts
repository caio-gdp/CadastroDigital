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
import { AddressComponent } from './components/user/address/address.component';
import { registerLocaleData } from '@angular/common';
import localePT from '@angular/common/locales/pt';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';

defineLocale('pt-BR', ptBrLocale);
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
      ProfileComponent,
      MenuComponent,
      AddressComponent
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
  providers: [PessoaService, provideNgxMask()],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
