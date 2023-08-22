import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Beneficio } from '@app/models/Beneficio';
import { Observable, take } from 'rxjs';

@Injectable()
export class BeneficioService {

  baseUrl = 'https://localhost:5001/api/Beneficio';

  constructor(private http: HttpClient) { }

  public get(qtd : number) : Observable<Beneficio[]>{
    // return this.http.get<Noticia[]>(`${this.baseUrl}/${qtd}`).pipe(take(1));
    return this.http.get<Beneficio[]>(this.baseUrl).pipe(take(1));
  }

}
