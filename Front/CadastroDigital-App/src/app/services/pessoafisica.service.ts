import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PessoaFisica } from '@app/models/PessoaFisica';
import { Observable, take } from 'rxjs';

@Injectable()
export class PessoaFisicaService {

  baseUrl = 'https://localhost:5001/api/PessoaFisica';
  tokenHeader = new HttpHeaders({
      'Authorization': 'Bearer'
    });

  constructor(private http: HttpClient) { }

  public post(pessoaFisica : PessoaFisica) : Observable<PessoaFisica>{
    return this.http.post<PessoaFisica>(this.baseUrl, pessoaFisica).pipe(take(1));
  }

  public put(pessoaFisica : PessoaFisica) : Observable<PessoaFisica>{
    return this.http.put<PessoaFisica>(this.baseUrl, pessoaFisica).pipe(take(1));
  }

  public getPessoaByIdUser(idUser : number) : Observable<PessoaFisica>{
    return this.http.get<PessoaFisica>(`${this.baseUrl}/${idUser}`).pipe(take(1));
  }
}
