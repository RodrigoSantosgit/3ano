--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.DeletePresidente(@id INT, @nif INT, @res INT OUTPUT)
AS
	
	IF EXISTS (SELECT * FROM ClubeDesportivo.presidente WHERE num_socio = @id)
	BEGIN
		DELETE FROM ClubeDesportivo.presidente WHERE num_socio = @id;
		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO