import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Noticia } from '@app/models/Noticia';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NoticiaService {

  baseUrl = 'https://localhost:5001/api/Noticia';

  constructor(private http: HttpClient) { }

  public get(qtd : number) : Observable<Noticia[]>{
    // return this.http.get<Noticia[]>(`${this.baseUrl}/${qtd}`).pipe(take(1));
    return this.http.get<Noticia[]>(this.baseUrl).pipe(take(1));
  }
}
