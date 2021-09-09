USE Inlock_Games_Manha;
GO


--Listar todos os usu�rios;
SELECT * FROM Usuarios;

--Listar todos os est�dios;
SELECT * FROM Estudios;

--Listar todos os jogos;
SELECT * FROM Jogos;

--Listar todos os jogos e seus respectivos est�dios;
SELECT NomeEstudio, NomeJogo, Descri��o,  FORMAT (DataLancamento, 'dd/MM/yyyy')DataLancamento, ValorJogo
FROM Jogos
INNER JOIN Estudios
ON Jogos.IdEstudio = Estudios.IdEstudio
GO


--Buscar e trazer na lista todos os est�dios com os respectivos jogos. Obs.: Listar
--todos os est�dios mesmo que eles n�o contenham nenhum jogo de refer�ncia;
SELECT NomeEstudio, NomeJogo, Descri��o, FORMAT (DataLancamento, 'dd/MM/yyyy')DataLancamento, ValorJogo
FROM Estudios
LEFT JOIN Jogos
ON Estudios.IdEstudio = Jogos.IdEstudio
GO


--Buscar um usu�rio por e-mail e senha (login);
SELECT * FROM Usuarios WHERE Email = 'admin@admin.com' AND Senha = 'admin';
GO

--Buscar um jogo por idJogo;
SELECT * FROM Jogos WHERE IdJogo = 2;
GO

--Buscar um est�dio por idEstudio;
SELECT * FROM Estudios WHERE IdEstudio = 3;
GO