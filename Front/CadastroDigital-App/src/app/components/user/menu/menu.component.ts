import { Component, OnInit } from '@angular/core';
import { Passo } from '@app/enums/passo.enum';
import { User } from '@app/models/Identity/User';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  passo : number;
  jsonUser: any;
  passoCadastro: string = "";
  user : User;

  constructor() { }

  ngOnInit() {
    this.loadUser();
  }

  loadUser(): void{

    this.jsonUser = localStorage.getItem('user');
    this.user = JSON.parse(this.jsonUser);

    if (this.user == null)
      this.passo = 0;
    else
      this.passo = this.user.passoCadastroId;

      alert(this.passo)

    for(const _passo of this.enumKeys(Passo)){
      const value = Passo[_passo]

      if (typeof value != "string"){
        if (value > this.passo + 1){
          (<HTMLDivElement>document.getElementById("d-" + value)).className = "isDivDisabled";
        }
      }
    }
  }

  enumKeys<O extends object, K extends keyof O = keyof O>(obj: O): K[] {
    return Object.keys(obj).filter(k => !Number.isNaN(k)) as K[]
  }

  public updateLocalStorage(passo: number) : void{

    this.jsonUser = localStorage.getItem('user');
    this.user = JSON.parse(this.jsonUser);

    this.user.passoCadastroId = passo

    if (this.user)
      localStorage.clear()

    localStorage.setItem("user", JSON.stringify(this.user));

    this.ngOnInit()
   }
}
