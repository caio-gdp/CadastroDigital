import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.scss']
})
export class PessoaComponent implements OnInit {

  public pessoas: any = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getPessoa();
  }

  public getPessoa() : void{

    this.http.get('https://localhost:5001/api/Pessoa').subscribe(
      response => this.pessoas = response,
      error => console.log(error)

    )


  }

}
