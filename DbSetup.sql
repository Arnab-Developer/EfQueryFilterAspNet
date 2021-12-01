USE [master]
GO

CREATE DATABASE [StudentDb]
ON PRIMARY
( 
    NAME = N'StudentDb', 
    FILENAME = N'C:\db\StudentDb.mdf' , 
    SIZE = 8192KB , 
    MAXSIZE = UNLIMITED, 
    FILEGROWTH = 65536KB 
)
LOG ON 
( 
    NAME = N'StudentDbLog', 
    FILENAME = N'C:\db\StudentDb.ldf' , 
    SIZE = 8192KB , 
    MAXSIZE = 2048GB , 
    FILEGROWTH = 65536KB 
)
GO

USE [StudentDb]
GO

CREATE TABLE Students (Id INT NOT NULL PRIMARY KEY, [Name] VARCHAR(10) NOT NULL,
    TenantId INT NOT NULL)
GO

INSERT INTO Students (Id, [Name], TenantId)
VALUES (1, 'Jon', 1), (2, 'Bob', 1), (3, 'Mita', 2), (4, 'Rahul', 2)
GO