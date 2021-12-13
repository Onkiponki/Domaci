create database Firma
use Firma
create table firma(
	id int identity(0,1),
	naziv nvarchar(30),
	pib nvarchar(30),
	adresa nvarchar(30),
	email nvarchar(30),
	tekRacun nvarchar(30)
)
insert into firma
values('Nestle','12345678','Aksentija Topalovica 1','nestle@gmail.com','12345678'),
('Frikom','12321','asdsadsa','1231','141124'),
('Igor','12321','asdsadsa','1231','141124')

update firma
set naziv ='{0}', pib='{1}', adresa='{2}', email='{3}', tekRacun='{4}'
where id = {5}
