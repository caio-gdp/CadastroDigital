import { Component, OnInit } from '@angular/core';
import { Beneficio } from '@app/models/Beneficio';
import { Noticia } from '@app/models/Noticia';
import { Parceria } from '@app/models/Parceria';
import { PlayList } from '@app/models/playlist';
import { BeneficioService } from '@app/services/beneficio.service';
import { NoticiaService } from '@app/services/noticia.service';
import { ParceriaService } from '@app/services/parceria.service';
import { Constants } from '@app/utils/Constants';

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
  playList: PlayList;

  constructor(private noticiaService: NoticiaService,
              private beneficioService: BeneficioService,
              private parceriaService: ParceriaService) { }

  ngOnInit() {
    this.getNoticias();
    this.getBeneficios();
    this.getParcerias();
  }

  public getNoticias() : void{
    const observer = {
      next : (_noticias : Noticia[]) => {
          this.noticias = _noticias;
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
    this.beneficioService.get(Constants.QTD_NOTICIAS).subscribe(observer);
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
}
