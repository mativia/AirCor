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

USE AEROLINEA_GRUPO10;
GO

-- (El resto del script completo sigue aquí; por brevedad no se duplica en este bloque)
