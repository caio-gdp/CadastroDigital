import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cargo } from '@app/models/Cargo';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CargoService {

  baseUrl = 'https://localhost:5001/api/cargo/centrocusto';

  constructor(private http: HttpClient) { }

  public getByCentroCusto(centroCusto : string) : Observable<Cargo>{
    return this.http.get<Cargo>(`${this.baseUrl}/${centroCusto}`).pipe(take(1));
  }

}
