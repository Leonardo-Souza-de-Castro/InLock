CREATE DATABASE Inlock_Games_Manha;
GO

USE Inlock_Games_Manha;
GO

--Criar uma tabela de estúdios com os campos de idEstudio e nomeEstudio;
CREATE TABLE Estudios(
   IdEstudio INT PRIMARY KEY IDENTITY(1,1),
   NomeEstudio VARCHAR(50) NOT NULL
);
GO

--Criar uma tabela de jogos com os campos idJogo, nomeJogo, descrição,
--dataLancamento, valor e idEstudio;
CREATE TABLE Jogos(
   IdJogo INT PRIMARY KEY IDENTITY(1,1),
   IdEstudio INT FOREIGN KEY REFERENCES Estudios(IdEstudio),
   NomeJogo VARCHAR(100) NOT NULL UNIQUE,
   Descricao VARCHAR(200) NOT NULL UNIQUE,
   DataLancamento DATE NOT NULL,
   ValorJogo SMALLMONEY NOT NULL
);


--Criar uma tabela de tipos de usuários contendo os campos idTipoUsuario e titulo;
CREATE TABLE TiposUsuarios(
   IdTipoUsuario INT PRIMARY KEY IDENTITY(1,1),
   Titulo VARCHAR(20) NOT NULL
);


--Criar uma tabela de usuários contendo os campos de idUsuario, email, senha e idTipoUsuario;
CREATE TABLE Usuarios(
  IdUsuario INT PRIMARY KEY IDENTITY(1,1),
  IdTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuarios(IdTipoUsuario),
  Email VARCHAR(50) NOT NULL UNIQUE,
  Senha VARCHAR(20) NOT NULL
);

ALTER TABLE Usuarios 
ADD CONSTRAINT INT
DEFAULT 2 FOR IdTipoUsuario;