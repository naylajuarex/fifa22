/*Realizar los SP para dar de alta todas las entidades menos a Transferencia.*/

DELIMITER $$

DROP PROCEDURE
    IF EXISTS altaFutbolista $$
CREATE PROCEDURE
    altaFutbolista (
        unidFutbolista INT UNSIGNED,
        unnombre VARCHAR(30),
        unnacimiento DATE,
        unapellido VARCHAR(25),
        unubiCampo TINYINT UNSIGNED,
        unvelocidad TINYINT UNSIGNED,
        unremate TINYINT UNSIGNED,
        unpase TINYINT UNSIGNED,
        undefensa TINYINT UNSIGNED
    ) BEGIN
INSERT INTO
    Futbolista (
        idFutbolista,
        nombre,
        nacimiento,
        apellido,
        ubiCampo,
        velocidad,
        remate,
        pase,
        defensa
    )
VALUES (
        unidFutbolista,
        unnombre,
        unnacimiento,
        unapellido,
        unubiCampo,
        unvelocidad,
        unremate,
        unpase,
        undefensa
    );

END $$ DELIMITER $$
DROP PROCEDURE
    IF EXISTS altaHabilidad $$
CREATE PROCEDURE
    altaHabilidad (
        unidHabilidad TINYINT UNSIGNED,
        undescripcion VARCHAR(45),
        unnHabilidad VARCHAR (45)
    ) BEGIN
INSERT INTO
    Habilidad (
        idHabilidad,
        descripcion,
        nHabilidad
    )
VALUES (
        unidHabilidad,
        undescripcion,
        unnHabilidad
    );

END $$ DELIMITER $$
DROP PROCEDURE
    IF EXISTS altaPosicion $$
CREATE PROCEDURE
    altaPosicion (
        unubiCampo TINYINT,
        unnPosicion VARCHAR (30)
    ) BEGIN
INSERT INTO
    Posicion (ubiCampo, nPosicion)
VALUES (unubiCampo, unnPosicion);

END $$

DELIMITER $$

DROP PROCEDURE
    IF EXISTS altaPosesion $$
CREATE PROCEDURE
    altaPosesion (
        unidJugador MEDIUMINT UNSIGNED,
        unidFutbolista TINYINT UNSIGNED
    ) BEGIN
INSERT INTO
    Posesion (idJugador, idFutbolista)
VALUES (unidJugador, unidFutbolista);

END $$

DELIMITER $$

DROP PROCEDURE
    IF EXISTS altaJugador $$
CREATE PROCEDURE
    altaJugador (
        unidJugador MEDIUMINT UNSIGNED,
        unnombre VARCHAR (30),
        unapellido VARCHAR (30),
        unusuario VARCHAR(15),
        uncontrasena CHAR(64),
        unmoneda MEDIUMINT UNSIGNED
    ) BEGIN
INSERT INTO
    Jugador (
        Nombre,
        Apellido,
        Usuario,
        Contrasena,
        Moneda
    )
VALUES (
        unnombre,
        unapellido,
        unusuario,
        uncontrasena,
        unmoneda
    );

SET
    unidJugador = last_insert_id();

END $$ DELIMITER $$
DROP PROCEDURE
    IF EXISTS altaFutbolistaHabilidad $$
CREATE PROCEDURE
    altaFutbolistaHabilidad (
        unidFutbolista SMALLINT UNSIGNED,
        unidHabilidad TINYINT UNSIGNED
    ) BEGIN
INSERT INTO
    FutbolistaHabilidad (idFutbolista, idHabilidad)
VALUES (unidFutbolista, unidHabilidad);

END $$
/*Hacer un SP llamado ‘publicar’ que recibe como parámetro un identificador de jugador, un identificador de futbolista y la cantidad de monedas a pagar. Hacer un SP llamado ‘comprar’ que reciba como parámetro la identificación de una transferencia junto con la identificación del comprador, el SP tiene que cerrar la transferencia.*/

DELIMITER $$

DROP PROCEDURE
    IF EXISTS publicar $$
CREATE PROCEDURE
    publicar (
        unidVendedor MEDIUMINT UNSIGNED,
        unidFutbolista SMALLINT UNSIGNED,
        unprecio MEDIUMINT UNSIGNED
    ) BEGIN
INSERT INTO
    Transferencia (
        idVendedor,
        idFutbolista,
        precio
    )
VALUES (
        unidVendedor,
        unidFutbolista,
        unprecio
    );

END $$

DELIMITER $$

DROP PROCEDURE
    IF EXISTS comprar $$
CREATE PROCEDURE
    comprar (
        unfyhPublicado DATETIME,
        unidComprador MEDIUMINT UNSIGNED
    ) BEGIN
INSERT INTO
    Transferencia (fyhPublicado, idComprador)
VALUES (unfyhPublicado, unidComprador);

END $$
/*Realizar el SP ‘transferenciasActividas’ que reciba por parámetro la identificación de un futbolista y devuelva un listado de las transferencias activas (aquellas no exitosas) donde se encuentra ese futbolista, ordenadas por fecha de publicación ascendentemente.*/

DELIMITER $$

DROP PROCEDURE
    IF EXISTS transferenciasActividas $$
CREATE PROCEDURE
    transferenciasActividas(
        unidFutbolista MEDIUMINT UNSIGNED
    ) BEGIN
SELECT idFutbolista
FROM Tranferencia
WHERE
    idFutbolista = unIdFutbolista
    AND fyhPublicado < CURDATE()
    AND fyhTerminado > CURDATE()
ORDER BY fyhPublicado asc;

END $$
/*Realizar el SF ‘gananciasEntre’ que reciba como parámetro la identificación de un jugador y 2 fechas, la función tiene que retornar la sumatoria de monedas por las transferencias existosas de ese jugador entre esas 2 fechas.*/

DELIMITER $$

DROP FUNCTION
    IF EXISTS gananciasEntre $$
CREATE FUNCTION
    gananciasEntre (
        unidJugador MEDIUMINT UNSIGNED,
        unfyhPublicado DATETIME,
        unfyhTerminado DATETIME
    ) RETURNS INT READS SQL DATA BEGIN DECLARE resultado INT;

SELECT
    SUM (moneda * fyhTerminado) INTO resultado
FROM Jugador
    JOIN Transferencia ON idVendedor = idJugador
WHERE
    fyhTerminado BETWEEN unfyhPublicado AND unfyhTerminado;

RETURN resultado;

END $$