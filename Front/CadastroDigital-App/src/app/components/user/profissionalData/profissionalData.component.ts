import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { isUndefined } from 'ngx-bootstrap/chronos/utils/type-checks';

@Component({
  selector: 'app-profissionalData',
  templateUrl: './profissionalData.component.html',
  styleUrls: ['./profissionalData.component.scss']
})
export class ProfissionalDataComponent implements OnInit {

  form : FormGroup;

  get f() : any{
    return this.form.controls;
  }

  constructor() { }

  ngOnInit() {

    this.form = new FormGroup({
      categoria : new FormControl(),
      centroCusto : new FormControl()
    })
  }

  public saveChange() : void{}

  public addCentroCusto() : void{

    var valor = this.f.categoria.value
    var objCentroCusto = document.getElementById('centroCusto');
    var objInformacaoBancaria = document.getElementById('divInformacaoBancaria');

    if (objCentroCusto != null && objInformacaoBancaria != null){
      if (valor == 1)
      {
        objCentroCusto.style.display = '';
        objInformacaoBancaria.style.display = 'none';
      }
      else if(valor == 5)
      {
        objCentroCusto.style.display = 'none';
        objInformacaoBancaria.style.display = '';
      }
      else{
        objCentroCusto.style.display = 'none';
        objInformacaoBancaria.style.display = 'none';
      }
    }
  }
}
