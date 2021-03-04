--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.DeleteSocio(@NIF INT,
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
			
			IF EXISTS (SELECT * FROM ClubeDesportivo.jogador WHERE num_socio = @numero)
			BEGIN
				DELETE FROM ClubeDesportivo.jogador WHERE num_socio = @numero;
			END

			IF EXISTS (SELECT * FROM ClubeDesportivo.treinador WHERE num_socio = @numero)
			BEGIN
				DELETE FROM ClubeDesportivo.treinador WHERE num_socio = @numero;
			END

			IF EXISTS (SELECT * FROM ClubeDesportivo.presidente WHERE num_socio = @numero)
			BEGIN
				DELETE FROM ClubeDesportivo.presidente WHERE num_socio = @numero;
			END

			DELETE FROM ClubeDesportivo.socio WHERE numero = @numero;

			DELETE FROM ClubeDesportivo.pessoa WHERE NIF = @NIF;

			SET @res = 0;

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