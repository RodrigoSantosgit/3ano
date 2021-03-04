DROP PROC ClubeDesportivo.CreateJogo
GO

GO
CREATE PROC ClubeDesportivo.CreateJogo(@id INT, @data DATE, @local VARCHAR(100), @resultado VARCHAR(50), @equipa1 INT, @equipa2 INT, @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.jogo WHERE ID = @id)
	BEGIN
		SET @res = 1;
	END
	ELSE
	BEGIN
		INSERT INTO ClubeDesportivo.jogo(data, local, resultado, equipa1, equipa2)
		VALUES(@data, @local, @resultado, @equipa1, @equipa2)
		SET @res = 0;
	END
GO