import { PessoaFisica } from "./PessoaFisica";

export interface Pessoa {
   id : number;
   tipoPessoaId : number;
   dataCadastro : Date;
   dataAtualizacao : Date;
   codigoValidacao : number;
   dataHoraCodigoValidacao : Date;
   senha : string;
   confirmaSenha : string;
   statusCadastroId : number;
   notificacao : boolean;

   pessoaFisica : PessoaFisica
}
