import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-profissionalData',
  templateUrl: './profissionalData.component.html',
  styleUrls: ['./profissionalData.component.scss']
})
export class ProfissionalDataComponent implements OnInit {

  form : FormGroup;

  constructor() { }

  ngOnInit() {
  }

  public saveChange() : void{}

}
