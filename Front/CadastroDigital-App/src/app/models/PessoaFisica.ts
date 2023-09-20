export interface PessoaFisica {
  id : number;
  cpf : string;
  dataNascimento : string;
  nome : string;
  rg : string;
  dataEmissao: string;
  orgaoExpedidorId?: number | null,
  ufId?: number | null,
  imagem : string;
  idUser : number;
  //pessoaId : number;
  sexoId? : number | null;
  estadoCivilId? : number | null;
}
