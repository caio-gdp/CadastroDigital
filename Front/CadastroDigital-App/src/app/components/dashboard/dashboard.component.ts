import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {

  public larguraImagem : number = 1000;
  public margemImagem : number = 10;

  constructor() { }

  ngOnInit() {
  }

}
