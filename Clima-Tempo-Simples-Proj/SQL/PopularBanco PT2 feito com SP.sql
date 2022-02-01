-- Cria uma procedure que popula a previsao de clima (e pode ser utilizada novamente)
-- Gera uma previsão com clima e temperaturas aleatórias para os próximos 10 dias.
-- PARAM @CidadeId = Id da cidade para qual sera feita a previsão

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'POPULARBANCO')
                    AND type IN ( N'P', N'PC' ) ) DROP PROCEDURE POPULARBANCO

GO 

CREATE PROCEDURE POPULARBANCO @CidadeId int = null
AS
	-- DECLARA O INDEX PARA O LOOP
	DECLARE @INDEX int = 0
	WHILE(@INDEX < 10)	
	BEGIN

		-- GERA UM NUMERO ALEATORIO E ESCOLHE UM CLIMA BASEADO NELE
		DECLARE @CLIMA nvarchar(15) = ''
		DECLARE @RAND_NUM INT = ABS(CHECKSUM(NEWID()) % 4)
		IF @RAND_NUM = 0
			SET @CLIMA = 'ensolarado'
		ELSE IF @RAND_NUM = 1
			SET @CLIMA = 'instavel'
		ELSE IF @RAND_NUM = 2
			SET @CLIMA = 'chuvoso'
		ELSE IF @RAND_NUM = 3
			SET @CLIMA = 'nublado'
		ELSE
			SET @CLIMA = 'tempestuoso'

		-- GERA TEMPERATURAS ALETÓRIAS
		DECLARE @RAND_MINIMO int = ABS(CHECKSUM(NEWID()) % 15) + 1 -- RANDOM BETWEEN 1 - 15
		DECLARE @RAND_MAXIMO int = ABS(CHECKSUM(NEWID()) % 25) + 15 -- RANDOM BETWEEN 15 - 40


		-- INSERE NO BANCO
		INSERT INTO PrevisaoClima (CidadeId, DataPrevisao, Clima, TemperaturaMinima, TemperaturaMaxima)
		VALUES
		(@CidadeId, DATEADD(day, @INDEX,GETDATE()), @CLIMA, @RAND_MINIMO, @RAND_MAXIMO)

		-- ATUALIZA O INDEX
		SET @INDEX = @INDEX + 1
	END


GO

DELETE FROM PrevisaoClima
GO

-- Poderia fazer uma query para buscar o Id de todas cidades e chamar a procedure para cada uma utilizando um foreach (CURSOR)
-- Mas to sem tempo :(
EXEC POPULARBANCO @CidadeId = 1
EXEC POPULARBANCO @CidadeId = 2
EXEC POPULARBANCO @CidadeId = 3
EXEC POPULARBANCO @CidadeId = 4
EXEC POPULARBANCO @CidadeId = 5

GO

SELECT * FROM PrevisaoClima



