/*Realizar un trigger para que antes de ingresar una fila en Transferencia, verifique que el usuario posea al futbolista en cuestión. En caso de no poseerlo, no se debe permitir la inserción de la fila y se debe mostrar la leyenda “El usuario nombreUsuario no posee a al futbolista NombreApellido"*/

DELIMITER $$
DROP TRIGGER IF EXISTS befinsTrasferencia $$
CREATE TRIGGER befinsTransferencia BEFORE INSERT ON Transferencia
FOR EACH ROW 
BEGIN
DECLARE Futbolistaj SMALLINT;
SELECT  INTO Futbolistaj


/* Realizar un trigger para que antes de efectuar una compra, se verifique que el usuario comprador, posea al menos la cantidad suficiente de monedas para la compra; en caso de no poseer las monedas, se debe cancelar la operación y mostrar la leyenda “Monedas insuficientes”. En caso de que el comprador ya posea al futbolista en cuestión, tampoco se debe permitir la operación y se debe mostrar la leyenda “Jugador en posesión”.*/

DELIMITER $$
DROP PROCEDURE IF EXISTS befinsTransferencia $$
CREATE TRIGGER befinsTransferencia BEFORE INSERT ON Tranferencia
FOR EACH ROW 

