import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-agregate',
  templateUrl: './agregate.component.html',
  styleUrls: ['./agregate.component.scss']
})
export class AgregateComponent implements OnInit {

  form : FormGroup

  get f() : any{
    return this.form.controls;
  }

  constructor() { }

  ngOnInit() {
  }

}
