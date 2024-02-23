import { Component, OnInit } from '@angular/core';
import { Passo } from '@app/enums/passo.enum';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  passo : number;
  jsonUser: any;
  passoCadastro: string = "";

  constructor() { }

  ngOnInit() {
    this.loadUser();
  }

  loadUser(): void{

    this.jsonUser = localStorage.getItem('user');
    let user = JSON.parse(this.jsonUser);

    console.log(user)

    if (user == null || user == '')
      this.passo = 1;
    else
      this.passo = user.passoCadastroId;

    console.log(user.passoCadastroId)

    for(const _passo of this.enumKeys(Passo)){
      const value = Passo[_passo]

      if (typeof value !== "string"){
        if (value >= this.passo){
          (<HTMLDivElement>document.getElementById("d-" + value)).className = "isDivDisabled";
        }
      }
    }
  }

  enumKeys<O extends object, K extends keyof O = keyof O>(obj: O): K[] {
    return Object.keys(obj).filter(k => !Number.isNaN(k)) as K[]
  }



}
