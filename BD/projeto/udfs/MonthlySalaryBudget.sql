CREATE FUNCTION ClubeDesportivo.MonthlySalaryBudget (@jodagor INT = 0, @pres INT = 0, @treinador INT = 0) returns DECIMAL(12,2)
AS
BEGIN
	DECLARE @budget AS DECIMAL(12,2)
	DECLARE @bPres AS DECIMAL(12,2)
	DECLARE @bTreinador AS DECIMAL(12,2)
	DECLARE @bJogador AS DECIMAL(12,2)

	IF @pres = 1
	BEGIN
		SELECT @bPres = sum(p.salario)
		FROM ClubeDesportivo.presidente AS p WHERE date_fim_pres IS NULL
	END
	ELSE
		SET @bPres = 0

	IF @treinador = 1
	BEGIN
		SELECT @bTreinador = sum(j.salario)
		FROM ClubeDesportivo.jogador AS j
	END
	ELSE
		SET @bTreinador = 0

	IF @jodagor = 1
	BEGIN
		SELECT @bJogador = sum(t.salario)
		FROM ClubeDesportivo.treinador AS t
	END
	ELSE
		SET @bJogador = 0

	SELECT @budget = @bPres + @bJogador + @bTreinador

	RETURN @budget
END
