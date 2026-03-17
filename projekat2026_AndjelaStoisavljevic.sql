create database projekat2026_AndjelaStoisavljevic
use projekat2026_AndjelaStoisavljevic

create table korisnik
(
id int identity(1,1) primary key,
email varchar(40),
pass varchar(30),
uloga int
)