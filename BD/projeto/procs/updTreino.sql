
GO
CREATE PROC ClubeDesportivo.UpdateTreino(@equipa INT, @data DATE, @equipa2 INT, @data2 DATE, @res INT OUTPUT)
AS
    PRINT @data
	IF EXISTS (SELECT * FROM ClubeDesportivo.treino WHERE equipa = @equipa AND @data = data)
	BEGIN
		UPDATE ClubeDesportivo.treino
		SET equipa = @equipa2, data = @data2
		WHERE equipa = @equipa AND @data = data;

		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 10;
	END
GO