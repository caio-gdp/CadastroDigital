import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Estado } from '@app/models/Estado';
import { Observable, take } from 'rxjs';

@Injectable()
export class EstadoService {

  baseUrl = 'https://localhost:5001/api/Estado';

  constructor(private http: HttpClient) { }

  public get() : Observable<Estado[]>{
    return this.http.get<Estado[]>(this.baseUrl).pipe(take(1));
  }

}
