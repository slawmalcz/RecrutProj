CREATE TABLE Stanowiska (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nazwa VARCHAR(255) NOT NULL,
	Placa_min MONEY NOT NULL,
	Placa_max MONEY NOT NULL
)
GO
INSERT INTO Stanowiska (Nazwa,Placa_min,Placa_max) VALUES
	('Szef',3800,4000),
	('Programista-Frontend',2500,3000),
	('Programista-Backend',2000,2500)
	;
GO
CREATE TABLE Pracownicy (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Imie VARCHAR(255),
	Nazwisko VARCHAR(255),
	Data_urodzenia DATE,
	Adres VARCHAR(255),
	Szef_ID INT ,
	Dzial_ID INT,
	Stanowisko_ID INT NOT NULL FOREIGN KEY REFERENCES Stanowiska(ID),
	Placa MONEY
)
GO
INSERT INTO Pracownicy (Imie,Nazwisko,Data_urodzenia,Adres,Szef_ID,Dzial_ID,Stanowisko_ID,Placa) VALUES 
	('Jan','Nowak','1967-02-04','Poznań ul.Sciegiennego 23/5',NULL,1,1,4000),
	('Adam','Buraczek','1982-06-09','Kórnik ul.Bosa 12A',1,1,2,3000),
	('Bartek','Rybak','1963-11-05','Pozań os.Lecha 54/120',1,1,2,2900),
	('Rafał','Koń','1988-10-15','Poznań ul.Polna 15',1,2,1,3900),
	('Antonio','Riviera','1955-08-01','Tulce ul.Przy szkole 20',4,2,3,2000),
	('Mieszko','Banan','1976-12-22','Tulce ul.Polna 2B',4,2,3,2300)
	;
GO
ALTER TABLE Pracownicy
ADD CONSTRAINT ID_SszefPracownik
FOREIGN KEY (Szef_ID) REFERENCES Pracownicy(ID);
GO
CREATE TABLE Ewaluacja(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Data DATE NOT NULL,
	Napisano_kodu INT NOT NULL DEFAULT 0,
	Obslozono_issue INT NOT NULL DEFAULT 0,
	Ocena_charakteru INT NOT NULL DEFAULT 0,
	Spoznienia INT NOT NULL DEFAULT 0,
	Blendow_w_kodzie INT NOT NULL DEFAULT 0,
	Przeczytanych_ksiazek INT NOT NULL DEFAULT 0,
	Ilosc_zakonczonych_projektow INT NOT NULL DEFAULT 0
)
GO
INSERT INTO Ewaluacja (Data,Napisano_kodu,Obslozono_issue,Ocena_charakteru,Spoznienia,Blendow_w_kodzie,Przeczytanych_ksiazek,Ilosc_zakonczonych_projektow) VALUES
	('01-01-2017',8,4,5,1,6,5,8),
	('01-01-2017',5,2,4,6,1,9,5),
	('01-01-2017',4,6,5,6,5,4,6),
	('01-01-2017',7,8,5,4,8,7,5),
	('01-01-2017',9,4,6,9,5,2,8),
	('01-01-2017',7,5,8,4,6,9,5)
	;
GO
CREATE TABLE EwaluacjaPracownikow (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Ewaluacja_ID INT NOT NULL FOREIGN KEY REFERENCES Ewaluacja(ID),
	Pracownik_ID INT NOT NULL FOREIGN KEY REFERENCES Pracownicy(ID)
)
GO
INSERT INTO EwaluacjaPracownikow(Ewaluacja_ID,Pracownik_ID) VALUES
	(1,1),
	(2,2),
	(3,3),
	(4,4),
	(5,5),
	(6,6)
	;
GO
CREATE TABLE Projekty (
	ID INT  NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nazwa VARCHAR(255) NOT NULL,
	Szef_ID INT NOT NULL FOREIGN KEY REFERENCES Pracownicy(ID),
	Data_rozpoczecia DATE NOT NULL,
	Data_zakonczenia DATE,
	Data_zakonczenia_planowana DATE NOT NULL
)
GO
INSERT INTO Projekty(Nazwa,Szef_ID,Data_rozpoczecia,Data_zakonczenia,Data_zakonczenia_planowana) VALUES
	('Analiza wewnętrzna',1,'2015-01-01',NULL,'2018-06-01'),
	('Upgrade hardewru',4,'2016-05-01','2016-07-15','2016-08-01'),
	('Kampania marketingowa',2,'2017-04-15',NULL,'2018-01-01')
	;
GO
CREATE TABLE Realizacje(
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	ID_Projektu INT NOT NULL FOREIGN KEY REFERENCES Projekty(ID),
	ID_Pracownika INT NOT NULL FOREIGN KEY REFERENCES Pracownicy(ID)
)
GO
INSERT INTO Realizacje(ID_Projektu,ID_Pracownika) VALUES
	(1,1),
	(1,2),
	(1,3),
	(2,4),
	(2,5),
	(3,2),
	(3,1),
	(3,3)
	;
GO
CREATE TABLE Dzialy (
	ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Nazwa VARCHAR(255) NOT NULL,
	ID_Szefa INT NOT NULL FOREIGN KEY REFERENCES Pracownicy(ID)
)
GO
INSERT INTO Dzialy(Nazwa,ID_Szefa) VALUES
	('Frontend',1),
	('Backend',4)
	;
GO
ALTER TABLE Pracownicy
ADD CONSTRAINT ID_SszefDzialu
FOREIGN KEY (Dzial_ID) REFERENCES Dzialy(ID);