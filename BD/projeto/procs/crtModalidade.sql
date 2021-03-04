GO
CREATE PROC ClubeDesportivo.CreateModalidade(@id INT, @nome VARCHAR(50), @res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.modalidade WHERE codigo = @id)
	BEGIN
		SET @res = 1;
	END
	ELSE
	BEGIN
		INSERT INTO ClubeDesportivo.modalidade(codigo, nome)
		VALUES(@id, @nome)
		SET @res = 0;
	END
GO