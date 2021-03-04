
GO
CREATE PROC ClubeDesportivo.UpdateJogo(@id INT, @data DATE, @local VARCHAR(100), @resultado VARCHAR(50), @equipa1 INT, @equipa2 INT, @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.jogo WHERE ID = @id) AND @data <> '' AND @local <> '' AND @resultado <> ''
	BEGIN
		UPDATE ClubeDesportivo.jogo
		SET data = @data, local = @local, resultado = @resultado, equipa1 = @equipa1, equipa2 = @equipa2
		WHERE ID = @id;

		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 10;
	END
GO