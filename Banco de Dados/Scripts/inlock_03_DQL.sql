USE Inlock_Games_Manha;
GO


--Listar todos os usuários;
SELECT * FROM Usuarios;

--Listar todos os estúdios;
SELECT * FROM Estudios;

--Listar todos os jogos;
SELECT * FROM Jogos;

--Listar todos os jogos e seus respectivos estúdios;
SELECT NomeEstudio, NomeJogo, Descrição,  FORMAT (DataLancamento, 'dd/MM/yyyy')DataLancamento, ValorJogo
FROM Jogos
INNER JOIN Estudios
ON Jogos.IdEstudio = Estudios.IdEstudio
GO


--Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar
--todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
SELECT NomeEstudio, NomeJogo, Descrição, FORMAT (DataLancamento, 'dd/MM/yyyy')DataLancamento, ValorJogo
FROM Estudios
LEFT JOIN Jogos
ON Estudios.IdEstudio = Jogos.IdEstudio
GO


--Buscar um usuário por e-mail e senha (login);
SELECT * FROM Usuarios WHERE Email = 'admin@admin.com' AND Senha = 'admin';
GO

--Buscar um jogo por idJogo;
SELECT * FROM Jogos WHERE IdJogo = 2;
GO

--Buscar um estúdio por idEstudio;
SELECT * FROM Estudios WHERE IdEstudio = 3;
GO