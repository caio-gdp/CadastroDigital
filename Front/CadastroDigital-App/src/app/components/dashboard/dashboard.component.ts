import { Component, OnInit } from '@angular/core';
import { Beneficio } from '@app/models/Beneficio';
import { Noticia } from '@app/models/Noticia';
import { Parceria } from '@app/models/Parceria';
import { PlayList } from '@app/models/playlist';
import { BeneficioService } from '@app/services/beneficio.service';
import { NoticiaService } from '@app/services/noticia.service';
import { ParceriaService } from '@app/services/parceria.service';
import { Constants } from '@app/utils/Constants';
import { LoginComponent } from '../user/login/login.component';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {

  public noticias: Noticia[] = [];
  public beneficios: Beneficio[] = [];
  public parcerias: Parceria[] = [];
  public larguraImagem : number = 1000;
  public margemImagem : number = 10;
  public templateNoticia : string;
  playList: PlayList;

  constructor(private noticiaService: NoticiaService,
              private beneficioService: BeneficioService,
              private parceriaService: ParceriaService,
              private loginComponent: LoginComponent) { }

  ngOnInit() {
    this.loginComponent.showLogin();
    this.getNoticias();
    this.getBeneficios();
    this.getParcerias();
  }

  public getNoticias() : void{
    const observer = {
      next : (_noticias : Noticia[]) => {
          this.noticias = _noticias;
          this.loadTemplateNoticias();
      },
      error : (error : any) =>
      {
        // this.spinner.hide(),
        // this.toastr.error('Erro ao carregar os registros.', "Erro!")
      },
      // complete : () => this.spinner.hide()
    };
    this.noticiaService.get(Constants.QTD_NOTICIAS).subscribe(observer);
  }

  public getBeneficios() : void{
    const observer = {
      next : (_beneficios : Beneficio[]) => {
          this.beneficios = _beneficios;
      },
      error : (error : any) =>
      {
        // this.spinner.hide(),
        // this.toastr.error('Erro ao carregar os registros.', "Erro!")
      },
      // complete : () => this.spinner.hide()
    };
    this.beneficioService.get().subscribe(observer);
  }

  public getParcerias() : void{
    const observer = {
      next : (_parcerias : Parceria[]) => {
          this.parcerias = _parcerias;
      },
      error : (error : any) =>
      {
        // this.spinner.hide(),
        // this.toastr.error('Erro ao carregar os registros.', "Erro!")
      },
      // complete : () => this.spinner.hide()
    };
    this.parceriaService.get(Constants.QTD_NOTICIAS).subscribe(observer);
  }

  public loadTemplateNoticias() : void{
    for (var i = 0; i < this.noticias.length; i++){
      if (i == 0){
        this.templateNoticia += '<h3>teste</h3>'+
                                '<div  class="block-area p-4">'+
                                '<div class="block-title-6">'+
                                  '<h4 class="h4 border-primary">'+
                                    '<span>Últimas Notícias</span>'+
                                  '</h4>'+
                                '</div>'+
                                '<div class="row">'+
                                 '<div class="flex-column col-lg-6">'+
                                    '<article class="card card-full mb-4 hover-a">'+
                                      '<div id="divImg" class="div_ratio_466-261 image-wrapper">'+
                                        '<a href="' + this.noticias[i].link + '">'+
                                          '<img class="img-fluid lazy img-md-not" src="../../assets/img/noticias/' + this.noticias[i].imagem + '">'+
                                        '</a>'+
                                      '</div>'+
                                      '<div class="card-body div-card-body-md-not">'+
                                        '<h2 class="card-title h1-sm h3-lg">'+
                                          '<a href="' + this.noticias[i].link + '" target="_blank">' + this.noticias[i].titulo + '"</a>'+
                                        '</h2>'+
                                        '<div class="card-text mb-2 text-muted small">'+
                                        '<span class="d-none d-sm-inline me-1">'+
                                          '<a class="fw-bold" href="#">"' + this.noticias[i].autor + '"</a>'+
                                        '</span>'+
                                        '<time>"' + this.noticias[i].data + '"</time>'+
                                        '<span title="9 comment" class="m-0 float-end">'+
                                          '<span class="icon-comments"></span>'+
                                        '</span>'+
                                      '</div>'+
                                      '<p class="card-text">"' + this.noticias[i].resumo + '"</p>'+
                                      '</div>'+
                                    '</article>'+
                                  '</div>'+
                                  '<div class="col-lg-6">'+
                                    '<div class="row">';

      }
      else{
        if (i < 5){
          this.templateNoticia +=     '<article class="col-6">'+
                                        '<div class="card card-full mb-4 hover-a">'+
                                          '<div class="ratio_165-92 image-wrapper">'+
                                            '<a href="' + this.noticias[i].link + '">'+
                                              '<img class="img-fluid lazy img-sm-not" src="../../assets/img/noticias/' + this.noticias[i].imagem + '">'+
                                            '</a>'+
                                          '</div>'+
                                          '<div class="card-body div-card-body-sm-not">'+
                                          '<h3 class="card-title h6 h5-sm h6-lg"><a href="' + this.noticias[i].link + '">"' + this.noticias[i].titulo + '"</a></h3>'+
                                            '<div class="card-text text-muted small">'+
                                              '<time>' + this.noticias[i].data + '</time>'+
                                            '</div>'+
                                          '</div>'+
                                        '</div>'+
                                      '</article>';


        }

        if (i == 4 || i == this.noticias.length){
                                    '</div>'+
                                  '</div>'+
                                '</div>'+
                              '</div>';
        }

      }
    }
  }

}
