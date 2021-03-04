--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.UpdateSocio(@NIF INT,
	@pnome VARCHAR(20),
	@numero INT, 
	@lnome VARCHAR(20), 
	@type VARCHAR(30),
	@db DATE,
	@msd DATE,
	@med DATE,
	@address VARCHAR(100),
	@res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.pessoa WHERE NIF = @NIF)
	BEGIN
		IF EXISTS (SELECT * FROM ClubeDesportivo.socio WHERE numero = @numero)
		BEGIN
			
			IF @pnome <> ''  AND @lnome <> ''
			BEGIN
				UPDATE pessoa
				SET data_nasc = @db, morada = @address, primeiro_nome = @pnome, ultimo_nome = @lnome
				WHERE NIF = @NIF

				UPDATE socio
				SET tipo = @type, data_fim = @msd, data_inicio = @med
				WHERE numero = @numero;

				SET @res = 0;
			END
			ELSE
			BEGIN
				SET @res = 10;
			END
		END
		ELSE
		BEGIN
			SET @res = 100;
		END
	END
	ELSE
	BEGIN
		SET @res = 10;
	END
GO