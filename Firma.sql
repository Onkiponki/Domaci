create database Firma
use Firma

create table firma(
	id int identity(1,1),
	naziv varchar(30),
	pib varchar(30),
	adresa varchar(30),
	email varchar(30),
	tekRacun varchar(30)
)
insert into firma
values('Nestle','12345678','Aksentija Topalovica 1','nestle@gmail.com','12345678')