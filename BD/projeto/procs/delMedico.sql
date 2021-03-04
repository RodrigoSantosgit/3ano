USE ClubeDesportivo
GO

GO
CREATE PROC ClubeDesportivo.DeleteMedico(
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
    AND EXISTS(SELECT * FROM ClubeDesportivo.medico WHERE NIF = @nif)
	BEGIN
        DELETE FROM ClubeDesportivo.medico WHERE num_ordem_medicos = @num;
		DELETE FROM ClubeDesportivo.pessoa WHERE NIF = @nif;
		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO