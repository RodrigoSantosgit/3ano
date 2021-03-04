GO
CREATE PROC ClubeDesportivo.CreateEquipa(@id INT, 
		@nome VARCHAR(50), 
		@clube INT, 
		@local VARCHAR(100), 
		@code_modal INT, 
		@res INT OUTPUT)
AS
	IF EXISTS (SELECT * FROM ClubeDesportivo.equipa WHERE ID = @id)
	BEGIN
		SET @res = 1;
	END
	ELSE
	BEGIN
		IF EXISTS (SELECT * FROM ClubeDesportivo.modalidade WHERE codigo = @code_modal)
		BEGIN
			
			IF @nome <> ''
			BEGIN
				INSERT INTO ClubeDesportivo.equipa(nome, local_treino, clube, codigo_modal)
				VALUES(@nome, @local, @clube, @code_modal)
				SET @res = 0;
			END
			ELSE
			BEGIN
				SET @res = 10;
			END
		END
		ELSE
		BEGIN
			SET @res = 1000;
		END
	END
GO