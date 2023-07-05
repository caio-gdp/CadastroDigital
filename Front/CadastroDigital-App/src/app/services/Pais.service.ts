import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pais } from '@app/models/Pais';
import { Observable, take } from 'rxjs';

@Injectable()
export class PaisService {

  baseUrl = 'https://localhost:5001/api/Pais';

  constructor(private http: HttpClient) { }

  public getById(id : number) : Observable<Pais>{
    return this.http.get<Pais>(`${this.baseUrl}/${id}`).pipe(take(1));
  }
}
