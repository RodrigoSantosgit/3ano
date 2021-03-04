--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.DeleteEquipa(@id INT, 
		@nome VARCHAR(50),
		@clube INT, 
		@local VARCHAR(100), 
		@code_modal INT, 
		@res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.equipa WHERE ID = @id)
	BEGIN
		DELETE FROM ClubeDesportivo.equipa WHERE ID = @id AND nome = @nome;
		SET @res = 0;
	END
	ELSE
	BEGIN
		SET @res = 100;
	END
GO