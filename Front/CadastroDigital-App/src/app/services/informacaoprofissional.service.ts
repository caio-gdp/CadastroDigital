import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { InformacaoProfissional } from '@app/models/InformacaoProfissional';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InformacaoProfissionalService {

  baseUrl = 'https://localhost:5001/api/InformacaoProfissional';
  tokenHeader = new HttpHeaders({
      'Authorization': 'Bearer'
    });

  constructor(private http: HttpClient) { }

  public post(id : number, informacaoProfissional : InformacaoProfissional) : Observable<InformacaoProfissional>{
    return this.http.post<InformacaoProfissional>(`${this.baseUrl}/${id}/`, informacaoProfissional).pipe(take(1));
  }

  public getInformacaoProfissional(id : number) : Observable<InformacaoProfissional>{
    return this.http.get<InformacaoProfissional>(`${this.baseUrl}/${id}/`).pipe(take(1));
  }

  // public getPessoaByIdUser(id : number) : Observable<PessoaFisica>{
  //   return this.http.get<PessoaFisica>(`${this.baseUrl}/${id}`).pipe(take(1));
  // }


}
