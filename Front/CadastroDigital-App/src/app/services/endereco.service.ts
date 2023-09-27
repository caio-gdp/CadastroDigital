import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endereco } from '@app/models/Endereco';
import { Observable, take } from 'rxjs';

@Injectable()
export class EnderecoService {

  cepUrl = 'https://viacep.com.br/ws'
  baseUrl = 'https://localhost:5001/api/Endereco';

  constructor(private http: HttpClient) { }

  public getByCep(cep : number) : Observable<Endereco>{
    return this.http.get<Endereco>(`${this.cepUrl}/${cep}/json/`).pipe(take(1));
  }

  public post(endereco : Endereco) : Observable<Endereco>{
    return this.http.post<Endereco>(this.baseUrl, endereco).pipe(take(1));
  }

}
