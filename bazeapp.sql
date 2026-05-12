CREATE DATABASE projekat2026_AndjelaStoisavljevic;
use projekat2026_AndjelaStoisavljevic;
create table teren
(
id INT PRIMARY KEY IDENTITY(1,1),
tip VARCHAR(50) NOT NULL
)
create table trener
(
id INT PRIMARY KEY IDENTITY(1,1),
ime VARCHAR(50) NOT NULL,
prezime VARCHAR(50) NOT NULL,
kontakt VARCHAR(50) NOT NULL
)
create table raspored
(
id INT PRIMARY KEY IDENTITY(1,1),
radni_dan VARCHAR(50) NOT NULL,
trener_id INT NOT NULL,
FOREIGN KEY (trener_id) REFERENCES trener(id)
        ON DELETE CASCADE
)
CREATE TABLE tip_korisnika
(
    id INT PRIMARY KEY IDENTITY(1,1),
    naziv VARCHAR(50) NOT NULL
)
INSERT INTO tip_korisnika (naziv)
VALUES ('admin'), ('obican');
create table korisnik
(
id INT PRIMARY KEY IDENTITY(1,1),
ime VARCHAR(50) NOT NULL,
prezime VARCHAR(50) NOT NULL,
telefon VARCHAR(30),
email VARCHAR(100),
pass VARCHAR(100),
tip_id INT NOT NULL,
    FOREIGN KEY (tip_id) REFERENCES tip_korisnika(id)
)
create table status_termina
(
id INT PRIMARY KEY IDENTITY(1,1),
naziv VARCHAR(20) NOT NULL
)
INSERT INTO status_termina (naziv)
VALUES ('zakazan'), ('otkazan');
create table termini
(
id INT PRIMARY KEY IDENTITY(1,1),
tip VARCHAR(50) NOT NULL,
sezona VARCHAR(50) NOT NULL,
datum DATE NOT NULL,
trener_id INT NOT NULL,
teren_id INT NOT NULL,
pocetak TIME NOT NULL,
trajanje_min INT NOT NULL,
korisnik_id INT NULL,
status_id INT NOT NULL DEFAULT 1,
FOREIGN KEY (status_id) REFERENCES status_termina(id),
FOREIGN KEY (trener_id) REFERENCES trener(id),
FOREIGN KEY (teren_id) REFERENCES teren(id),
FOREIGN KEY (korisnik_id) REFERENCES korisnik(id)
)

INSERT INTO teren (tip) VALUES
('otvoren'),
('zatvoren'),
('otvoren'),
('zatvoren');

INSERT INTO trener (ime, prezime, kontakt) VALUES
('Marko', 'Markovic', '061111111'),
('Jovan', 'Jovanovic', '062222222'),
('Nikola', 'Nikolic', '063333333');


INSERT INTO raspored (radni_dan, trener_id) VALUES
('Ponedeljak', 1),
('Utorak', 1),
('Sreda', 2),
('Cetvrtak', 2),
('Petak', 3),
('Subota', 3);

INSERT INTO korisnik (ime, prezime, telefon, email, pass, tip_id) VALUES
('Petar', 'Petrovic', '064111111', 'petar@gmail.com', 1234, 2),
('Ana', 'Anic', '065222222', 'ana@gmail.com', 666,2),
('Ivana', 'Ivic', '066333333', 'ivana@gmail.com', 777, 2),
('Admin', 'Add', NULL, 'admin@gmail.com', 222, 1);


INSERT INTO termini (tip, sezona, datum, trener_id, teren_id, pocetak, trajanje_min, korisnik_id, status_id) VALUES
('trening', 'leto', '2026-05-01', 1, 1, '10:00', 60, 1, 1),
('trening', 'leto', '2026-05-02', 2, 2, '12:00', 90, 2, 1),
('mec', 'zima', '2026-12-10', 3, 3, '15:00', 120, 3, 1),
('trening', 'prolece', '2026-04-20', 1, 2, '09:00', 60, NULL, 2),
('mec', 'jesen', '2026-09-15', 2, 1, '18:00', 90, 1, 2),
('trening', 'zima', '2026-01-10', 3, 4, '20:00', 60, 2, 1);

ALTER TABLE trener ADD aktivan BIT DEFAULT 1;
UPDATE trener
SET aktivan = 1
WHERE aktivan IS NULL;


