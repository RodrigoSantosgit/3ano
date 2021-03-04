USE ClubeDesportivo
GO

GO
CREATE PROC ClubeDesportivo.CreateTreino(@equipa INT, @data DATE, @equipa2 INT, @data2 DATE, @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.treino WHERE equipa = @equipa AND data = @data)
	BEGIN
		SET @res = 1;
	END
	ELSE
	BEGIN
		INSERT INTO ClubeDesportivo.treino(data, equipa)
		VALUES(@data2, @equipa2)
		SET @res = 0;
	END
GO