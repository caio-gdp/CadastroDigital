import { Email } from "./Email";
import { Pessoa } from "./Pessoa";
import { Telefone } from "./Telefone";

export interface PessoaFisica {
  id : number;
  cpf : string;
  dataNascimento : Date;
  nome : string;
  imagem : string;
  pessoaId : number;
  sexoId : number;
  estadoCivilId : number;
  pessoa : Pessoa;
  telefone : Telefone;
  email : Email;
}
