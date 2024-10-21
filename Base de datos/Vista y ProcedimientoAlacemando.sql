CREATE PROCEDURE InsertarDatosReservacion
    @ApellidoCliente NVARCHAR(50),
    @NombreCliente NVARCHAR(50),
    @DNICliente NVARCHAR(15),
    @EmailCliente NVARCHAR(100),
    @TelefonoCliente NVARCHAR(15),
    @NumeroHabitacion INT,
    @FechaInicio DATE,
    @DiasEstancia INT
AS
BEGIN
    -- Insertar cliente si no existe
    DECLARE @ClienteID INT
    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE DNI = @DNICliente)
    BEGIN
        INSERT INTO Cliente (Apellido, Nombre, DNI, Email, Telefono)
        VALUES (@ApellidoCliente, @NombreCliente, @DNICliente, @EmailCliente, @TelefonoCliente)

        SET @ClienteID = SCOPE_IDENTITY()
    END
    ELSE
    BEGIN
        SELECT @ClienteID = ID FROM Cliente WHERE DNI = @DNICliente
    END

    -- Obtener ID de la habitación
    DECLARE @HabitacionID INT
    SELECT @HabitacionID = ID FROM Habitacion WHERE Habitacion.numero_habitacion = @NumeroHabitacion

    -- Insertar reservación
    INSERT INTO Reservacion (ID_Cliente, ID_Habitacion, fecha_inicio, dias_estancia)
    VALUES (@ClienteID, @HabitacionID, @FechaInicio, @DiasEstancia)

    -- Calcular monto y actualizar en la reservación
    DECLARE @PrecioHabitacion DECIMAL(18, 2)
    SELECT @PrecioHabitacion = Precio FROM Habitacion WHERE ID = @HabitacionID

    DECLARE @Monto DECIMAL(18, 2)
    SET @Monto = @PrecioHabitacion * @DiasEstancia

    UPDATE Reservacion
    SET Monto = @Monto
    WHERE ID_Cliente = @ClienteID AND ID_Habitacion = @HabitacionID AND Reservacion.fecha_inicio = @FechaInicio;
END

-- Ejemplo de llamada al procedimiento almacenado para insertar datos
DECLARE @ApellidoCliente NVARCHAR(50) = 'Canales';
DECLARE @NombreCliente NVARCHAR(50) = 'Martin';
DECLARE @DNICliente NVARCHAR(15) = '56419812';
DECLARE @EmailCliente NVARCHAR(100) = 'Canales@example.com';
DECLARE @TelefonoCliente NVARCHAR(15) = '965436655';
DECLARE @NumeroHabitacion INT = 203;
DECLARE @FechaInicio DATE = '2023-09-01';
DECLARE @DiasEstancia INT = 3;

-- Llamar al procedimiento almacenado para insertar datos
EXEC InsertarDatosReservacion
    @ApellidoCliente,
    @NombreCliente,
    @DNICliente,
    @EmailCliente,
    @TelefonoCliente,
    @NumeroHabitacion,
    @FechaInicio,
    @DiasEstancia;


CREATE VIEW VistaReservaciones AS
SELECT
    C.Apellido,
    C.Nombre,
    C.DNI,
    C.Telefono,
    H.numero_habitacion,
    H.tipo_habitacion,
    H.Precio,
    R.fecha_inicio,
    R.dias_estancia
FROM Cliente C
INNER JOIN Reservacion R ON C.ID = R.ID_Cliente
INNER JOIN Habitacion H ON R.ID_Habitacion = H.ID;