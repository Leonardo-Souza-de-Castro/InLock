USE Inlock_Games_Manha;
GO

--Inserir três estúdios: um com o nome de Blizzard, outro com o nome de 
--Rockstar Studios e o último com o nome de Square Enix;
INSERT INTO Estudios(NomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')

SELECT * FROM Estudios



--Inserir um jogo com o nome de: Diablo 3, com data de lançamento de: 15 de maio de 2012, que contenha a descrição de: é um jogo que contém bastante
-- ação e é viciante, seja você um novato ou um fã. Seu estúdio é a Blizzard. E o jogo custa R$ 99,00; 

--Inserir um jogo com o nome de: Red Dead Redemption II, com a descrição de: jogo eletrônico de ação-aventura western. Seu estúdio será a Rockstar Studios. 
-- Lançado mundialmente em 26 de outubro de 2018. E o jogo custa R$ 120,00;
INSERT INTO Jogos(IdEstudio, NomeJogo, Descricao, DataLancamento, ValorJogo)
VALUES (1,'Diablo 3','É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.',
        '15/05/2012', '99'), 

       (2,'Red Dead Redemption II','Jogo eletrônico de ação-aventura western.','26/10/2018','120')

SELECT * FROM Jogos



--Inserir Tipos de Usuários Adm e Cliente
INSERT INTO TiposUsuarios(Titulo)
VALUES ('Administrador'),('Cliente')

SELECT * FROM TiposUsuarios



--Inserir um usuário do tipo ADMINISTRADOR que tenha o e-mail igual a admin@admin.com e a senha igual a admin;
--Inserir um usuário do tipo CLIENTE que tenha o e-mail igual a cliente@cliente.com e a senha igual a cliente;
INSERT INTO Usuarios(IdTipoUsuario,Email,Senha)
VALUES (1,'admin@admin.com','admin'),
       (2,'cliente@cliente.com','cliente')

SELECT * FROM Usuarios

--Teste Listar Todos Tiposusuarios
Select IdTipoUsuario, Titulo From TiposUsuarios

--Teste Listar Por Id Tiposusuarios
Select Titulo From TiposUsuarios as TU where TU.IdTipoUsuario = 3