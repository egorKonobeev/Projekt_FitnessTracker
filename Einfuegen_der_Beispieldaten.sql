USE FitnessTracker;
GO

--INSERT INTO Benutzer(Benutzername, Geburtsdatum, Email, Tagesziel_in_Kcal)
--VALUES  ('Egor Konobeev', '1999-06-04', 'egor.konobeeff@gmail.com', 500),
--		('Christiano Ronaldo', '1985-02-05', 'christiano.ronaldo@mail.com', 1000),
--		('Lionel Messi', '1987-06-24', 'lionel.messi@mail.com', 800),
--		('LeBron James', '1984-12-30', 'lebron.james@mail.com', 1500),
--		('James Harden', '1989-08-26', 'james.partyman@yahoo.com', NULL),
--		('Stephen Curry', '1988-03-14', 'steph.curry@gmail.com', 900),
--		('Giannis Antetokounmpo', '1994-12-06', 'greek.freek@yahoo.com', 1500),
--		('Kyrie Irving', '1992-03-23', 'kyrie.irving@mail.com', NULL),
--		('Robert Lewandowski', '1988-08-23', 'robert.lewandowski@gmail.com', 1000),
--		('Anthony Davis', '1993-03-11', 'anthony.davis@yahoo.com', 800);

INSERT INTO Vorbereiteter_Fitnessplan()

SELECT * FROM Benutzer;