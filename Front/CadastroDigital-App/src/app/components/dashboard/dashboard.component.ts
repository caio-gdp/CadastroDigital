import { Component, OnInit } from '@angular/core';
import { Noticia } from '@app/models/Noticia';
import { NoticiaService } from '@app/services/noticia.service';
import { Constants } from '@app/utils/Constants';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {

  public noticias: Noticia[] = [];
  public larguraImagem : number = 1000;
  public margemImagem : number = 10;

  constructor(private noticiaService: NoticiaService) { }

  ngOnInit() {
    this.getNoticias();
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

}
