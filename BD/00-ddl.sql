DROP DATABASE IF EXISTS fifa;
CREATE DATABASE fifa;
USE fifa;

CREATE TABLE Posicion(
    ubiCampo TINYINT UNSIGNED NOT NULL,
    nPosicion VARCHAR(20) NOT NULL,
    PRIMARY KEY (ubiCampo)
);

CREATE TABLE Habilidad(
    idHabilidad TINYINT UNSIGNED NOT NULL,
    nHabilidad VARCHAR (45) NOT NULL,
    descripcion VARCHAR (45) NOT NULL,
    PRIMARY KEY (idHabilidad)
);


CREATE TABLE Jugador(
    idJugador MEDIUMINT UNSIGNED NOT NULL,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(30) NOT NULL,
    usuario VARCHAR(15) NOT NULL,
    contrasena CHAR(64) NOT NULL,
    moneda INT UNSIGNED NOT NULL,
    PRIMARY KEY (idJugador)
);

CREATE TABLE Futbolista(
    idFutbolista SMALLINT UNSIGNED NOT NULL,
    ubiCampo TINYINT UNSIGNED NOT NULL,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(25) NOT NULL,
    nacimiento DATE NOT NULL,
    velocidad TINYINT UNSIGNED NOT NULL,
    remate TINYINT UNSIGNED NOT NULL,
    pase TINYINT UNSIGNED NOT NULL,
    defensa TINYINT UNSIGNED NOT NULL,
    PRIMARY KEY (idFutbolista),
	CONSTRAINT fk_Futbolista_ubiCampo FOREIGN KEY (ubiCampo)
        REFERENCES Posicion (ubiCampo)
);

CREATE TABLE Posesion(
idJugador MEDIUMINT NOT NULL,
idFutbolista SMALLINT UNSIGNED NOT NULL,
PRIMARY KEY (idJugador, idFutbolista)
);

CREATE TABLE FutbolistaHabilidad(
    idFutbolista SMALLINT UNSIGNED NOT NULL,
    idHabilidad TINYINT UNSIGNED NOT NULL,
    PRIMARY KEY (idFutbolista),
    CONSTRAINT fk_FutbolistaHabilidad_idHabilidad FOREIGN KEY (idHabilidad)
        REFERENCES Habilidad (idHabilidad)
);

CREATE TABLE Transferencia(
    fyhPublicado DATETIME NOT NULL, 
    idVendedor MEDIUMINT UNSIGNED NOT NULL,  
    idComprador MEDIUMINT UNSIGNED NOT NULL, 
    precio MEDIUMINT UNSIGNED NOT NULL,
    fyhTerminado DATETIME NOT NULL,
    idFutbolista SMALLINT UNSIGNED NOT NULL,
    PRIMARY KEY (fyhPublicado),
    CONSTRAINT fk_Transferencia_idFutbolista FOREIGN KEY (idFutbolista)
        REFERENCES Futbolista (idFutbolista),
    CONSTRAINT fk_Transferencia_idVendedor FOREIGN KEY (idVendedor)
        REFERENCES Jugador (idJugador),
    CONSTRAINT fk_Transferencia_idComprador FOREIGN KEY (idComprador)
        REFERENCES Jugador (idJugador)
);





