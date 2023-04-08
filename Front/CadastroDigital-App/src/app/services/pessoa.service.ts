import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pessoa } from '../models/Pessoa';
import { PessoaFisica } from '../models/PessoaFisica';

@Injectable()
export class PessoaService {

  baseUrl = 'https://localhost:5001/api/Pessoa';

constructor(private http: HttpClient) { }

  public getPessoas() : Observable<Pessoa[]>{
    return this.http.get<Pessoa[]>(this.baseUrl);
  }

  public getPessoaById(id : number) : Observable<Pessoa>{
    return this.http.get<Pessoa>(`${this.baseUrl}/${id}}`);
  }

  public getPessoaByCpf(cpf : string) : Observable<PessoaFisica>{
    return this.http.get<PessoaFisica>(`${this.baseUrl}/${cpf}/cpf}`);
  }

  public getPessoaByNome(nome : string) : Observable<PessoaFisica>{
    return this.http.get<PessoaFisica>(`${this.baseUrl}/${nome}/nome}`);
  }
}
