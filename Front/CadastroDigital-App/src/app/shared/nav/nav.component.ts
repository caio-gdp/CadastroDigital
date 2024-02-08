import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  dataAtual = new Date();

  constructor(private router: Router) { }

  ngOnInit() : void {
    //if (this.router.url == '/')
      //<HTMLDivElement>document.getElementById("divLogin")?.style.display = "none";
  }

  showMenuLoggedOut() : boolean{
    return this.router.url == '/dashboard';
  }

  showMenuLoggedIn() : boolean{
    var ret : boolean = false;

    // if (this.router.url != '/user/login' && this.router.url != '/dashboard')
    if (this.router.url == '/')
      ret = true;

      return ret;
  }

  registration() : void{
    this.router.navigate([`user/registration/`]);
  }
}
