drop DATABASE if exists fifa;
CREATE DATABASE fifa;
USE fifa;

CREATE TABLE TipoHabilidad(
    NumHabilidad INT NOT NULL,
    Velocidad TINYINT,
    Remate TINYINT,
    Pase TINYINT,
    Defensa TINYINT,
    PRIMARY KEY (NumHabilidad)
);
CREATE TABLE Habilidad(
    idHabilidad INT NOT NULL,
    idFutbolista INT NOT NULL,
    NumHabilidad INT NOT NULL,
    Des_Habilidad VARCHAR(45) NOT NULL,
    PRIMARY KEY (idHabilidad),
    CONSTRAINT fk_Habilidad_numHabilidad FOREIGN KEY(NumHabilidad)
		REFERENCES TipoHabilidad (NumHabilidad)
);
CREATE TABLE Posicion(
    ubiCampo int NOT NULL,
    idFutbolista int NOT NULL,
    Nombre_Posicion VARCHAR(30) NOT NULL,
    PRIMARY KEY (ubiCampo)
);

CREATE TABLE Jugador(
    idJugador int NOT NULL,
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(30) NOT NULL,
    Usuario VARCHAR(15) NOT NULL,
    Contrasena CHAR(64) NOT NULL,
    Moneda INT UNSIGNED NOT NULL,
    ubicampo INT not NULL,
    PRIMARY KEY(idJugador),
    CONSTRAINT fk_jugador_ubicampo FOREIGN KEY(ubicampo)
		REFERENCES Posicion (ubiCampo)
);

CREATE Table futbolista(
    idfutbolista int NOT NULL ,
    idhabilidad int NOT NULL,
    transferencia int NOT NULL,
    nombre VARCHAR(30) NOT NULL,
    pellido VARCHAR(25) NOT NULL,
    nacimiento DATE NOT NULL,
    PRIMARY KEY (idfutbolista),
    CONSTRAINT fk_Habilidad_idHabilidad FOREIGN KEY(idHabilidad)
		REFERENCES Habilidad (idHabilidad)
);
CREATE TABLE Transferencia(
    Transferencia int NOT NULL,
    idfutbolista int NOT NULL,
    Precio int NOT NULL,
    Fecha_in DATETIME NOT NULL,
    Fecha_fin DATETIME NOT NULL,
    Comprador VARCHAR(15) NOT NULL,
    PRIMARY KEY (transferencia),
	CONSTRAINT fk_Transferencia_idfutbolista FOREIGN KEY(idfutbolista)
		REFERENCES futbolista (idfutbolista)
);
create table Posesion(
idJugador int not null,
cantfutbolista int not null,
idfutbolista int not null,
primary key (idjugador, idfutbolista),
CONSTRAINT fk_Posesion_idJugador FOREIGN KEY(idJugador)
		REFERENCES Jugador (idJugador),
CONSTRAINT fk_Posesion_idfutbolista FOREIGN KEY(idfutbolista)
		REFERENCES futbolista (idfutbolista)
);
