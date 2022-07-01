
DROP DATABASE IF EXISTS fifa;
CREATE DATABASE fifa;
USE fifa;


CREATE TABLE Habilidad(
    idHabilidad INT NOT NULL,
    DesHabilidad VARCHAR(45) NOT NULL,
    PRIMARY KEY (idHabilidad),
    CONSTRAINT fk_habilidad_idHabilidad FOREIGN KEY(idHabilidad)
);

CREATE TABLE Posicion(
    ubiCampo INT UNSIGNED NOT NULL,
    NomPosicion VARCHAR(30) NOT NULL,
    PRIMARY KEY (ubiCampo)
);

CREATE Table futbolista(
    idfutbolista INT UNSIGNED NOT NULL ,
    idHabilidad INT NOT NULL,
    nombre VARCHAR(30) NOT NULL,
    apellido VARCHAR(25) NOT NULL,
    nacimiento DATE NOT NULL,
    ubiCampo INT UNSIGNED NOT NULL,
    Velocidad TINYINT,
    Remate TINYINT,
    Pase TINYINT,
    Defensa TINYINT,
    PRIMARY KEY (idfutbolista),
    CONSTRAINT fk_futbolista_idHabilidad FOREIGN KEY(idHabilidad)
        REFERENCES Habilidad (idHabilidad),
	CONSTRAINT fk_futbolista_ubicampo FOREIGN KEY(ubiCampo)
        REFERENCES Posicion (ubiCampo)
);

CREATE TABLE Transferencia(
    Transferen INT NOT NULL,
    Precio INT NOT NULL,
    Fecha_in DATETIME NOT NULL,
    Fecha_fin DATETIME NULL,
    Comprador VARCHAR(15) NOT NULL,
    PRIMARY KEY (Transferen)
);

CREATE TABLE Jugador(
    idJugador INT NOT NULL,
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(30) NOT NULL,
    Usuario VARCHAR(15) NOT NULL,
    Contrasena CHAR(64) NOT NULL,
    Moneda INT UNSIGNED NOT NULL,
    ubiCampo INT UNSIGNED NOT NULL,
    Transferen int NOT NULL,
    PRIMARY KEY(idJugador),
    CONSTRAINT fk_jugador_ubicampo FOREIGN KEY (ubiCampo)
        REFERENCES Posicion (ubiCampo),
    CONSTRAINT fk_Jugador_transferen FOREIGN KEY(transferen)
        REFERENCES Transferencia (transferen)
);

CREATE TABLE Posesion(
idJugador INT NOT NULL,
cantfutbolista INT UNSIGNED NOT NULL,
idfutbolista INT UNSIGNED NOT NULL,
PRIMARY KEY (idjugador, idfutbolista),
CONSTRAINT fk_Posesion_idJugador FOREIGN KEY(idJugador)
        REFERENCES Jugador (idJugador),
CONSTRAINT fk_Posesion_idfutbolista FOREIGN KEY(idfutbolista)
        REFERENCES futbolista (idfutbolista)
);
