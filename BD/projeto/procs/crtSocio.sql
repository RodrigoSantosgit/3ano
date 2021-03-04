--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.CreateSocio(@NIF INT,
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
			
			SET @res  = 1;

		END
		ELSE
		BEGIN

			INSERT INTO socio(NIF, tipo, data_fim, data_inicio)
			VALUES(@NIF, @type, @msd, @med)

			SET @res = 0;

		END
	END
	ELSE
	BEGIN
		
		IF @pnome <> ''  AND @lnome <> ''
		BEGIN
			INSERT INTO pessoa(NIF, data_nasc, morada, primeiro_nome, ultimo_nome)
			VALUEs(@NIF, @db, @address, @pnome, @lnome)

			INSERT INTO socio(NIF, tipo, data_fim, data_inicio)
			VALUES(@NIF, @type, @msd, @med)

			SET @res = 0;

		END
		ELSE
			SET @res = 10;
	END
GO