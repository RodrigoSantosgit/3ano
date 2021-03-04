--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.UpdateClube(@NIF INT, @nome VARCHAR(80), @web_site VARCHAR(100), @sede VARCHAR(100), @res INT OUTPUT)
AS
	
	IF EXISTS (SELECT * FROM ClubeDesportivo.clube_desportivo WHERE NIF = @NIF)
	BEGIN
		UPDATE clube_desportivo
		SET nome = @nome, web_site = @web_site, sede = @sede
		WHERE NIF = @NIF;

		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO