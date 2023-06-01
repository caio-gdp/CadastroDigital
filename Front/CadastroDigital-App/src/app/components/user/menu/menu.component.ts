import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  passo : string = "precadastro";

  constructor() { }

  ngOnInit() {

    if (this.passo != undefined){
       (<HTMLInputElement>document.getElementById("a-" + this.passo)).style.borderLeft = "3px solid #fd0404";
       (<HTMLInputElement>document.getElementById("a-" + this.passo)).style.backgroundColor = "#ebeaea";
       (<HTMLInputElement>document.getElementById("i-" + this.passo)).style.color = "#fd0404";
    }
  }

}
