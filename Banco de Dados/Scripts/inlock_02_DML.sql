USE Inlock_Games_Manha;
GO

--Inserindo dados na tabela 
INSERT INTO Estudios(NomeEstudio)
VALUES ('Blizzard'), ('Rockstar Studios'), ('Square Enix')

SELECT * FROM Estudios


--Inserindo dados na tabela 
INSERT INTO Jogos(IdEstudio, NomeJogo, Descri��o, DataLancamento, ValorJogo)
VALUES (1,'Diablo 3','� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.',
        '15/05/2012', '99'), 

       (2,'Red Dead Redemption II','Jogo eletr�nico de a��o-aventura western.','26/10/2018','120')

SELECT * FROM Jogos



--Inserindo dados na tabela 
INSERT INTO TiposUsuarios(Titulo)
VALUES ('Administrador'),('Cliente')

SELECT * FROM TiposUsuarios



--Inserindo dados na tabela 
INSERT INTO Usuarios(IdTipoUsuario,Email,Senha)
VALUES (1,'admin@admin.com','admin'),
       (2,'cliente@cliente.com','cliente')

SELECT * FROM Usuarios

