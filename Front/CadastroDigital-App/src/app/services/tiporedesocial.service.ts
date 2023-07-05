import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TipoRedeSocial } from '@app/models/TipoRedeSocial';
import { Observable, take } from 'rxjs';

@Injectable()
export class TipoRedeSocialService {

  baseUrl = 'https://localhost:5001/api/TipoRedeSocial';

  constructor(private http: HttpClient) { }

  public get() : Observable<TipoRedeSocial[]>{
    return this.http.get<TipoRedeSocial[]>(this.baseUrl).pipe(take(1));
  }

}
