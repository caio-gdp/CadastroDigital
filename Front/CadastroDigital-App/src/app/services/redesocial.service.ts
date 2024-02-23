import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RedeSocial } from '@app/models/RedeSocial';
import { Observable, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RedesocialService {

  baseUrl = 'https://localhost:5001/api/RedeSocial';

  constructor(private http: HttpClient) { }

  public getRedesSociais() : Observable<RedeSocial[]>{
    return this.http.get<RedeSocial[]>(this.baseUrl).pipe(take(1));
  }

  public getRedeSocialByUserId(userId: number) : Observable<RedeSocial[]>{
    return this.http.get<RedeSocial[]>(`${this.baseUrl}/${userId}`).pipe(take(1));
  }

  public deleteRedeSocial(id: number) : Observable<RedeSocial[]>{
    return this.http.delete<RedeSocial[]>(`${this.baseUrl}/${id}`).pipe(take(1));
  }

}


