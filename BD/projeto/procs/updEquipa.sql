--USE ClubeDesportivo
--GO

GO
CREATE PROC ClubeDesportivo.UpdateEquipa(@id INT, 
		@nome VARCHAR(80), 
		@clube INT, 
		@local VARCHAR(100), 
		@code_modal INT, 
		@res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.equipa WHERE ID = @id) AND @nome <> ''
	BEGIN
		IF EXISTS (SELECT * FROM ClubeDesportivo.modalidade WHERE codigo = @code_modal)
		BEGIN

			UPDATE ClubeDesportivo.equipa
			SET nome = @nome, local_treino = @local, codigo_modal = @code_modal
			WHERE ID = @id;

			SET @res = 0;

		END
		ELSE
		BEGIN
			SET @res = 1000;
		END
	END
	ELSE
	BEGIN
		SET @res = 10;
	END
GO