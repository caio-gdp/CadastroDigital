import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TipoParente } from '@app/models/TipoParente';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TipoParenteService {

  baseUrl = 'https://localhost:5001/api/TipoParente';

  constructor(private http: HttpClient) { }

  public get() : Observable<TipoParente[]>{
    return this.http.get<TipoParente[]>(this.baseUrl).pipe(take(1));
  }

}
