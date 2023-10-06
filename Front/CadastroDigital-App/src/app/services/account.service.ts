import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, first, map, take } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { User } from '@app/models/Identity/User';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private currentUserSource = new ReplaySubject<User | null>(1);
  public currentUser$ = this.currentUserSource.asObservable();
  baseUrl = 'https://localhost:5001/api/account/';

  constructor(private http: HttpClient) { }

  public login(model: any) : Observable<void>{
    return this.http.post<User>(this.baseUrl + 'login', model).pipe(
      take(1),
      map((response: User) => {
        const user = response;

        if (user){
          this.setCurrentUser(user)
        }
      })
    );
  }

  getUser(): Observable<User>{
    return this.http.get<User>(this.baseUrl + 'getUser').pipe(take(1));
  }

  public register(model: User) : Observable<User>{

    model.noticia = null ? false : true;

    return this.http.post<User>(this.baseUrl + 'register', model).pipe(take(1));
  }

  public updateUser(model: User) : Observable<void>{

    return this.http.put<User>(this.baseUrl + 'updateUser', model).pipe(
      take(1),
      map((response: User) => {
        const user = response;

        if (user){
          this.setCurrentUser(user)
        }
    }));
  }

  public setCurrentUser(user: User) : void{
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout(): void{
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.currentUserSource.complete();
  }

}
