--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.UpdateModalidade(@id INT, @nome VARCHAR(50), @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.modalidade WHERE codigo = @id) AND @nome <> ''
	BEGIN
		UPDATE ClubeDesportivo.modalidade
		SET codigo = @id, nome = @nome
		WHERE codigo = @id;

		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 10;
	END
GO