-- Active: 1646654372192@@127.0.0.1@3306@fifa

use fifa;

CALL
    altaHabilidad (24, "...", "chilena");

CALL
    altaHabilidad (56, "...", "bicicleta");

CALL
    altaPosicion (12, "Delantero");

CALL
    altaPosicion (19, "Defensa");

SET @FUTBOLISTA = NULL;
CALL
    altaFutbolista (
        @FUTBOLISTA,
        "Pepe",
        '1999/02/23',
        "Sanchez",
        19,
        78,
        80,
        60,
        90
    );

CALL
    altaFutbolista (
        @FUTBOLISTA,
        "hola",
        '1999/02/23',
        "esta",
        12,
        74,
        85,
        60,
        96
    );

SET @JOGADOR = NULL;

CALL
    altaJugador (
        @JOGADOR,
        "Marco",
        "Antonio",
        "MarkitoElPro007",
        "87654321",
        1000
    );

SET @JOGADOR2 = NULL;

CALL
    altaJugador (
        @JOGADOR2,
        "Julio",
        "Cesar",
        "XxJulioGamerxX",
        "12345678",
        200
    );

CALL altaPosesion (1, 2);

CALL altaPosesion (2, 1);

CALL
    altaFutbolistaHabilidad (1, 24);

CALL
    altaFutbolistaHabilidad (2, 56);

CALL
    transferenciasActividas (1);

CALL
    publicar (2, 1, '2020/04/17', 200);

CALL
    comprar ('2020/04/17', '2020/05/17', 1);

CALL
    transferenciasActividas (2);

SELECT
    gananciasEntre (2, '2020/04/17', '2020/05/17');