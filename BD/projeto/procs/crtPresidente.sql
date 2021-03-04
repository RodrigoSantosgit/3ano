--USE ClubeDesportivo;
--GO

GO
CREATE PROC ClubeDesportivo.CreatePresidente(
	@m_id INT,
	@type VARCHAR(30),
	@nif INT,
	@pn VARCHAR(20),
	@ln VARCHAR(20),
	@address VARCHAR(100),
	@bd DATE,
	@msd DATE,
	@med DATE,
	@psd DATE,
	@ped DATE,
	@sal DECIMAL(9,2),
	@res INT OUTPUT)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;

			IF (EXISTS (SELECT * FROM ClubeDesportivo.presidente WHERE num_socio = @m_id))
			BEGIN

				SET @res = 1;

			END

			ELSE
			BEGIN

				IF (EXISTS (SELECT * FROM ClubeDesportivo.pessoa WHERE NIF = @nif))
				BEGIN
					IF (EXISTS (SELECT * FROM ClubeDesportivo.socio WHERE numero = @m_id))
					BEGIN

						UPDATE socio
						SET tipo = @type
						WHERE numero = @m_id;

					END
					ELSE
					BEGIN

						INSERT INTO socio(tipo, data_fim, data_inicio, NIF)
						VALUES(@type, @med, @msd, @nif);

					END

				END
				ELSE
				BEGIN
					
					INSERT INTO pessoa(NIF, primeiro_nome, ultimo_nome, morada, data_nasc)
					VALUES(@nif, @pn, @ln, @address, @bd);

					INSERT INTO socio(tipo, data_fim, data_inicio, NIF)
					VALUES(@type, @med, @msd, @nif);

				END

				DECLARE @num_socio INT;
				SELECT @num_socio = numero FROM ClubeDesportivo.socio WHERE NIF = @nif

				INSERT INTO presidente(num_socio, data_inicio_pres, date_fim_pres, salario, clube)
				VALUES(@num_socio, @psd, @ped, @sal, 999);

				SET @res = 0;

			END

			IF @@TRANCOUNT > 0
				COMMIT TRANSACTION;

	END TRY

	BEGIN CATCH
		SET @res = 10;
		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;
	END CATCH

END
GO