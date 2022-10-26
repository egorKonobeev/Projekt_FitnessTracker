USE FitnessTracker;
GO

INSERT INTO Benutzer(Benutzername, Geburtsdatum, Email, Tagesziel_in_Kcal)
VALUES  ('Egor Konobeev', '1999-06-04', 'egor.konobeeff@gmail.com', 500),
		('Christiano Ronaldo', '1985-02-05', 'christiano.ronaldo@mail.com', 1000),
		('Lionel Messi', '1987-06-24', 'lionel.messi@mail.com', 800),
		('LeBron James', '1984-12-30', 'lebron.james@mail.com', 1500),
		('James Harden', '1989-08-26', 'james.partyman@yahoo.com', NULL),
		('Stephen Curry', '1988-03-14', 'steph.curry@gmail.com', 900),
		('Giannis Antetokounmpo', '1994-12-06', 'greek.freek@yahoo.com', 1500),
		('Kyrie Irving', '1992-03-23', 'kyrie.irving@mail.com', NULL),
		('Robert Lewandowski', '1988-08-23', 'robert.lewandowski@gmail.com', 1000),
		('Anthony Davis', '1993-03-11', 'anthony.davis@yahoo.com', 800);

INSERT INTO Uebung(Uebungname,Wiederholungen,Dauer)
VALUES  ('Laufen', NULL, '00:10:00'),
		('Plank', NULL, '00:01:00'),
		('American Swing', 15, NULL),
		('Bankdruecken', 10, NULL),
		('Schulterdruecken', 10, NULL),
		('Dips', 10, NULL),
		('French Press', 10, NULL),
		('Trizepsstrecken', 10, NULL),
		('Ruderergometer', NULL, '00:10:00'),
		('Beinpresse', NULL, '00:15:00');

INSERT INTO Training(BenutzerID, Dauer, Kalorienverbrauch)
VALUES  (1, '01:00:00', 200),
		(2, '01:30:00', 300),
		(3, '00:50:00', 250),
		(4, '00:45:00', 200),
		(5, '01:02:00', 325),
		(6, '01:28:00', 450),
		(7, '02:00:00', 1000),
		(8, '01:50:00', 800),
		(9, '01:55:00', 766),
		(10, '00:36:00', 150);

SELECT * FROM Benutzer;
SELECT * FROM Uebung;
SELECT * FROM Training;