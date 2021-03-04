
USE ClubeDesportivo
GO

DROP PROC ClubeDesportivo.CreateMedico
GO


GO
CREATE PROC ClubeDesportivo.CreateMedico(
	@num INT,
	@nif INT,
    @primeiro_nome VARCHAR(20),
    @ultimo_nome VARCHAR(20),
	@especialidade VARCHAR(50),
	@morada VARCHAR(100),
	@data_inicio DATE,
	@data_fim DATE,
	@data_nasc DATE,
	@res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.medico WHERE num_ordem_medicos = @num)
	BEGIN
		SET @res = 1;
	END
    ELSE IF EXISTS(SELECT * FROM ClubeDesportivo.medico WHERE NIF = @nif)
    BEGIN
        SET @res = 2;
    END
	ELSE
	BEGIN
		INSERT INTO ClubeDesportivo.pessoa(NIF, primeiro_nome, ultimo_nome, data_nasc, morada)
		VALUES(@nif, @primeiro_nome, @ultimo_nome, @data_nasc, @morada)

        INSERT INTO ClubeDesportivo.medico(NIF ,especialidade, num_ordem_medicos, data_inicio, data_fim)
        VALUES (@nif, @especialidade, @num, @data_inicio, @data_fim)
		SET @res = 0;
	END
GO