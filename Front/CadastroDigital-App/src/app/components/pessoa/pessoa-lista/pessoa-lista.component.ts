import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Pessoa } from '@app/models/Pessoa';
import { PessoaService } from '@app/services/pessoa.service';

@Component({
  selector: 'app-pessoa-lista',
  templateUrl: './pessoa-lista.component.html',
  styleUrls: ['./pessoa-lista.component.css']
})
export class PessoaListaComponent implements OnInit {
  public pessoas: Pessoa[] = [];
  public _pessoasFiltradas : Pessoa[] = [];
  private _filtroLista = '';
  public exibirImagem : boolean = true;
  public larguraImagem : number = 50;
  public margemImagem : number = 3;

  constructor(private pessoaService: PessoaService,
    private modalService: BsModalService,
    private modalRef : BsModalRef,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router,
    private activeRouter : ActivatedRoute) { }

    pessoaId : number;

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
        this.toastr.error('Erro ao carregar os registros.', "Erro!")
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

  openModal(template: TemplateRef<any>, id : number) : void {
    this.pessoaId = id;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {

    this.modalRef?.hide();
    this.spinner.show();

    if (this.pessoaId != 0){
      this.pessoaService.delete(this.pessoaId).subscribe({
        next: (result : boolean) => {
          if (result){
            this.toastr.success('Registro excluído com sucesso.', "Excluído");
            this.getPessoas();
          }
        },
        error: (error : any) => {
          this.toastr.error('Erro ao tentar excluir o registro.', "Erro!");
          console.error(error);
        },
      }).add(() => this.spinner.hide());
    }
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalhePessoa(id : number) : void{
    this.router.navigate([`pessoa/detalhe/${id}`])
  }
}
