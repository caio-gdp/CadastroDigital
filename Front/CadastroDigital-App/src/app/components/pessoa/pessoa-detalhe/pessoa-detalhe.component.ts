import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-pessoa-detalhe',
  templateUrl: './pessoa-detalhe.component.html',
  styleUrls: ['./pessoa-detalhe.component.css']
})
export class PessoaDetalheComponent implements OnInit {

  form: FormGroup;

  get f() : any{
    return this.form.controls;
  }

  constructor(private fb : FormBuilder) { }

  ngOnInit() {
    this.validation();
  }

  onSubmit() : void{

    if (this.form.invalid){
      return;
    }
  }

  public validation() : void{
    this.form = this.fb.group({
      cpf : ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      dataNascimento : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      nome : ['', [Validators.required, Validators.minLength(2), Validators.maxLength(150)]],
      telefone : ['', [Validators.required]],
      email :['', [Validators.required, Validators.email]],
    })
  }

  public resetForm(event : any) : void{
    event.preventDefault();
    this.form.reset();
  }
}
