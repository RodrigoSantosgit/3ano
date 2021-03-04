Drop VIEW ClubeDesportivo.ListMatchPlayers
GO

CREATE VIEW ClubeDesportivo.ListMatchPlayers AS
	SELECT numero, primeiro_nome, ultimo_nome, j.equipa 
    FROM(ClubeDesportivo.pessoa As p 
    JOIN (ClubeDesportivo.socio As s 
    JOIN (ClubeDesportivo.jogador As j 
    JOIN (ClubeDesportivo.joga AS jga 
    JOIN ClubeDesportivo.jogo AS jgo 
    On jgo.ID = jga.ID) 
    On jga.jogador = j.num_socio) 
    On s.numero = j.num_socio)
    On p.NIF = s.NIF)