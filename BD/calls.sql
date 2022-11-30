-- Active: 1646654372192@@127.0.0.1@3306@fifa

use fifa;

CALL
    altaHabilidad (24, "...", "chilena");

CALL
    altaHabilidad(56, "...", "bicicleta");

CALL
    altaPosicion (12, "Delantero");

CALL
    altaPosicion (19, "Defensa")
CALL
    altaFutbolista (
        14,
        "Pepe",
        '1999/02/23',
        "Sanchez",
        12,
        78,
        80,
        60,
        90
    );

CALL
    altaFutbolista (
        15,
        "hola",
        '1999/02/23',
        "esta",
        19,
        74,
        85,
        60,
        96
    );

CALL
    altaJugador (
        1,
        "Marco",
        "Antonio",
        "MarkitoElPro007",
        "87654321",
        1000
    );

CALL
    altaJugador (
        2,
        "Julio",
        "Cesar",
        "XxJulioGamerxX",
        "12345678",
        200
    );

CALL altaPosesion (2, 15);

CALL altaPosesion (1, 14);

CALL
    altaFutbolistaHabilidad (14, 24);

CALL
    altaFutbolistaHabilidad (15, 56);

CALL
    transferenciasActividas (14);

CALL
    publicar (2, 15, '2020/04/17', 200);

CALL
    comprar ('2020/04/17', '2020/05/17', 1);

CALL
    transferenciasActividas (2);

SELECT
    gananciasEntre (2, '2020/04/17', '2020/05/17');