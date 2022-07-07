/*Realizar los SP para dar de alta todas las entidades menos a Transferencia.*/

DELIMITER $$
DROP PROCEDURE IF EXISTS altaFutbolista $$
CREATE PROCEDURE altaFutbolista (unidFutbolista INT UNSIGNED, unnombre VARCHAR(30), unnacimiento DATE, unapellido VARCHAR(25), unubiCampo TINYINT UNSIGNED, unvelocidad TINYINT UNSIGNED, unremate TINYINT UNSIGNED, unpase TINYINT UNSIGNED, undefensa TINYINT UNSIGNED)
BEGIN
INSERT Futbolista (idfutbolista, nombre, nacimiento, apellido, idHabilidad, ubiCampo, velocidad, remate, pase,defensa)
VALUES (unidFutbolista, unnombre, unnacimiento, unapellido, unidHabilidad, unubiCampo, unvelocidad, unremate, unpase, undefensa);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaHabilidad $$
CREATE PROCEDURE altaHabilidad (unidHabilidad TINYINT UNSIGNED, undescripcion VARCHAR(45), unnHabilidad VARCHAR (45))
BEGIN
INSERT Habilidad (idHabilidad, descripcion, nHabilidad)
VALUES (unidhabilidad, undeshabilidad, nHabilidad);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaPosicion $$
CREATE PROCEDURE altaPosicion (unubiCampo TINYINT, unnPosicion VARCHAR (30))
BEGIN
INSERT Posicion (ubiCampo, nPosicion)
VALUES (unubiCampo, unnPosicion);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaPosesion $$
CREATE PROCEDURE altaPosesion (unidJugador MEDIUMINT UNSIGNED, unidFutbolista TINYINT UNSIGNED)
BEGIN
INSERT Posesion (idjugador, cantfutbolistas, idfutbolista)
VALUES (unidjugador, uncantfutbolistas, unidfutbolista);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaJugador $$
CREATE PROCEDURE altaJugador (unidJugador MEDIUMINT UNSIGNED, unnombre VARCHAR (30), unapellido VARCHAR (30), unusuario VARCHAR(15), uncontrasena CHAR(64), unmoneda MEDIUMINT UNSIGNED)
BEGIN
INSERT Jugador (idJugador, nombre, apellido, usuario, contrasena, moneda)
VALUES (unidJugador, unnombre, unapellido, unusuario, uncontrasena, unmoneda);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaFutbolistaHabilidad $$
CREATE PROCEDURE altaFutbolistaHabilidad (unidFutbolista SMALLINT UNSIGNED, unidHabilidad TINYINT UNSIGNED)
BEGIN
INSERT FutbolistaHabilidad (idFutbolista, idHabilidad)
VALUES (unidFutbolista, unidHabilidad)
END $$

/*Hacer un SP llamado ‘publicar’ que recibe como parámetro un identificador de jugador, un identificador de futbolista y la cantidad de monedas a pagar.
Hacer un SP llamado ‘comprar’ que reciba como parámetro la identificación de una transferencia junto con la identificación del comprador, el SP tiene que cerrar la transferencia.*/

DELIMITER $$
DROP PROCEDURE IF EXISTS publicar $$
CREATE PROCEDURE publicar(unIdJugador MEDIUMINT UNSIGNED, unIdFutbolista SMALLINT UNSIGNED, unPrecio MEDIUMINT UNSIGNED)
BEGIN
    INSERT INTO publicar (idJugador, idFutbolista, precio)
        VALUES (unIdJugador, unIdFutbolista, unPrecio);
END$$
DELIMITER $$
DROP PROCEDURE IF EXISTS comprar $$
CREATE PROCEDURE comprar (unFyhPublicado DATETIME, unIdComprador MEDIUMINT UNSIGNED)
BEGIN
    INSERT INTO comprar (fyhPublicado, idComprador)
        VALUES (unFyhPublicado, unIdComprador);
END $$

/*Realizar el SP ‘transferenciasActividas’ que reciba por parámetro la identificación de un futbolista y devuelva un listado de las transferencias activas (aquellas no exitosas)
donde se encuentra ese futbolista, ordenadas por fecha de publicación ascendentemente.*/

DELIMITER $$
DROP PROCEDURE IF EXISTS transferenciasActividas $$
CREATE PROCEDURE transferenciasActividas(unIdFutbolista MEDIUMINT UNSIGNED)
BEGIN
        SELECT idFutbolista
        FROM Futbolista f
        JOIN Posesion p on p.idFutbolista = f.idFutbolista
        JOIN Jugador j on j.idJugador = p.idJugador
        JOIN Transferencia t on idJugador = idVendedor
        WHERE f.idFutbolista = unIdFutbolista AND fyhPublicado < CURDATE() AND fyhTerminado > CURDATE()
        ORDER BY fyhPublicado asc;
END $$

/*Realizar el SF ‘gananciasEntre’ que reciba como parámetro la identificación de un jugador y 2 fechas,
la función tiene que retornar la sumatoria de monedas por las transferencias existosas de ese jugador entre esas 2 fechas.*/

DELIMITER $$
DROP FUNCTION IF EXISTS gananciasEntre $$
CREATE FUNCTION gananciasEntre (unIdJugador MEDIUMINT UNSIGNED, unFyhPublicado DATETIME, unFyhTerminado DATETIME)
RETURNS INT
READ SQL DATA
BEGIN
    DECLARE resultado INT;

    SELECT  SUM(moneda) INTO resultado
    FROM Jugador j
    JOIN Posesion p ON p.idJugador = j.idJugador
    JOIN Transferencia t ON t.idVendedor = p.idJugador
    WHERE fyhPublicado BETWEEN unFyhPublicado AND unFyhTerminado
    RETURN resultado;
END $$
