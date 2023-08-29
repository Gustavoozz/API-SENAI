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

--ALTER TABLE Filme DROP COLUMN Nome;
--GO

--DROP TABLE Filme

--ALTER TABLE Filme
--ADD Nome VARCHAR(30) FOREIGN KEY REFERENCES Genero(IdGenero)

INSERT INTO Genero(Nome)
VALUES('Ação'),('Terror')

INSERT INTO Filme(IdGenero,Titulo)
VALUES(1,'Django Livre')

-- Efeito Joana D'Arc: 
--INSERT INTO Genero(Nome)
--VALUES('Joana D'Arc')

SELECT	
	F.IdFilme,
	F.IdGenero,
	F.Titulo,
	G.Nome 
FROM Filme AS F
	INNER JOIN Genero AS G ON F.IdGenero = G.IdGenero


SELECT * FROM Genero
SELECT * FROM Filme
