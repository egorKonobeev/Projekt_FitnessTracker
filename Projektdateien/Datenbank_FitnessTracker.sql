IF DB_ID(N'FitnessTracker') IS NULL
	CREATE DATABASE FitnessTracker;
GO

USE FitnessTracker;
GO

IF OBJECT_ID('Trainingsession') IS NOT NULL
	DROP TABLE Trainingsession;
	GO

IF OBJECT_ID('Uebung') IS NOT NULL
	DROP TABLE Uebung;
	GO

IF OBJECT_ID('Training') IS NOT NULL
	DROP TABLE Training;
	GO

IF OBJECT_ID('Benutzer') IS NOT NULL
	DROP TABLE Benutzer;
	GO

CREATE TABLE Benutzer (
BenutzerID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Benutzername NVARCHAR(100) NOT NULL,
Geburtsdatum DATE,
Email NVARCHAR(100),
Tagesziel_in_Kcal INT
);
GO

CREATE TABLE Training (
TrainingID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Dauer INT,
Kalorienverbrauch FLOAT,
BenutzerID INT,
CONSTRAINT fk_benutzer_performance FOREIGN KEY (BenutzerID)
REFERENCES Benutzer(BenutzerID)
);
GO

CREATE TABLE Uebung (
UebungID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Uebungname NVARCHAR(100) NOT NULL,
Wiederholungen INT,
Dauer DATETIME,
);
GO

CREATE TABLE Trainingsession (
TrainingID INT,
UebungID INT,
CONSTRAINT pk_training_uebung PRIMARY KEY (TrainingID, UebungID)
);
GO