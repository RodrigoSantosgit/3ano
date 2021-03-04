DROP PROC ClubeDesportivo.CreateJogador
GO

GO
CREATE PROC ClubeDesportivo.CreateJogador(
	@m_id INT,
	@nif INT,
	@pn VARCHAR(20),
	@ln VARCHAR(20),
	@address VARCHAR(100),
	@bd DATE,
	@msd DATE,
	@med DATE,
	@sal DECIMAL(9,2),
    @equipa INT,
	@res INT OUTPUT)
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION t1

			IF EXISTS (SELECT * FROM ClubeDesportivo.jogador WHERE num_socio = @m_id)
            BEGIN

                SET @res = 1;
                ROLLBACK TRANSACTION t1
                
            END
            
            IF EXISTS (SELECT * FROM ClubeDesportivo.pessoa WHERE NIF = @nif)
            BEGIN
                IF EXISTS (SELECT * FROM ClubeDesportivo.socio WHERE numero = @m_id)
                BEGIN

                    UPDATE socio
                    SET tipo = 'atleta'
                    WHERE numero = @m_id

                END
                ELSE
                BEGIN

                    INSERT INTO socio(tipo, data_fim, data_inicio, NIF)
                    VALUES('atleta', @med, @msd, @nif)

                END

				END
			ELSE
            BEGIN

                INSERT INTO pessoa(NIF, primeiro_nome, ultimo_nome, morada, data_nasc)
                VALUES(@nif, @pn, @ln, @address, @bd)

                INSERT INTO socio(tipo, data_fim, data_inicio, NIF)
                VALUES('atleta', @med, @msd, @nif)

            END

            INSERT INTO jogador(num_socio, salario, equipa)
            VALUES(@m_id, @sal, @equipa)

            SET @res = 0;
            COMMIT TRANSACTION t1

	END TRY
	BEGIN CATCH
		SET @res = 10;
		ROLLBACK TRANSACTION t1
	END CATCH
END
GO