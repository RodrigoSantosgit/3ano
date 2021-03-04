--USE ClubeDesportivo
--GO

GO
CREATE TRIGGER ClubeDesportivo.updatePresidente ON ClubeDesportivo.presidente
INSTEAD OF UPDATE
AS
BEGIN
	DECLARE @dFim AS DATE
	DECLARE @dInicio AS DATE
	DECLARE @sal AS DECIMAL(9,2)
	DECLARE @ID AS INT

	SELECT @dInicio = data_inicio_pres FROM inserted;
	SELECT @sal = salario FROM inserted;
	SELECT @dFim = date_fim_pres FROM inserted;
	SELECT @ID = num_socio FROM inserted;

	IF @dFim IS NULL
	BEGIN
		IF EXISTS (SELECT * FROM ClubeDesportivo.presidente WHERE date_fim_pres is NULL)
		BEGIN
			PRINT 'ERRO: Só pode haver um presidente ativo!'
		END
		ELSE
		BEGIN
			UPDATE ClubeDesportivo.presidente
			SET data_inicio_pres = @dInicio, date_fim_pres = @dFim, salario = @sal
			WHERE num_socio = @ID
		END
	END
	ELSE
	BEGIN
		UPDATE ClubeDesportivo.presidente
		SET data_inicio_pres = @dInicio, date_fim_pres = @dFim, salario = @sal
		WHERE num_socio = @ID
	END
END
GO