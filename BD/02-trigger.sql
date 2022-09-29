/*Realizar un trigger para que antes de ingresar una fila en Transferencia, 
 verifique que el usuario posea al futbolista en cuestión. En caso de no poseerlo, 
 no se debe permitir la inserción de la fila y se debe mostrar la leyenda “El usuario nombreUsuario no posee a al futbolista NombreApellido"*/

/* Realizar un trigger para que antes de efectuar una compra, se verifique que el usuario comprador, 
 posea al menos la cantidad suficiente de monedas para la compra; en caso de no poseer las monedas, 
 se debe cancelar la operación y mostrar la leyenda “Monedas insuficientes”.*/

DELIMITER $$ 

DROP TRIGGER IF EXISTS NoPosee $$
CREATE TRIGGER
    NoPosee BEFORE
INSERT
    ON Transferencia FOR EACH ROW BEGIN IF (
        NOT EXISTS (
            SELECT *
            FROM Posesion
            WHERE
                idFutbolista = NEW.idFutbolista
                AND idJugador = NEW.idVendedor
        )
    ) THEN SIGNAL SQLSTATE '45000'
SET
    MESSAGE_TEXT = 'El usuario no posee al futbolista';

END IF;

IF (
    EXISTS (
        SELECT *
        FROM Jugador
        WHERE
            NEW.precio > moneda
            AND idJugador = NEW.idComprador
    )
) THEN SIGNAL SQLSTATE '45000'
SET
    MESSAGE_TEXT = 'Monedas insuficientes';

END IF;

END $$
/*En caso de que el comprador ya posea al futbolista en cuestión, 
 tampoco se debe permitir la operación y se debe mostrar la leyenda “Jugador en posesión”.*/

DELIMITER $$

DROP TRIGGER
    IF EXISTS TienePosesion $$
CREATE TRIGGER
    BefInsTienePosesion BEFORE
UPDATE
    ON Transferencia FOR EACH ROW BEGIN IF (
        EXISTS (
            SELECT *
            FROM Posesion
            WHERE
                idFutbolista = NEW.idFutbolista
                AND idJugador = NEW.idComprador
        )
    ) THEN SIGNAL SQLSTATE '45000'
SET
    MESSAGE_TEXT = 'Jugador en posesion';

END IF;

END $$