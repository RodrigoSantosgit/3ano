CREATE VIEW ClubeDesportivo.ListPlayerTreatments AS
	SELECT a.medico, a.jogador, p.primeiro_nome, p.ultimo_nome 
	FROM ClubeDesportivo.assiste AS a JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.pessoa AS p ON s.NIF = p.NIF) ON a.jogador = s.numero;