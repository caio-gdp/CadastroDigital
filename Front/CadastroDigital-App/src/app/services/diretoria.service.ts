import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Diretoria } from '@app/models/Diretoria';
import { Observable, take } from 'rxjs';

@Injectable()
export class DiretoriaService {

  baseUrl = 'https://localhost:5001/api/diretoria';

  constructor(private http: HttpClient) { }

  public get() : Observable<Diretoria[]>{
    return this.http.get<Diretoria[]>(this.baseUrl).pipe(take(1));
  }

}
