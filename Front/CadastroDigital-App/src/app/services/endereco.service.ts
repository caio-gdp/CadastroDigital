import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Endereco } from '@app/models/Endereco';
import { Observable, take } from 'rxjs';

@Injectable()
export class EnderecoService {

  baseUrl = 'https://viacep.com.br/ws'

  constructor(private http: HttpClient) { }

  public getByCep(cep : number) : Observable<Endereco>{
    return this.http.get<Endereco>(`${this.baseUrl}/${cep}/json/`).pipe(take(1));
  }

}
