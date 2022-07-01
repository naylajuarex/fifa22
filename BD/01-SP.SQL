/*Realizar los SP para dar de alta todas las entidades menos a Transferencia.*/

DELIMITER $$
DROP PROCEDURE IF EXISTS altaFutbolista $$
CREATE PROCEDURE altafutbolista (unidfutbolista INT UNSIGNED, unnombre VARCHAR(30), unnacimiento DATE, unapellido VARCHAR(25), unidhabilidad INT, unubiCampo INT)
BEGIN
INSERT Futbolista (idfutbolista, nombre, nacimiento, apellido, idHabilidad, ubiCampo)
VALUES (unidfutbolista, unnombre, unnacimiento, unapellido, unidhabilidad, unubiCampo);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altahabilidad $$
CREATE PROCEDURE altahabilidad (unidhabilidad INT, undeshabilidad VARCHAR(45))
BEGIN
INSERT Habilidad (idHabilidad, DesHabilidad)
VALUES (unidhabilidad, undeshabilidad);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altatipohabilidad $$
CREATE PROCEDURE altatipohabilidad (unidhabilidad INT, unvelocidad TINYINT, unremate TINYINT, unpase TINYINT, undefensa TINYINT)
BEGIN
INSERT tipoHabilidad (idHabilidad, Velocidad, Remate, Pase, Defensa)
VALUES (unidhabilidad, unvelocidad, unremate, unpase, undefensa);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaposicion $$
CREATE PROCEDURE altaposicion (unubiCampo INT, unNomPosicion VARCHAR (30))
BEGIN
INSERT Posicion (ubiCampo, NomPosicion)
VALUES (unubiCampo, unNomPosicion);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaposesion $$
CREATE PROCEDURE altaposesion (unidjugador INT, uncantfutbolistas INT UNSIGNED, unidfutbolista INT UNSIGNED)
BEGIN
INSERT Posesion (idjugador, cantfutbolistas, idfutbolista)
VALUES (unidjugador, uncantfutbolistas, unidfutbolista);
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altajugador $$
CREATE PROCEDURE altajugador (unidjugador INT, unnombre VARCHAR (30), unapellido VARCHAR (30), unusuario VARCHAR(15), uncontrasena CHAR(64), unmoneda INT UNSIGNED, unTransferen INT,unubiCampo INT UNSIGNED)
BEGIN
INSERT jugador (idjugador, Nombre, Apellido, Usuario, Contrasena, Moneda, Transferen,ubiCampo)
VALUES (unidjugador, unnombre, unapellido, unusuario, uncontrasena, unmoneda, unTransferen,unubiCampo);
END $$

/*Hacer un SP llamado ‘publicar’ que recibe como parámetro un identificador de jugador, un identificador de futbolista y la cantidad de monedas a pagar.
Hacer un SP llamado ‘comprar’ que reciba como parámetro la identificación de una transferencia junto con la identificación del comprador, el SP tiene que cerrar la transferencia.*/

DELIMITER $$
DROP PROCEDURE IF EXISTS publicar $$
CREATE PROCEDURE publicar(unidjugador INT, unidfutbolista INT, unmonedas INT UNSIGNED)
BEGIN
END $$
DELIMITER $$
DROP PROCEDURE IF EXISTS comprar $$
CREATE PROCEDURE comprar(unTransferen INT, unComprador VARCHAR(15))
BEGIN
END $$

/*Realizar el SP ‘transferenciasActividas’ que reciba por parámetro la identificación de un futbolista y devuelva un listado de las transferencias activas (aquellas no exitosas)
donde se encuentra ese futbolista, ordenadas por fecha de publicación ascendentemente.*/

DELIMITER $$
DROP PROCEDURE IF EXISTS transferenciasActividas $$
CREATE PROCEDURE transferenciasActividas(unidfutbolista INT)
BEGIN
        SELECT t.transfer
        FROM futbolista f
        JOIN Posesion p on p.idFutbolista = f.idFutbolista
        JOIN Jugador j on j.idJugador = p.idJugador
        JOIN Transferencia t on t.transfer= j.transfer
        WHERE f.idFutbolista = unidfutbolista AND Fecha_in < CURDATE() AND Fecha_fIn > CURDATE()
        ORDER BY Fecha_in asc;
END $$ 

/*Realizar el SF ‘gananciasEntre’ que reciba como parámetro la identificación de un jugador y 2 fechas,
la función tiene que retornar la sumatoria de monedas por las transferencias existosas de ese jugador entre esas 2 fechas.*/

DELIMITER $$
DROP FUNCTION IF EXISTS gananciasEntre $$
CREATE FUNCTION gananciasEntre (unIDjugador INT, unFyhPublicado DATETIME, unFyhTerminado DATETIME)
RETURNS int
READs SQL DATA
BEGIN
    DECLARE resultado int;

    SELECT  SUM(moneda) INTO resultado
    FROM    Jugador J
    inner join Transferencia T ON T.transfer = J.transfer
    WHERE Fecha_in between unFyhPublicado and unFyhTerminado;
    RETURN resultado;
END $$
