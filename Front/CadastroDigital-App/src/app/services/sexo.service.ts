import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Sexo } from '@app/models/Sexo';
import { Observable, take } from 'rxjs';

@Injectable()
export class SexoService {

  baseUrl = 'https://localhost:5001/api/Sexo';

  constructor(private http: HttpClient) { }

  public get() : Observable<Sexo[]>{
    return this.http.get<Sexo[]>(this.baseUrl).pipe(take(1));
  }

}
