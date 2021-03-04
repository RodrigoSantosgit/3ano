USE ClubeDesportivo
GO

GO
CREATE PROC ClubeDesportivo.DeleteTreinador(
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
		DELETE FROM ClubeDesportivo.treinador WHERE num_socio = @m_id;
        DELETE FROM ClubeDesportivo.treina WHERE treinador = @m_id;
		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO