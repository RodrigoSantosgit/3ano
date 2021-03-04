CREATE SCHEMA ClubeDesportivo;
GO

CREATE TABLE ClubeDesportivo.pessoa(
	primeiro_nome VARCHAR(20) NOT NULL,
	ultimo_nome VARCHAR(20) NOT NULL,
	NIF INT PRIMARY KEY NOT NULL,
	data_nasc DATE not null,
	morada VARCHAR(100) NOT NULL
);

CREATE TABLE ClubeDesportivo.socio(
	numero INT IDENTITY(1,1) PRIMARY KEY not null,
	NIF INT,
	data_inicio DATE not null,
	data_fim DATE,
	tipo VARCHAR(30) not null,
	FOREIGN KEY (NIF) REFERENCES ClubeDesportivo.pessoa(NIF)
);

CREATE TABLE ClubeDesportivo.clube_desportivo(
	NIF INT PRIMARY KEY NOT NULL,
    sede VARCHAR(100) NOT NULL,
    web_site VARCHAR(100),
    nome VARCHAR (80)
);

CREATE TABLE ClubeDesportivo.modalidade(
    nome VARCHAR(50) NOT NULL,
    codigo INT PRIMARY KEY NOT NULL
);

CREATE TABLE ClubeDesportivo.patrocionador(
	nome VARCHAR(60) NOT NULL,
    cond_patrocinio INT NOT NULL,
	NIF INT PRIMARY KEY NOT NULL,
	clube INT NOT NULL,
	FOREIGN KEY (clube) REFERENCES ClubeDesportivo.clube_desportivo(NIF)
);

CREATE TABLE ClubeDesportivo.equipa(
	ID INT IDENTITY(1,1) NOT NULL,
    local_treino VARCHAR(100) NOT NULL,
    codigo_modal INT,
    clube INT NOT NULL,
    nome VARCHAR (80),
    FOREIGN KEY (clube) REFERENCES ClubeDesportivo.clube_desportivo(NIF),
	PRIMARY KEY (ID),
    FOREIGN KEY (codigo_modal) REFERENCES ClubeDesportivo.modalidade(codigo)
);

CREATE TABLE ClubeDesportivo.treino(
    data DATE NOT NULL,
    equipa INT,
    PRIMARY KEY (data, equipa),
	FOREIGN KEY (equipa) REFERENCES ClubeDesportivo.equipa(ID)
);

CREATE TABLE ClubeDesportivo.jogo(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    data DATE NOT NULL,
    local VARCHAR(100) NOT NULL,
    resultado VARCHAR(50),
    equipa1 INT,
    equipa2 INT,
	FOREIGN KEY (equipa1) REFERENCES ClubeDesportivo.equipa(ID),
    FOREIGN KEY (equipa2) REFERENCES ClubeDesportivo.equipa(ID)
);

CREATE TABLE ClubeDesportivo.jogador(
    salario DECIMAL(9,2) NOT NULL,
    num_socio INT,
    equipa INT,
    FOREIGN KEY (num_socio) REFERENCES ClubeDesportivo.socio(numero),
	PRIMARY KEY (num_socio),
	CONSTRAINT fk_equipa
		FOREIGN KEY (equipa)
		REFERENCES ClubeDesportivo.equipa(ID)
		ON DELETE SET NULL
);

CREATE TABLE ClubeDesportivo.treinador(
    salario DECIMAL(9,2) NOT NULL,
    num_socio INT PRIMARY KEY references ClubeDesportivo.socio(numero) NOT NULL
);

CREATE TABLE ClubeDesportivo.presidente(
	num_socio INT PRIMARY KEY references ClubeDesportivo.socio(numero) not null,
	clube INT,
	salario DECIMAL(9,2) not null,
	data_inicio_pres DATE not null,
	date_fim_pres DATE,
	FOREIGN KEY (clube) references ClubeDesportivo.clube_desportivo(NIF)

);

CREATE TABLE ClubeDesportivo.medico(
	num_ordem_medicos INT PRIMARY KEY not null,
	NIF INT not null,
	data_inicio DATE not null,
	data_fim DATE,
	especialidade VARCHAR(50),
	FOREIGN KEY (NIF) REFERENCES ClubeDesportivo.pessoa(NIF)
);

CREATE TABLE ClubeDesportivo.assiste(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	jogador INT,
	medico INT,
	CONSTRAINT fk_jogador
		FOREIGN KEY (jogador)
		REFERENCES ClubeDesportivo.jogador(num_socio)
		ON DELETE SET NULL,
	CONSTRAINT fk_medico
		FOREIGN KEY (medico)
		REFERENCES ClubeDesportivo.medico(num_ordem_medicos)
		ON DELETE SET NULL
);

CREATE TABLE ClubeDesportivo.joga(
	ID INT IDENTITY(1,1) NOT NULL,
	jogador INT,
	jogo_ID INT,
	PRIMARY KEY (ID),
	CONSTRAINT fk_jogador_joga
		FOREIGN KEY (jogador)
		REFERENCES ClubeDesportivo.jogador(num_socio)
		ON DELETE SET NULL,
	CONSTRAINT fk_jogo_ID
		FOREIGN KEY (jogo_ID)
		REFERENCES ClubeDesportivo.jogo(ID)
		ON DELETE SET NULL
);

CREATE TABLE ClubeDesportivo.treina(
	treinador INT not null,
	equipa INT not null,
	data_inicio DATE not null,
	data_fim DATE,
	FOREIGN KEY (treinador) REFERENCES ClubeDesportivo.treinador(num_socio),
	FOREIGN KEY (equipa) REFERENCES ClubeDesportivo.equipa(ID),
	PRIMARY KEY (treinador, equipa, data_inicio)
);