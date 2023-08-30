CREATE DATABASE Filmes_Tarde
USE Filmes_Tarde

CREATE TABLE Genero
(
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(50)
)

CREATE TABLE Filme
(
	IdFilme INT PRIMARY KEY IDENTITY,
	IdGenero INT FOREIGN KEY REFERENCES Genero(IdGenero),
	Titulo VARCHAR(50)
)

-- Other commands:
--ALTER TABLE Filme DROP COLUMN Nome;
--GO

--DROP TABLE Filme

--ALTER TABLE Filme
--ADD Nome VARCHAR(30) FOREIGN KEY REFERENCES Genero(IdGenero)

-- Inserir dados na tabela gênero:
INSERT INTO Genero(Nome)
VALUES('Ação'),('Terror')

-- Inserir dados na tabela filme:
INSERT INTO Filme(IdGenero,Titulo)
VALUES(2, 'Sexta-Feira 13')

 
-- Efeito Joana D'Arc: 
--INSERT INTO Genero(Nome)
--VALUES('Joana D'Arc')

-- JOIN:
SELECT	
	F.IdFilme,
	F.IdGenero,
	F.Titulo,
	G.Nome 
FROM Filme AS F
	INNER JOIN Genero AS G ON F.IdGenero = G.IdGenero


-- Select:
SELECT * FROM Genero
SELECT * FROM Filme
SELECT * FROM Usuario

-- DROP:
DROP TABLE Usuario


-- Tabela Usuario:
CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	Email VARCHAR(50) NOT NULL UNIQUE,
	Senha VARCHAR(20) NOT NULL,
	Permissão BIT NOT NULL
)

-- Inserir dados na tabela usuario:
INSERT INTO Usuario(Email,Senha,Permissão)
VALUES('maNOEL@gmail.com','4321','0')
