USE ClubeDesportivo
GO

GO
CREATE PROC ClubeDesportivo.DeleteTreino(@equipa INT, @data DATE, @equipa2 INT, @data2 DATE, @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.treino WHERE equipa = @equipa AND data = @data)
	BEGIN
		DELETE FROM ClubeDesportivo.treino WHERE equipa = @equipa AND data = @data;
		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO