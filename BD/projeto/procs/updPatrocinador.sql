--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.UpdatePatrocinador(@NIF INT, @nome VARCHAR(60), @clube INT, @spLvl INT, @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.patrocionador WHERE NIF = @NIF)
	BEGIN

		UPDATE patrocionador
		SET nome = @nome, clube = @clube, cond_patrocinio = @spLvl
		WHERE NIF = @NIF;

		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO