drop DATABASE if exists fifa;
CREATE DATABASE fifa;
USE fifa;

CREATE TABLE TipoHabilidad(
    idHabilidad INT NOT NULL,
    Velocidad TINYINT,
    Remate TINYINT,
    Pase TINYINT,
    Defensa TINYINT,
    PRIMARY KEY (idhabilidad),
    CONSTRAINT fk_tipoHabilidad_idHabilidad FOREIGN KEY(idHabilidad)
    references habilidad(idhabilidad)
);
CREATE TABLE Habilidad(
    idHabilidad INT NOT NULL,
    DesHabilidad VARCHAR(45) NOT NULL,
    PRIMARY KEY (idHabilidad),
    CONSTRAINT fk_habilidad_idHabilidad FOREIGN KEY(idHabilidad)
		REFERENCES TipoHabilidad (idHabilidad)
);
CREATE Table futbolista(
    idfutbolista int NOT NULL ,
    idhabilidad int NOT NULL,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(25) NOT NULL,
    nacimiento DATE NOT NULL,
    ubicampo INT NOT NULL,
    PRIMARY KEY (idfutbolista),
    CONSTRAINT fk_Habilidad_idHabilidad FOREIGN KEY(idHabilidad)
		REFERENCES Habilidad (idHabilidad)
);
CREATE TABLE Posicion(
    ubiCampo int NOT NULL,
    NomPosicion VARCHAR(30) NOT NULL,
    PRIMARY KEY (ubiCampo)
);

CREATE TABLE Jugador(
    idJugador int NOT NULL,
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(30) NOT NULL,
    Usuario VARCHAR(15) NOT NULL,
    Contrasena CHAR(64) NOT NULL,
    Moneda INT UNSIGNED NOT NULL,
    ubicampo INT UNSIGNED NOT NULL,
    PRIMARY KEY(idJugador),
    CONSTRAINT fk_jugador_ubicampo FOREIGN KEY (ubicampo)
		REFERENCES Posicion (ubiCampo)
);

CREATE TABLE Transferencia(
    Transferen int NOT NULL,
    Precio int NOT NULL,
    Fecha_in DATETIME NOT NULL,
    Fecha_fin DATETIME NOT NULL,
    Comprador VARCHAR(15) NOT NULL,
    PRIMARY KEY (transferencia),
	CONSTRAINT fk_Transferencia_transferen FOREIGN KEY(transferen)
		REFERENCES jugador (transferen)
);

create table Posesion(
idJugador INT NOT NULL,
cantfutbolista INT NOT NULL,
idfutbolista INT UNSIGNED NOT NULL,
PRIMARY KEY (idjugador, idfutbolista),
CONSTRAINT fk_Posesion_idJugador FOREIGN KEY(idJugador)
		REFERENCES Jugador (idJugador),
CONSTRAINT fk_Posesion_idfutbolista FOREIGN KEY(idfutbolista)
		REFERENCES futbolista (idfutbolista)
);
