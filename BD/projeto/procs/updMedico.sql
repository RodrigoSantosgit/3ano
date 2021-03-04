USE ClubeDesportivo
GO

GO
CREATE PROC ClubeDesportivo.UpdateMedico(
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

		UPDATE ClubeDesportivo.medico
		SET especialidade = @especialidade,
            data_inicio = @data_inicio,
            data_fim = @data_fim
		WHERE num_ordem_medicos = @num;

        UPDATE ClubeDesportivo.pessoa
		SET primeiro_nome = @primeiro_nome,
            ultimo_nome = @ultimo_nome,
            morada = @morada,
            data_nasc = @data_nasc
		WHERE NIF = @nif;

		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 10;
	END
GO