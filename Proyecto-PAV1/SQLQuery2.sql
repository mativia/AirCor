------------------------------------------------------------
-- SCRIPT DE CREACIÓN DE BASE DE DATOS - AEROLÍNEA GRUPO10
-- Compatible con: SQL Server 2019 / 2022 y Visual Studio
-- Autor: Matías Via + ChatGPT
-- Fecha: 2025-11-04
------------------------------------------------------------

-- 1️⃣ Crear base de datos (si no existe)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'AEROLINEA_GRUPO10')
BEGIN
    CREATE DATABASE AEROLINEA_GRUPO10;
    PRINT 'Base de datos AEROLINEA_GRUPO10 creada correctamente.';
END
GO

-- 2️⃣ Usar la base de datos
USE AEROLINEA_GRUPO10;
GO

------------------------------------------------------------
-- PARTE 1: País, Provincia, Ciudad y Aeropuerto
------------------------------------------------------------
CREATE TABLE PAIS (
    IdPais INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE PROVINCIA (
    IdProvincia INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    IdPais INT NOT NULL,
    CONSTRAINT FK_PROVINCIA_PAIS FOREIGN KEY (IdPais) REFERENCES PAIS(IdPais)
);

CREATE TABLE CIUDAD (
    IdCiudad INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    IdProvincia INT NOT NULL,
    CONSTRAINT FK_CIUDAD_PROVINCIA FOREIGN KEY (IdProvincia) REFERENCES PROVINCIA(IdProvincia)
);

CREATE TABLE AEROPUERTO (
    CodigoAeropuerto INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    IdCiudad INT NOT NULL,
    Calle NVARCHAR(100) NULL,
    NroCalle NVARCHAR(10) NULL,
    Telefono NVARCHAR(20) NULL,
    CONSTRAINT FK_AEROPUERTO_CIUDAD FOREIGN KEY (IdCiudad) REFERENCES CIUDAD(IdCiudad)
);

-- Datos iniciales
INSERT INTO PAIS (Nombre) VALUES ('Argentina');
INSERT INTO PROVINCIA (Nombre, IdPais) VALUES ('Córdoba', 1);
INSERT INTO CIUDAD (Nombre, IdProvincia) VALUES ('Córdoba Capital', 1);
INSERT INTO AEROPUERTO (Nombre, IdCiudad, Calle, NroCalle, Telefono)
VALUES ('Aeropuerto Internacional de Córdoba', 1, 'Ruta E53', 'Km 8.5', '0351-4750881');

------------------------------------------------------------
-- PARTE 2: Modelos, Aviones, Vuelos y Tarifas
------------------------------------------------------------
CREATE TABLE MODELO (
    IdModelo INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE AVION (
    Matricula NVARCHAR(10) PRIMARY KEY,
    IdModelo INT NOT NULL,
    CantidadSalidasEmergencia INT NULL,
    Longitud DECIMAL(10,2) NULL,
    AlcanceVuelo DECIMAL(10,2) NULL,
    FilasPC INT NULL,
    AsientosPC INT NULL,
    FilasCB INT NULL,
    AsientosCB INT NULL,
    FilasCT INT NULL,
    AsientosCT INT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_AVION_MODELO FOREIGN KEY (IdModelo) REFERENCES MODELO(IdModelo)
);

CREATE TABLE DIA_SEMANA (
    IdDia INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(20) NOT NULL
);

CREATE TABLE DEFINICION_DE_VUELO (
    NroVuelo INT IDENTITY(1,1) PRIMARY KEY,
    MatriculaAvion NVARCHAR(10) NOT NULL,
    CodigoAeropuertoOrigen INT NOT NULL,
    CodigoAeropuertoDestino INT NOT NULL,
    HorarioPartida TIME NOT NULL,
    HorarioLlegada TIME NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_DEFVUELO_AVION FOREIGN KEY (MatriculaAvion) REFERENCES AVION(Matricula),
    CONSTRAINT FK_DEFVUELO_AEROPUERTO_ORIGEN FOREIGN KEY (CodigoAeropuertoOrigen) REFERENCES AEROPUERTO(CodigoAeropuerto),
    CONSTRAINT FK_DEFVUELO_AEROPUERTO_DESTINO FOREIGN KEY (CodigoAeropuertoDestino) REFERENCES AEROPUERTO(CodigoAeropuerto)
);

CREATE TABLE DEFINICION_DE_VUELO_X_DIAS (
    NroVuelo INT NOT NULL,
    IdDia INT NOT NULL,
    CONSTRAINT PK_DEFVUELO_X_DIA PRIMARY KEY (NroVuelo, IdDia),
    CONSTRAINT FK_DEFVUELOXDIA_DEFVUELO FOREIGN KEY (NroVuelo) REFERENCES DEFINICION_DE_VUELO(NroVuelo),
    CONSTRAINT FK_DEFVUELOXDIA_DIA FOREIGN KEY (IdDia) REFERENCES DIA_SEMANA(IdDia)
);

CREATE TABLE ESTADO_VUELO (
    IdEstadoVuelo INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(50) NOT NULL
);

CREATE TABLE VUELO (
    IdVuelo INT IDENTITY(1,1) PRIMARY KEY,
    NroVuelo INT NOT NULL,
    FechaPartida DATE NOT NULL,
    IdEstadoVuelo INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_VUELO_DEFVUELO FOREIGN KEY (NroVuelo) REFERENCES DEFINICION_DE_VUELO(NroVuelo),
    CONSTRAINT FK_VUELO_ESTADO FOREIGN KEY (IdEstadoVuelo) REFERENCES ESTADO_VUELO(IdEstadoVuelo)
);

CREATE TABLE CAMBIO_ESTADO_VUELO (
    IdCambio INT IDENTITY(1,1) PRIMARY KEY,
    IdVuelo INT NOT NULL,
    IdEstadoVuelo INT NOT NULL,
    FechaCambio DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_CAMBIO_VUELO FOREIGN KEY (IdVuelo) REFERENCES VUELO(IdVuelo),
    CONSTRAINT FK_CAMBIO_ESTADO FOREIGN KEY (IdEstadoVuelo) REFERENCES ESTADO_VUELO(IdEstadoVuelo)
);

CREATE TABLE TIPO_CLASE (
    IdTipoClase INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE TARIFA (
    NroVuelo INT NOT NULL,
    IdTipoClase INT NOT NULL,
    Importe DECIMAL(10,2) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT PK_TARIFA PRIMARY KEY (NroVuelo, IdTipoClase),
    CONSTRAINT FK_TARIFA_VUELO FOREIGN KEY (NroVuelo) REFERENCES DEFINICION_DE_VUELO(NroVuelo),
    CONSTRAINT FK_TARIFA_TIPOCLASE FOREIGN KEY (IdTipoClase) REFERENCES TIPO_CLASE(IdTipoClase)
);

-- Datos iniciales
INSERT INTO MODELO (Nombre) VALUES ('Boeing 737');
INSERT INTO AVION (Matricula, IdModelo, CantidadSalidasEmergencia, Longitud, AlcanceVuelo,
                   FilasPC, AsientosPC, FilasCB, AsientosCB, FilasCT, AsientosCT, Activo)
VALUES ('LV-ABC', 1, 8, 39.50, 5600, 2, 8, 3, 12, 25, 150, 1);

INSERT INTO DIA_SEMANA (Descripcion)
VALUES ('Lunes'), ('Martes'), ('Miércoles'), ('Jueves'), ('Viernes'), ('Sábado'), ('Domingo');

INSERT INTO ESTADO_VUELO (Descripcion)
VALUES ('Programado'), ('En vuelo'), ('Aterrizado'), ('Cancelado');

INSERT INTO TIPO_CLASE (Nombre, Activo)
VALUES ('Económica', 1), ('Business', 1);

INSERT INTO DEFINICION_DE_VUELO (MatriculaAvion, CodigoAeropuertoOrigen, CodigoAeropuertoDestino, HorarioPartida, HorarioLlegada, Activo)
VALUES ('LV-ABC', 1, 1, '08:00', '10:00', 1);

INSERT INTO DEFINICION_DE_VUELO_X_DIAS (NroVuelo, IdDia)
SELECT 1, IdDia FROM DIA_SEMANA WHERE Descripcion IN ('Lunes', 'Miércoles', 'Viernes');

INSERT INTO VUELO (NroVuelo, FechaPartida, IdEstadoVuelo, Activo)
VALUES (1, GETDATE(), 1, 1);

INSERT INTO TARIFA (NroVuelo, IdTipoClase, Importe, Activo)
VALUES (1, 1, 25000, 1), (1, 2, 40000, 1);

------------------------------------------------------------
-- PARTE 3: Pasajeros, Reservas y Sesiones
------------------------------------------------------------
CREATE TABLE TIPO_DOCUMENTO (
    IdTipoDocumento INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(50) NOT NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE SEXO (
    IdSexo INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(20) NOT NULL
);

CREATE TABLE PASAJERO (
    IdPasajero INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    IdTipoDocumento INT NOT NULL,
    NroDocumento NVARCHAR(20) NOT NULL,
    FechaNacimiento DATE NULL,
    IdSexo INT NULL,
    Telefono NVARCHAR(30) NULL,
    Email NVARCHAR(100) NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_PASAJERO_TIPODOC FOREIGN KEY (IdTipoDocumento) REFERENCES TIPO_DOCUMENTO(IdTipoDocumento),
    CONSTRAINT FK_PASAJERO_SEXO FOREIGN KEY (IdSexo) REFERENCES SEXO(IdSexo)
);

CREATE TABLE ASIENTO (
    IdAsiento INT IDENTITY(1,1) PRIMARY KEY,
    MatriculaAvion NVARCHAR(10) NOT NULL,
    Fila INT NOT NULL,
    Columna NVARCHAR(5) NOT NULL,
    IdTipoClase INT NOT NULL,
    CONSTRAINT FK_ASIENTO_AVION FOREIGN KEY (MatriculaAvion) REFERENCES AVION(Matricula),
    CONSTRAINT FK_ASIENTO_TIPOCLASE FOREIGN KEY (IdTipoClase) REFERENCES TIPO_CLASE(IdTipoClase)
);

CREATE TABLE RESERVA (
    IdReserva INT IDENTITY(1,1) PRIMARY KEY,
    IdVuelo INT NOT NULL,
    IdPasajero INT NOT NULL,
    FechaReserva DATETIME NOT NULL DEFAULT GETDATE(),
    IdAsiento INT NULL,
    Precio DECIMAL(10,2) NOT NULL,
    Estado NVARCHAR(30) NOT NULL DEFAULT 'Confirmada',
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_RESERVA_VUELO FOREIGN KEY (IdVuelo) REFERENCES VUELO(IdVuelo),
    CONSTRAINT FK_RESERVA_PASAJERO FOREIGN KEY (IdPasajero) REFERENCES PASAJERO(IdPasajero),
    CONSTRAINT FK_RESERVA_ASIENTO FOREIGN KEY (IdAsiento) REFERENCES ASIENTO(IdAsiento)
);

CREATE TABLE SESION (
    IdSesion INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    FechaHoraDesde DATETIME NOT NULL DEFAULT GETDATE(),
    FechaHoraHasta DATETIME NULL
);

-- Datos iniciales
INSERT INTO TIPO_DOCUMENTO (Descripcion, Activo)
VALUES ('DNI', 1), ('Pasaporte', 1), ('Cédula', 1);

INSERT INTO SEXO (Descripcion)
VALUES ('Masculino'), ('Femenino'), ('Otro');

INSERT INTO PASAJERO (Nombre, Apellido, IdTipoDocumento, NroDocumento, FechaNacimiento, IdSexo, Telefono, Email, Activo)
VALUES ('Juan', 'Pérez', 1, '40111222', '1989-05-21', 1, '3516123456', 'juanperez@gmail.com', 1);

INSERT INTO ASIENTO (MatriculaAvion, Fila, Columna, IdTipoClase)
VALUES ('LV-ABC', 1, 'A', 2), ('LV-ABC', 1, 'B', 2), ('LV-ABC', 10, 'C', 1), ('LV-ABC', 10, 'D', 1);

INSERT INTO RESERVA (IdVuelo, IdPasajero, IdAsiento, Precio, Estado, Activo)
VALUES (1, 1, 3, 25000, 'Confirmada', 1);

------------------------------------------------------------
-- PARTE 4: Usuarios, Perfiles y Permisos
------------------------------------------------------------
CREATE TABLE PERFIL (
    IdPerfil INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(100) NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE PERMISO (
    IdPermiso INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Descripcion NVARCHAR(100) NULL,
    Activo BIT NOT NULL DEFAULT 1
);

CREATE TABLE PERFIL_X_PERMISO (
    IdPerfil INT NOT NULL,
    IdPermiso INT NOT NULL,
    CONSTRAINT PK_PERFIL_X_PERMISO PRIMARY KEY (IdPerfil, IdPermiso),
    CONSTRAINT FK_PERFIL_X_PERMISO_PERFIL FOREIGN KEY (IdPerfil) REFERENCES PERFIL(IdPerfil),
    CONSTRAINT FK_PERFIL_X_PERMISO_PERMISO FOREIGN KEY (IdPermiso) REFERENCES PERMISO(IdPermiso)
);

CREATE TABLE USUARIO (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Contraseña NVARCHAR(100) NOT NULL,
    IdPerfil INT NOT NULL,
    Activo BIT NOT NULL DEFAULT 1,
    CONSTRAINT FK_USUARIO_PERFIL FOREIGN KEY (IdPerfil) REFERENCES PERFIL(IdPerfil)
);

-- Datos iniciales
INSERT INTO PERFIL (Nombre, Descripcion, Activo)
VALUES ('Administrador', 'Acceso total al sistema', 1),
       ('Empleado', 'Acceso limitado a operaciones', 1);

INSERT INTO PERMISO (Nombre, Descripcion, Activo)
VALUES ('GestionUsuarios', 'Permite crear, modificar o eliminar usuarios', 1),
       ('GestionVuelos', 'Permite gestionar vuelos y definiciones', 1),
       ('GestionReservas', 'Permite gestionar reservas de pasajeros', 1),
       ('VerReportes', 'Permite acceder a reportes', 1);

INSERT INTO PERFIL_X_PERMISO (IdPerfil, IdPermiso)
SELECT 1, IdPermiso FROM PERMISO;

INSERT INTO PERFIL_X_PERMISO (IdPerfil, IdPermiso)
SELECT 2, IdPermiso FROM PERMISO WHERE Nombre IN ('GestionReservas', 'VerReportes');

INSERT INTO USUARIO (Nombre, Contraseña, IdPerfil, Activo)
VALUES ('admin', 'admin', 1, 1),
       ('empleado', '1234', 2, 1);
