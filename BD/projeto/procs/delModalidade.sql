--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.DeleteModalidade(@id INT, @nome VARCHAR(50), @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.modalidade WHERE codigo = @id)
	BEGIN
		DELETE FROM ClubeDesportivo.modalidade WHERE codigo = @id AND nome = @nome;
		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO