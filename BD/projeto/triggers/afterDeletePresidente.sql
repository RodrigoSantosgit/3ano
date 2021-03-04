USE ClubeDesportivo
GO

GO
CREATE TRIGGER ClubeDesportivo.afterDeletePresidente ON ClubeDesportivo.presidente
AFTER DELETE
AS
BEGIN

	DECLARE @ID AS INT

	SELECT @ID = num_socio FROM Deleted;

    UPDATE ClubeDesportivo.socio
    SET tipo = 'normal'
    WHERE numero = @id
END
GO