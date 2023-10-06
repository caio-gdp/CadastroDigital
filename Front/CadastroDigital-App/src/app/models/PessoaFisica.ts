import { RedeSocial } from "./RedeSocial";

export interface PessoaFisica {
  id : number;
  dataNascimento : string;
  rg : string;
  dataEmissao: string;
  orgaoExpedidorId: number | null,
  ufExpedidorId: number | null,
  naturalidadeId: number | null,
  nacionalidadeId: number | null,
  ufId: number | null,
  imagem : string;
  idUser : number;
  sexoId : number | null;
  estadoCivilId : number | null;
  redesSociais : RedeSocial[] | any;
}
