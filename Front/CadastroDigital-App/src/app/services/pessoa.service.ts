import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Pessoa } from '../models/Pessoa';
import { PessoaFisica } from '../models/PessoaFisica';

@Injectable()
export class PessoaService {

  baseUrl = 'https://localhost:5001/api/Pessoa';

constructor(private http: HttpClient) { }

  public getPessoas() : Observable<Pessoa[]>{
    return this.http.get<Pessoa[]>(this.baseUrl).pipe(take(1));
  }

  public getPessoaById(id : number) : Observable<Pessoa>{
    return this.http.get<Pessoa>(`${this.baseUrl}/${id}`).pipe(take(1));
  }

  public getPessoaByCpf(cpf : string) : Observable<PessoaFisica>{
    return this.http.get<PessoaFisica>(`${this.baseUrl}/${cpf}/cpf}`).pipe(take(1));
  }

  public getPessoaByNome(nome : string) : Observable<PessoaFisica>{
    return this.http.get<PessoaFisica>(`${this.baseUrl}/${nome}/nome}`).pipe(take(1));
  }

  public post(pessoa : Pessoa) : Observable<Pessoa>{
    return this.http.post<Pessoa>(this.baseUrl, pessoa).pipe(take(1));
  }

  public put(id : number, pessoa : Pessoa) : Observable<Pessoa>{
    return this.http.put<Pessoa>(`${this.baseUrl}/${pessoa.id}`, pessoa).pipe(take(1));
  }

  public delete(id : number) : Observable<boolean>{
    return this.http.delete<boolean>(`${this.baseUrl}/${id}`).pipe(take(1));

  }
}