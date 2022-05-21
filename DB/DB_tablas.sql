-------- Creamos la BD con el nombre de CMV --------

CREATE DATABASE CMV
GO 

-------- Usamos la BD que acabamos de crear --------
USE CMV

GO

-------- Creamos la tabla que contendrá los tipos de cuentas a las que un usuario podrá acceder --------
create table CAT_CMV_TIPO_CUENTA(
id_cuenta int primary key identity(1,1),
nombre_cuenta varchar(100)
)
Go

-------- Creamos la tabla que contendrá la información de los clientes dados de alta --------
create table TBL_CMV_CLIENTE(
id_cliente int primary key identity(1,1),
nombre varchar(50),
apellido_paterno varchar(50),
apellido_materno varchar(50),
rfc varchar(13),
curp varchar(18),
fecha_alta datetime
)
Go

-------- Creamos la tabla que contendrá la información de las cuentas que están asociadas a un cliente --------
create table TBL_CMV_TIPO_CUENTA(
id_cliente_cuenta int primary key identity(1,1),
id_cliente int,
id_cuenta int,
saldo_actual money,
fecha_contratacion datetime,
fecha_ultimo_movimento datetime
constraint id_cliente foreign key (id_cliente) references TBL_CMV_CLIENTE
on delete cascade
on update cascade,
constraint id_cuenta foreign key (id_cuenta) references CAT_CMV_TIPO_CUENTA
on delete cascade
on update cascade
)
Go
-------- Para evitar los errores al momento de actualizar y borra la información, eliminaremos y actualizaremos en cascada --------