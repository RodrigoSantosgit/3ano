
GO
CREATE PROC ClubeDesportivo.CreatePatrocinador(@NIF INT, @nome VARCHAR(60), @clube INT, @spLvl INT, @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.patrocionador WHERE NIF = @NIF)
	BEGIN

		SET @res = 1;

	END
	ELSE
	BEGIN
		
		IF @nome <> ''
		BEGIN
			INSERT INTO patrocionador(NIF, nome, clube, cond_patrocinio)
			VALUES(@NIF, @nome, @clube, @spLvl);

			SET @res = 0;
		END
		ELSE
			SET @res = 10;
	END
GO