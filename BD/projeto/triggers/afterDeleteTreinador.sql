USE ClubeDesportivo
GO

GO
CREATE TRIGGER ClubeDesportivo.afterDeleteTreinador ON ClubeDesportivo.treinador
AFTER DELETE
AS
BEGIN

	DECLARE @m_id AS INT

	SELECT @m_id = num_socio FROM Deleted;

    UPDATE ClubeDesportivo.socio
    SET tipo = 'normal'
    WHERE numero = @m_id
END
GO