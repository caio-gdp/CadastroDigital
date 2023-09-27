import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cidade } from '@app/models/Cidade';
import { Observable, take } from 'rxjs';

@Injectable()
export class CidadeService {

  baseUrl = 'https://localhost:5001/api/Cidade';

  constructor(private http: HttpClient) { }

  public getByEstado(estado : number) : Observable<Cidade[]>{
    return this.http.get<Cidade[]>(`${this.baseUrl}/estado/${estado}`).pipe(take(1));
  }

  public getByName(cidade : string) : Observable<Cidade>{
    return this.http.get<Cidade>(`${this.baseUrl}/cidade/${cidade}`).pipe(take(1));
  }
}
