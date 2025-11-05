CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NombreUsuario NVARCHAR(50) NOT NULL,
    Clave NVARCHAR(50) NOT NULL,
    NombreCompleto NVARCHAR(100),
    Rol NVARCHAR(50)
);

INSERT INTO Usuarios (NombreUsuario, Clave, NombreCompleto, Rol)
VALUES ('admin', 'admin', 'Administrador del sistema', 'Administrador');
