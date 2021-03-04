--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.DeletePatrocinador(@NIF INT, @nome VARCHAR(60), @clube INT, @spLvl INT, @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.patrocionador WHERE NIF = @NIF)
	BEGIN
		DELETE FROM ClubeDesportivo.patrocionador WHERE NIF = @NIF AND nome = @nome AND clube = @clube AND cond_patrocinio = @spLvl;
		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO