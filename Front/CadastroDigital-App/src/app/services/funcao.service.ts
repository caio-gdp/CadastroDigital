import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Funcao } from '@app/models/Funcao';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FuncaoService {

  baseUrl = 'https://localhost:5001/api/funcao';

  constructor(private http: HttpClient) { }

  public getByCategoria(categoria : number) : Observable<Funcao[]>{
    return this.http.get<Funcao[]>(`${this.baseUrl}/${categoria}`).pipe(take(1));
  }

}
