CREATE VIEW ClubeDesportivo.ListTeamPlayers AS
	SELECT j.equipa, j.num_socio, p.primeiro_nome, p.ultimo_nome 
	FROM ClubeDesportivo.jogador AS j JOIN (ClubeDesportivo.socio AS s JOIN ClubeDesportivo.pessoa AS p ON s.NIF = p.NIF) ON j.num_socio = s.numero;