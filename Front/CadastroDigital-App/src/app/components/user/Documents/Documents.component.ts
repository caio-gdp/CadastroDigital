import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-Documents',
  templateUrl: './Documents.component.html',
  styleUrls: ['./Documents.component.scss']
})
export class DocumentsComponent implements OnInit {

  form : FormGroup;
  imagemUrl : string;
  file : File[];

  constructor() { }

  ngOnInit() {
    this.imagemUrl = 'assets/img/upload.png';
  }

  onFileChange(e : any) : void{

    const reader = new FileReader();
    reader.onload = (event: any) => this.imagemUrl = event.target.result;

    this.file = e.target.files;

    reader.readAsDataURL(this.file[0]);

  }

}
