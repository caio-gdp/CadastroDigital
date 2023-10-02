import { Injectable } from '@angular/core';
import { Observable, ReplaySubject, map, take } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { User } from '@app/models/Identity/User';
import { UserLogin } from '@app/models/Identity/UserLogin';

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
          var i = user.name.indexOf(' ');
          user.name = user.name.substring(0,i)
          this.setCurrentUser(user)
        }
      })
    );
  }

  public register(model: any) : Observable<User>{

    alert(model)

    var user = {} as User;

    user.userId = model.userId;
    user.phoneNumber = model.phoneNumber;
    user.dateOfBirth = model.dateOfBirth;
    user.name = model.name;
    user.email = model.email;
    user.passwordHash = model.passwordReg;
    user.noticia = model.noticia = null ? false : true;
    // user.tipoPessoa = "F";
    // user.dataCadastro = new Date();
    // user.passoCadastroId = 1,
    // user.statusCadastroId = 3

    //  return this.http.post<User>(this.baseUrl + 'register', model).pipe(
    //   take(1),
    //   map((response: User) => {
    //     const user = response;

    //     if (user){
    //       this.setCurrentUser(user)
    //     }
    //   })
    // );

    return this.http.post<User>(this.baseUrl + 'register', model).pipe(take(1));

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
