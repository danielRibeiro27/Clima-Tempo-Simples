-- INSERE OS ESTADOS
DELETE FROM Estado

GO

INSERT INTO Estado 
(Id, Nome, UF)
VALUES
(1, 'São Paulo', 'SP'),
(2, 'Paraná', 'PR')

GO
SELECT * FROM Estado
GO

-- INSERE AS CIDADES
DELETE FROM Cidade

GO

INSERT INTO Cidade 
(Id, Nome, EstadoId)
VALUES
(1, 'Assis', 1),
(2, 'Santo Anastacio', 1),
(3, 'Presidente Prudente', 1),
(4, 'Campinas', 1),
(5, 'Lonrina', 2)

GO
SELECT * FROM Cidade