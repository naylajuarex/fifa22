-- Active: 1646654372192@@127.0.0.1@3306@fifa

DROP DATABASE IF EXISTS fifa;

CREATE DATABASE fifa;

USE fifa;

CREATE TABLE
    Posicion(
        ubiCampo TINYINT UNSIGNED NOT NULL,
        nPosicion VARCHAR(20) NOT NULL,
        PRIMARY KEY (ubiCampo)
    );

CREATE TABLE
    Habilidad(
        idHabilidad TINYINT UNSIGNED NOT NULL,
        nHabilidad VARCHAR (45) NOT NULL,
        descripcion VARCHAR (45) NOT NULL,
        PRIMARY KEY (idHabilidad)
    );

CREATE TABLE
    Jugador(
        IdJugador MEDIUMINT UNSIGNED AUTO_INCREMENT NOT NULL,
        Nombre VARCHAR(30) NOT NULL,
        Apellido VARCHAR(30) NOT NULL,
        Usuario VARCHAR(15) NOT NULL,
        Contrasena CHAR(64) NOT NULL,
        Moneda INT UNSIGNED NOT NULL,
        PRIMARY KEY (IdJugador)
    );

CREATE TABLE
    Futbolista(
        idFutbolista SMALLINT UNSIGNED AUTO_INCREMENT NOT NULL,
        ubiCampo TINYINT UNSIGNED NOT NULL,
        nombre VARCHAR(30) NOT NULL,
        apellido VARCHAR(25) NOT NULL,
        nacimiento DATETIME NOT NULL,
        velocidad TINYINT UNSIGNED NOT NULL,
        remate TINYINT UNSIGNED NOT NULL,
        pase TINYINT UNSIGNED NOT NULL,
        defensa TINYINT UNSIGNED NOT NULL,
        PRIMARY KEY (idFutbolista),
        CONSTRAINT fk_Futbolista_ubiCampo FOREIGN KEY (ubiCampo) REFERENCES Posicion (ubiCampo)
    );

CREATE TABLE
    Posesion(
        idJugador MEDIUMINT UNSIGNED NOT NULL,
        idFutbolista SMALLINT UNSIGNED NOT NULL,
        PRIMARY KEY (idJugador, idFutbolista),
        CONSTRAINT fk_Posesion_idJugador FOREIGN KEY (idJugador) REFERENCES Jugador (idJugador),
        CONSTRAINT fk_Posesion_idFutbolista FOREIGN KEY (idFutbolista) REFERENCES Futbolista (idFutbolista)
    );

CREATE TABLE
    FutbolistaHabilidad(
        idFutbolista SMALLINT UNSIGNED NOT NULL,
        idHabilidad TINYINT UNSIGNED NOT NULL,
        PRIMARY KEY (idFutbolista, idHabilidad),
        CONSTRAINT fk_FutbolistaHabilidad_idHabilidad FOREIGN KEY (idHabilidad) REFERENCES Habilidad (idHabilidad)
    );

CREATE TABLE
    Transferencia(
        fyhPublicado DATETIME NOT NULL,
        idVendedor MEDIUMINT UNSIGNED NOT NULL,
        idComprador MEDIUMINT UNSIGNED NULL,
        precio MEDIUMINT UNSIGNED NOT NULL,
        fyhTerminado DATETIME NULL,
        idFutbolista SMALLINT UNSIGNED NOT NULL,
        PRIMARY KEY (
            fyhPublicado,
            idVendedor,
            idFutbolista
        ),
        CONSTRAINT fk_Transferencia_idFutbolista FOREIGN KEY (idFutbolista) REFERENCES Futbolista (idFutbolista),
        CONSTRAINT fk_Transferencia_idVendedor FOREIGN KEY (idVendedor) REFERENCES Jugador (IdJugador),
        CONSTRAINT fk_Transferencia_idComprador FOREIGN KEY (idComprador) REFERENCES Jugador (IdJugador)
    );