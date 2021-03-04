
GO
CREATE PROC ClubeDesportivo.DeleteJogo(@id INT, @data DATE, @local VARCHAR(100), @resultado VARCHAR(50), @equipa1 INT, @equipa2 INT, @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.jogo WHERE ID = @id)
	BEGIN
		DELETE FROM ClubeDesportivo.jogo WHERE ID = @id;
		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO