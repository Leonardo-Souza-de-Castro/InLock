USE Inlock_Games_Manha;
GO


--Listar todos os usu?rios;
SELECT * FROM Usuarios;

--Listar todos os est?dios;
SELECT * FROM Estudios;

--Listar todos os jogos;
SELECT * FROM Jogos;

--Listar todos os tipos de usu?rios;
SELECT * FROM TiposUsuarios;

--Listar todos os jogos e seus respectivos est?dios;
SELECT NomeEstudio, NomeJogo, Descricao,  CONVERT (DATE,DataLancamento,103)[Data de Lancamento], ValorJogo
FROM Jogos
INNER JOIN Estudios
ON Jogos.IdEstudio = Estudios.IdEstudio
GO


--Buscar e trazer na lista todos os est?dios com os respectivos jogos. Obs.: Listar
--todos os est?dios mesmo que eles n?o contenham nenhum jogo de refer?ncia;
SELECT NomeEstudio, NomeJogo, Descricao, CONVERT (VARCHAR(20), DataLancamento, 103)[Data de Lancamento], ValorJogo
FROM Estudios
LEFT JOIN Jogos
ON Estudios.IdEstudio = Jogos.IdEstudio
GO


--Buscar um usu?rio por e-mail e senha (login);
SELECT * FROM Usuarios WHERE Email = 'admin@admin.com' AND Senha = 'admin';
GO

--Buscar um jogo por idJogo;
SELECT * FROM Jogos WHERE IdJogo = 2;
GO

--Buscar um est?dio por idEstudio;
SELECT * FROM Estudios WHERE IdEstudio = 3;
GO


--Teste do c?digo listar todos
Select NomeEstudio As [Nome do Estudio], IdJogo As [Id Jogo], NomeJogo As [Nome], Descricao As 'Descri??o', DataLancamento As [Data de Lan?amento], ValorJogo As Valor
From Jogos As J 
Inner Join Estudios As E 
on J.IdEstudio = E.IdEstudio;
go

--Teste Listar por Id
Select NomeEstudio As [Nome do Estudio], IdJogo As [Id Jogo], NomeJogo As Nome, Descricao As [Descri??o], DataLancamento As [Data de Lan?amento], ValorJogo As Valor
From Jogos As J 
Inner Join Estudios As E 
on J.IdEstudio = E.IdEstudio where J.IdJogo = 1;
GO

--Testando Listar Todos os Est?dios mesmo os que n?o possuem jogos cadastrados.
Select NomeEstudio As [Nome do Estudio], IdJogo As [Id Jogo], NomeJogo As Nome, Descricao As [Descri??o], DataLancamento As [Data de Lan?amento], ValorJogo As Valor 
From Estudios As E
Left Join Jogos As J 
On E.IdEstudio = J.IdEstudio

 select  IdUsuario, email, senha, IdTipoUsuario from Usuarios where email = 'admin@admin.com'  and senha = 'admin'