import { Component, OnChanges, OnInit } from '@angular/core';
import { ControlValueAccessor, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

import { Pessoa } from '@app/models/Pessoa';
import { PessoaFisica } from '@app/models/PessoaFisica';
import { PessoaService } from '@app/services/pessoa.service';

import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-pessoa-detalhe',
  templateUrl: './pessoa-detalhe.component.html',
  styleUrls: ['./pessoa-detalhe.component.css']
})
export class PessoaDetalheComponent implements OnInit {

  pessoa: Pessoa;
  pessoaFisica: PessoaFisica;
  form: FormGroup;
  stateForm = 'post';

  get f() : any{
    return this.form.controls;
  }

  bsConfig() : any{
    return {
      dateInputFormat: 'DD/MM/YYYY',
      adaptivePosition: true,
      isAnimated: true,
      containerClass: 'theme-default',
      location: 'pt-br'
    };
  }

  constructor(private fb : FormBuilder,
              private localeService: BsLocaleService,
              private activeRouter: ActivatedRoute,
              private pessoaService : PessoaService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService)
  {
    this.localeService.use('pt-br');
  }

  ngOnInit() {
    //this.loadPessoa();
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

  public cssValidator(filedForm : FormControl) : any {
    return {'is-invalid':this.f.cpf.errors && this.f.cpf.touched}
  }

  public loadPessoa() : void {

    const pessoaId = this.activeRouter.snapshot.paramMap.get('id');

    if (pessoaId != null && pessoaId != '0'){

      this.spinner.show();
      this.stateForm = 'put';

      this.pessoaService.getPessoaById(+pessoaId).subscribe({
        next : (pessoa : Pessoa) => {
          this.pessoa = {...pessoa};
          this.pessoaFisica = {...pessoa.pessoaFisica};

          var d = this.pessoaFisica.dataNascimento.substring(8,10);
          var m = this.pessoaFisica.dataNascimento.substring(5,7);
          var a = this.pessoaFisica.dataNascimento.substring(0,4);

          this.pessoaFisica.dataNascimento = String(d) + '/' + String(m) + '/' + String(a);

          this.form.patchValue(this.pessoa);
          this.form.patchValue(this.pessoaFisica);
        },
        error : (error : any) =>
        {
          this.toastr.error('Erro ao carregar o registro.', "Erro!")
        },
      }).add(() => this.spinner.hide());
    }
  }

  public saveChange() : void{

    this.spinner.show();

    if (this.form.valid){

      this.pessoa = (this.stateForm == 'post') ? {...this.form.value} : {id: this.pessoa.id, ...this.form.value};

      // this.pessoaService[this.stateForm](this.pessoa).subscribe({
      //   next: () => this.toastr.success('Registro salvo com sucesso.', 'Sucesso'),
      //   error: (error: any) => {
      //     console.error(error);
      //     this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
      //   },
      // }).add(() => this.spinner.hide());

      this.pessoaService.post(this.pessoa).subscribe({
        next: () => this.toastr.success('Registro salvo com sucesso.', 'Sucesso'),
        error: (error: any) => {
          console.error(error);
          this.toastr.error('Erro ao tentar salvar o registro.', 'Erro!')
        },
      }).add(() => this.spinner.hide());
    }
  }

}
