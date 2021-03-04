
GO
CREATE PROC ClubeDesportivo.UpdateTreinador(
	@m_id INT,
	@nif INT,
	@pn VARCHAR(20),
	@ln VARCHAR(20),
	@address VARCHAR(100),
	@bd DATE,
	@msd DATE,
	@med DATE,
	@sal DECIMAL(9,2),
	@res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.treinador WHERE num_socio = @m_id)
	BEGIN
		UPDATE ClubeDesportivo.treinador
		SET salario = @sal
		WHERE num_socio = @m_id;

		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 10;
	END
GO