import { Component, OnInit } from '@angular/core';
import { Pessoa } from '../models/Pessoa';
import { PessoaService } from '../services/pessoa.service';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.scss']
})
export class PessoaComponent implements OnInit {

  public pessoas: Pessoa[] = [];
  exibirImagem : boolean = true;
  larguraImagem : number = 50;
  margemImagem : number = 3;

  constructor(private pessoaService: PessoaService) { }

  ngOnInit() {
    this.getPessoas();
  }

  public getPessoas() : void{
    this.pessoaService.getPessoas().subscribe(
      (_pessoas : Pessoa[]) => {
          this.pessoas = _pessoas;
      },
      error => console.log(error)
    )
  }

  public getPessoaId() : void{


  }

  alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }
}
