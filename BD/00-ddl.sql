DROP DATABASE IF EXISTS fifa;
CREATE DATABASE fifa;
USE fifa;

CREATE TABLE Posicion(
    ubiCampo TINYINT UNSIGNED NOT NULL,
    nPosicion VARCHAR(20) NOT NULL,
    PRIMARY KEY (ubiCampo)
);

CREATE TABLE Habilidad(
    idHabilidad TINYINT NOT NULL,
    nHabilidad VARCHAR (45) NOT NULL,
    descripcion VARCHAR (45) NOT NULL,
    PRIMARY KEY (idHabilidad)
);

CREATE TABLE Transferencia(
    fyhPublicado DATETIME NOT NULL, 
    idVendedor SMALLINT UNSIGNED NOT NULL,  
    idComprador SMALLINT UNSIGNED NOT NULL, 
    precio MEDIUMINT UNSIGNED NOT NULL,
    fyhTerminado DATETIME NOT NULL,
    PRIMARY KEY (fyhPublicado)
);

CREATE TABLE Jugador(
    idJugador INT NOT NULL,
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(30) NOT NULL,
    Usuario VARCHAR(15) NOT NULL,
    Contrasena CHAR(64) NOT NULL,
    Moneda INT UNSIGNED NOT NULL,
    PRIMARY KEY(idJugador)
);

CREATE TABLE Futbolista(
    idFutbolista MEDIUMINT UNSIGNED NOT NULL,
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
idFutbolista MEDIUMINT UNSIGNED NOT NULL,
PRIMARY KEY (idJugador, idFutbolista)
);

CREATE TABLE FutbolistaHabilidad(
    idFutbolista MEDIUMINT UNSIGNED NOT NULL,
    idHabilidad TINYINT UNSIGNED NOT NULL,
    PRIMARY KEY (idFutbolista),
    CONSTRAINT fk_FutbolistaHabilidad_idHabilidad FOREIGN KEY (idHabilidad)
    REFERENCES Habilidad (idHabilidad)
);




