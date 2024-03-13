import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endereco } from '@app/models/Endereco';
import { Observable, take } from 'rxjs';

@Injectable()
export class EnderecoService {

  cepUrl = 'https://viacep.com.br/ws'
  baseUrl = 'https://localhost:5001/api/Endereco';
  tokenHeader = new HttpHeaders({
    'Authorization': 'Bearer'
  });

  constructor(private http: HttpClient) { }

  public getByCep(cep : number) : Observable<Endereco>{
    return this.http.get<Endereco>(`${this.cepUrl}/${cep}/json/`).pipe(take(1));
  }

  public post(idUser : number, endereco : Endereco) : Observable<Endereco>{
    return this.http.post<Endereco>(`${this.baseUrl}/${idUser}/`, endereco).pipe(take(1));
  }

  public put(idUser : number, endereco : Endereco) : Observable<Endereco>{
    return this.http.put<Endereco>(`${this.baseUrl}/${idUser}/`, endereco).pipe(take(1));
  }

  public getEndereco(id : number) : Observable<Endereco>{
    return this.http.get<Endereco>(`${this.baseUrl}/${id}/`).pipe(take(1));
  }

}
