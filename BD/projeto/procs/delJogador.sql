USE ClubeDesportivo
GO

GO
CREATE PROC ClubeDesportivo.DeleteJogador(
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
	BEGIN
        DELETE FROM ClubeDesportivo.joga WHERE jogador = @m_id;
        DELETE FROM ClubeDesportivo.assiste WHERE jogador = @m_id;
		DELETE FROM ClubeDesportivo.jogador WHERE num_socio = @m_id;
		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO