import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Parceria } from '@app/models/Parceria';
import { Observable, take } from 'rxjs';

@Injectable()
export class ParceriaService {

baseUrl = 'https://localhost:5001/api/parceria';

constructor(private http: HttpClient) { }

public get(qtd : number) : Observable<Parceria[]>{
  // return this.http.get<Noticia[]>(`${this.baseUrl}/${qtd}`).pipe(take(1));
  return this.http.get<Parceria[]>(this.baseUrl).pipe(take(1));
}

}
