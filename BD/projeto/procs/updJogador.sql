USE ClubeDesportivo
GO

GO
CREATE PROC ClubeDesportivo.UpdateJogador(
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
	IF EXISTS (SELECT * FROM ClubeDesportivo.jogador WHERE num_socio = @m_id)
    AND EXISTS (SELECT * FROM ClubeDesportivo.equipa WHERE ID = @equipa)
	BEGIN
		UPDATE ClubeDesportivo.jogador
		SET salario = @sal,
        equipa = @equipa
		WHERE num_socio = @m_id;

		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 10;
	END
GO