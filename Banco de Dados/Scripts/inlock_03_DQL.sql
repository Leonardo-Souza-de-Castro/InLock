USE Inlock_Games_Manha;
GO


--Listar todos os usuários;
SELECT * FROM Usuarios;

--Listar todos os estúdios;
SELECT * FROM Estudios;

--Listar todos os jogos;
SELECT * FROM Jogos;

--Listar todos os jogos e seus respectivos estúdios;
SELECT NomeEstudio, NomeJogo, Descricao,  CONVERT (DATE,DataLancamento,103)[Data de Lancamento], ValorJogo
FROM Jogos
INNER JOIN Estudios
ON Jogos.IdEstudio = Estudios.IdEstudio
GO


--Buscar e trazer na lista todos os estúdios com os respectivos jogos. Obs.: Listar
--todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
SELECT NomeEstudio, NomeJogo, Descricao, CONVERT (VARCHAR(20), DataLancamento, 103)[Data de Lancamento], ValorJogo
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


--Teste do código listar todos
Select NomeEstudio As [Nome do Estudio], IdJogo As [Id Jogo], NomeJogo As [Nome], Descricao As 'Descrição', DataLancamento As [Data de Lançamento], ValorJogo As Valor
From Jogos As J 
Inner Join Estudios As E 
on J.IdEstudio = E.IdEstudio;
go

--Teste Listar por Id
Select NomeEstudio As [Nome do Estudio], IdJogo As [Id Jogo], NomeJogo As Nome, Descricao As [Descrição], DataLancamento As [Data de Lançamento], ValorJogo As Valor
From Jogos As J 
Inner Join Estudios As E 
on J.IdEstudio = E.IdEstudio where J.IdJogo = 1;
GO

--Testando Listar Todos os Estúdios mesmo os que não possuem jogos cadastrados.
Select NomeEstudio As [Nome do Estudio], IdJogo As [Id Jogo], NomeJogo As Nome, Descricao As [Descrição], DataLancamento As [Data de Lançamento], ValorJogo As Valor 
From Estudios As E
Left Join Jogos As J 
On E.IdEstudio = J.IdEstudio