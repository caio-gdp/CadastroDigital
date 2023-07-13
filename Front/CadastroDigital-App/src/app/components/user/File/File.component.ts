import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-File',
  templateUrl: './File.component.html',
  styleUrls: ['./File.component.scss']
})
export class FileComponent implements OnInit {

  form : FormGroup;
  file : string;

  constructor() { }

  ngOnInit() {
    this.file = 'assets/files/ficha-socio-pdf';
  }

  openFile(i : number) : void{

    window.open("assign");
  }

}
