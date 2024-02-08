import { Component, OnInit } from '@angular/core';
import { LoginComponent } from './login/login.component';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent  implements OnInit {

  //constructor(private loginComponent : LoginComponent,)
  constructor(private loginComponent : LoginComponent,) {
  }

  ngOnInit() : void {
    // alert("user")
    // //this.loginComponent.showLogin();
  }

}
