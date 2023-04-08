import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Pessoa } from '../../models/Pessoa';
import { PessoaService } from '../../services/pessoa.service';

@Component({
  selector: 'app-pessoa',
  templateUrl: './pessoa.component.html',
  styleUrls: ['./pessoa.component.scss']
})
export class PessoaComponent implements OnInit {
  public pessoas: Pessoa[] = [];
  public _pessoasFiltradas : Pessoa[] = [];
  private _filtroLista = '';
  public exibirImagem : boolean = true;
  public larguraImagem : number = 50;
  public margemImagem : number = 3;

  constructor(private pessoaService: PessoaService,
    private modalService: BsModalService,
    private modalRef : BsModalRef,
    private toastrService: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.getPessoas();
  }

  public get filtroLista() : string{
    return this._filtroLista;
  }

  public set filtroLista(value : string){
    this._filtroLista = value;
    this._pessoasFiltradas = this._filtroLista ? this.filtrarPessoas(this.filtroLista): [];
  }

  public filtrarPessoas(filtrarPor : string) : Pessoa[]{
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.pessoas.filter(
      pessoa => pessoa.pessoaFisica.nome.toLocaleLowerCase().indexOf(filtrarPor) != -1 ||
      pessoa.pessoaFisica.cpf.indexOf(filtrarPor) != -1
    );
  }

  public getPessoas() : void{
    const observer = {
      next : (_pessoas : Pessoa[]) => {
          this.pessoas = _pessoas;
          this._pessoasFiltradas = this.pessoas;
      },
      error : (error : any) =>
      {
        this.spinner.hide(),
        this.toastrService.error('Erro ao carregar os registros.', "Erro!")
      },
      complete : () => this.spinner.hide()
    };
    this.pessoaService.getPessoas().subscribe(observer);
  }

  public getPessoaId() : void{
  }

  alterarImagem(){
    this.exibirImagem = !this.exibirImagem;
  }

  openModal(template: TemplateRef<any>) : void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastrService.success('Registro excluído com sucesso.', "Excluído");
  }

  decline(): void {
    this.modalRef?.hide();
  }

}
