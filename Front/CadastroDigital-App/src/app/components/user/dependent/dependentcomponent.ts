import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Dependente } from '@app/models/Dependente';

@Component({
  selector: 'app-dependent',
  templateUrl: './dependent.component.html',
  styleUrls: ['./dependent.component.scss']
})
export class DependentComponent implements OnInit {

  form : FormGroup;

  get f() : any{
    return this.form.controls;
  }

  get dependentes(): FormArray{
    return this.form.get('dependentes') as FormArray;
  }

  constructor(public fb : FormBuilder) { }

  ngOnInit() {
    this.validation();
  }

  private validation() : void{
    this.form = this.fb.group({
      dependentes: this.fb.array([])
    });
  }

  addDependente() : void{
     this.dependentes.push(this.criarDependente({id: 0} as Dependente));
  }

  criarDependente(dependente : Dependente): FormGroup {
    return this.fb.group({
      id: [dependente.id],
      nome: [dependente.nome],
      // dataNascimento : [dependente.dataNascimento],
      // grauparentesco : [dependente.grauParentescoId]
    })
  }

  // public tituloDependente(nome: string) : string{
  //   console.log(nome)
  //    return this.dependentes.get(nome)?.value;

  // }

}
