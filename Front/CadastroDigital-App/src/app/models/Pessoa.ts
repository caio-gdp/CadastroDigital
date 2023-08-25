import { PessoaFisica } from "./PessoaFisica";
import { Email } from "./Email";
import { Telefone } from "./Telefone";

export interface Pessoa {
   id : number;
   tipoPessoaId : number;
   dataCadastro : string;
   dataAtualizacao : string;
   codigoValidacao : number;
   dataHoraCodigoValidacao : string;
   senha : string;
   confirmaSenha : string;
   statusCadastroId : number;
   passoCadastroId : number;
   enderecoIp : string;
   notificacao : boolean;
   pessoaFisica : PessoaFisica
   telefone : Telefone;
   email : Email;

}
