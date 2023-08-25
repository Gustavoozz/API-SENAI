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

INSERT INTO Genero(Nome)
VALUES('Ação'),('Terror')

INSERT INTO Filme(IdGenero,Titulo)
VALUES(1,'Django livre'),(2,'A Freira')

-- Efeito Joana D'Arc: 
--INSERT INTO Genero(Nome)
--VALUES('Joana D'Arc')

SELECT * FROM Genero
SELECT * FROM Filme