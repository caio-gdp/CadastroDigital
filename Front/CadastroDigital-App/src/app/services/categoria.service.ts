import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categoria } from '@app/models/Categoria';
import { Observable, take } from 'rxjs';

@Injectable()
export class CategoriaService {

  baseUrl = 'https://localhost:5001/api/categoria';

  constructor(private http: HttpClient) { }

  public get() : Observable<Categoria[]>{
    return this.http.get<Categoria[]>(this.baseUrl).pipe(take(1));
  }

}
