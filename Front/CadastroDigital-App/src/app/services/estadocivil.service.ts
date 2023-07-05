import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EstadoCivil } from '@app/models/EstadoCivil';
import { Observable, take } from 'rxjs';

@Injectable()
export class EstadoCivilService {

  baseUrl = 'https://localhost:5001/api/EstadoCivil';

  constructor(private http: HttpClient) { }

  public get() : Observable<EstadoCivil[]>{
    return this.http.get<EstadoCivil[]>(this.baseUrl).pipe(take(1));
  }

}
