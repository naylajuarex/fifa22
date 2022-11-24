/*Administrador: desde la terminal donde corre el sistema, puede ver todo y dar de alta posiciones, habilidades y futbolistas.
 Jugadores: Pueden ver todo desde cualquier terminal.
 Sistema: desde cualquier terminal puede:
 ver Jugadores y Futbolistas.
 ver, dar de alta y eliminar Transferencias. También puede actualizar solo  la fecha y hora de la transferencia y el identificador del comprador.*/

USE fifa;

DROP USER
    IF EXISTS 'Administrador' @'localhost';

CREATE USER
    'Administrador' @'localhost' IDENTIFIED BY 'PassAdministrador';

GRANT
SELECT
    ON fifa.* TO 'Administrador' @'localhost';

GRANT
INSERT
    ON fifa.Posicion TO 'Administrador' @'localhost';

GRANT
INSERT
    ON fifa.Habilidad TO 'Administrador' @'localhost';

GRANT
INSERT
    ON fifa.Futbolista TO 'Administrador' @'localhost';

DROP USER
    IF EXISTS 'Jugadores' @'%';

CREATE USER
    'Jugadores' @'%' IDENTIFIED BY 'PassJugadores';

GRANT
SELECT
    ON fifa.* TO 'Jugadores' @'%';

DROP USER
    IF EXISTS 'Sistema' @'%';

CREATE USER
    'Sistema' @'%' IDENTIFIED BY 'PassSistema';

GRANT
SELECT
    ON fifa.Jugador TO 'Sistema' @'%';

GRANT
SELECT
    ON fifa.Futbolista TO 'Sistema' @'%';

GRANT
INSERT,
DELETE
    ON fifa.Transferencia TO 'Sistema' @'%';

GRANT
UPDATE (fyhTerminado, idComprador) ON fifa.Transferencia TO 'Sistema' @'%';