import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from '@app/models/Login';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseUrl = 'https://localhost:5001/api/user/login';

  constructor(private http: HttpClient) { }

  public get(qtd : number) : Observable<Login[]>{
    // return this.http.get<Noticia[]>(`${this.baseUrl}/${qtd}`).pipe(take(1));
    return this.http.get<Login[]>(this.baseUrl).pipe(take(1));
  }

}
