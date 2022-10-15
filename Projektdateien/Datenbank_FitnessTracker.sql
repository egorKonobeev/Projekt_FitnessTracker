IF DB_ID(N'FitnessTracker') IS NULL
	CREATE DATABASE FitnessTracker;
GO

USE FitnessTracker;
GO

IF OBJECT_ID('Benutzer') IS NOT NULL
	DROP TABLE Benutzer;
	GO

IF OBJECT_ID('Performance') IS NOT NULL
	DROP TABLE Performance;
	GO

IF OBJECT_ID('Eigener_Fitnessplan') IS NOT NULL
	DROP TABLE Eigener_Fitnessplan;
	GO

IF OBJECT_ID('Vorbereiteter_Fitnessplan') IS NOT NULL
	DROP TABLE Vorbereiteter_Fitnessplan;
	GO

CREATE TABLE Benutzer (
BenutzerID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Benutzername NVARCHAR(100) NOT NULL,
Geburtsdatum DATE,
Email NVARCHAR(100),
Tagesziel_in_Kcal INT
);

CREATE TABLE Performance (
PerformanceID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Benutzername NVARCHAR(100) NOT NULL,
Schritte INT,
Dauer DATETIME,
Kalorienverbrauch FLOAT,
Durchschnittliche_Geschwindigkeit FLOAT,
Distanz FLOAT,
BenutzerID INT,
CONSTRAINT fk_benutzer_performance FOREIGN KEY (BenutzerID)
REFERENCES Benutzer(BenutzerID)
);

CREATE TABLE Eigener_Fitnessplan (
EPlanID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
Benutzername NVARCHAR(100) NOT NULL,
Anzahl_uebungen INT,
Dauer DATETIME,
Kalorienverbrauch FLOAT,
BenutzerID INT,
CONSTRAINT fk_benutzer_eigener_fitnessplan FOREIGN KEY (BenutzerID)
REFERENCES Benutzer(BenutzerID)
);

CREATE TABLE Vorbereiteter_Fitnessplan (
VPlanID INT IDENTITY(1,1),
BenutzerID INT,
CONSTRAINT fk_benutzer_vorbereiteter_fitnessplan FOREIGN KEY (BenutzerID)
REFERENCES Benutzer(BenutzerID),
CONSTRAINT pk_benutzer_vorbereiteter_fitnessplan PRIMARY KEY (VPlanID, BenutzerID),
Anzahl_uebungen INT,
Dauer DATETIME,
Schwierigkeit TINYINT,
Kalorienverbrauch FLOAT,
);