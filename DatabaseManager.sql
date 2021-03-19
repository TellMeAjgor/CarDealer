--Creating database--
IF NOT EXISTS (SELECT name FROM master.sys.databases WHERE name=N'CarDealer')
BEGIN
    CREATE DATABASE CarDealer
END

--Creating tabe Clients--
USE [CarDealer]
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Clients' AND TABLE_SCHEMA='dbo')
BEGIN
    CREATE TABLE Clients (
        Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
        FirstName nvarchar(20),
        LastName nvarchar(20),
        Email nvarchar(50),
        Phone nvarchar(11),
        Age tinyint,
        City nvarchar(30),
        Sex nvarchar(30)
    )
END

--Creating table Cars--
USE [CarDealer]
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Cars' AND TABLE_SCHEMA='dbo')
BEGIN
    CREATE TABLE Cars (
        Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
        Brand nvarchar(100),
        Model nvarchar(100),
        HorsePower int,
        Mileage int,
        Vin nvarchar(17),
        Condition nvarchar(50),
        Year nvarchar(4),
        Color nvarchar(20),
        Drive nvarchar(4),
        Description nvarchar(256)
    )
END

--Creating table Transactions--
USE [CarDealer]
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Transactions' AND TABLE_SCHEMA='dbo')
BEGIN
    CREATE TABLE Transactions (
        Id int PRIMARY KEY NOT NULL IDENTITY(1,1),
        CarId int FOREIGN KEY REFERENCES Cars(Id),
        ClientId int FOREIGN KEY REFERENCES Clients(Id),
        Price int,
        Date Date
    )
END
