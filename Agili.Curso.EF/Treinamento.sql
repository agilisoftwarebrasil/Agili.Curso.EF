CREATE TABLE Item (
  Id	bigint identity not null,
  Nome	varchar(120) not null,
  CONSTRAINT PkItem    PRIMARY KEY (Id)
);

CREATE TABLE Produto (
  Id	bigint identity not null,
  Nome	varchar(120) not null,
  ItemId	bigint not null,
  Qtde int not null default 0,
  CONSTRAINT PkProduto   PRIMARY KEY (Id)
);
ALTER TABLE Produto ADD CONSTRAINT FkProduto FOREIGN KEY (ItemId) REFERENCES Item (Id);


CREATE TABLE Pessoa (
  Id	bigint identity not null,
  Nome	varchar(120) not null,
  Data	Datetime,
  Ativo bit not null default 1,
  CONSTRAINT PkPessoa    PRIMARY KEY (Id)
);

CREATE TABLE PessoaFisica (
  Id	bigint identity not null,
  CPF	varchar(11) not null,
  RG    varchar(20),
  CONSTRAINT PkPessoaFisica    PRIMARY KEY (Id)
);

CREATE TABLE PessoaJuridica (
  Id	bigint identity not null,
  NomeFantasia	varchar(120) not null,
  CNPJ	varchar(14) not null,
  CONSTRAINT PkPessoaJuridica PRIMARY KEY (Id)
);

CREATE TABLE Cartorio (
  Id	bigint identity not null,
  CodigoINEP int null,
  CONSTRAINT PkCartorio PRIMARY KEY (Id)
);

CREATE TABLE Telefone (
	Id bigint identity not null,
	PessoaId bigint not null,
	Numero varchar(15) not null,
	TipoTelefoneId bigint not null
);

CREATE TABLE TipoTelefone (
  Id	bigint identity not null,
  Nome	varchar(120) not null,
  CONSTRAINT PkTipoTelefone PRIMARY KEY (Id)
);


ALTER TABLE Telefone ADD CONSTRAINT FkTelefone FOREIGN KEY (TipoTelefoneId) REFERENCES TipoTelefone (Id);
ALTER TABLE Telefone ADD CONSTRAINT FkTelefone2 FOREIGN KEY (PessoaId) REFERENCES Pessoa (Id);
ALTER TABLE PessoaFisica ADD CONSTRAINT FkPessoaFisica FOREIGN KEY (Id) REFERENCES Pessoa (Id);
ALTER TABLE PessoaJuridica ADD CONSTRAINT FkPessoaJuridica FOREIGN KEY (Id) REFERENCES Pessoa (Id);

ALTER TABLE Cartorio ADD CONSTRAINT FkCartorio FOREIGN KEY (Id) REFERENCES Cartorio (Id);


CREATE VIEW VwPessoa as (select * from Pessoa);