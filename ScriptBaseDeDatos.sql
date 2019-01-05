create database RENTACAR

go

use RENTACAR
go
create table CLIENTES
(id int IDENTITY (1, 1) not null primary key, nombre varchar(15) not null, apellido varchar(15) not null,
telefono varchar(20) not null, correo varchar(50) not null, pais varchar(20) not null, estado int not null)
go
create table VEHICULO
(id int IDENTITY (1, 1) not null, numeroDePlaca varchar(50) not null primary key, modelo char(15) not null,
año char(4) not null, estado int not null)
go
create table PRESTAMOS 
(id int IDENTITY (1,1) not null, idCliente int not null, placaDelVehiculo varchar(50) not null, fechaDePrestamo datetime not null,
fechaDeDevolucion datetime not null,dias int not null, montoDePrestamo float, prima float, montoACancelar float,estado int not null)