USE SuperheroesDb
CREATE TABLE SuperHero(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Hero_name nvarchar(25) NULL,
Alias nvarchar(100) NULL,
Origin nvarchar(100) NULL
)
CREATE TABLE Assistant(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Assistant_name nvarchar(25) NULL
)
CREATE TABLE Power(
Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
Power_name nvarchar(25) NULL,
Power_Description nvarchar(100) NULL
)