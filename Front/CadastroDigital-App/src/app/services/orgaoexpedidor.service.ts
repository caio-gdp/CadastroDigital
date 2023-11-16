import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrgaoExpedidor } from '@app/models/OrgaoExpedidor';
import { Observable, take } from 'rxjs';

@Injectable()
export class OrgaoExpedidorService {

  baseUrl = 'https://localhost:5001/api/OrgaoExpedidor';

  constructor(private http: HttpClient) { }

  public get() : Observable<OrgaoExpedidor[]>{
    return this.http.get<OrgaoExpedidor[]>(this.baseUrl).pipe(take(1));
  }

}
