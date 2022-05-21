go
use CMV
go

------------------------- SP obtiene la información de los clientes -------------------------
go
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_obtener_cliente_alta')
DROP PROCEDURE sp_obtener_cliente_alta 

go
create procedure sp_obtener_cliente_alta
as
begin

select * from TBL_CMV_CLIENTE
end

go


------------------------- SP modifica la información de un cliente -------------------------
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_modificar_cliente')
DROP PROCEDURE sp_modificar_cliente

go

create procedure sp_modificar_cliente
	(
		@id_cliente int,
		@nombre varchar(50),
		@apellido_paterno varchar(50),
		@apellido_materno varchar(50),
		@rfc varchar(13),
		@curp varchar(18),
		@fecha_alta datetime
	)
as
begin

update 
	TBL_CMV_CLIENTE 
set 
	nombre = @nombre, 
	apellido_paterno =@apellido_paterno, 
	apellido_materno = @apellido_materno, 
	rfc = @rfc, 
	curp = @curp,
	fecha_alta =@fecha_alta
where 
	id_cliente = @id_cliente

end

go

------------------------- SP obtiene la información de la cuenta asociada con un cliente-------------------------
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_obtener_info_cuenta')
DROP PROCEDURE sp_obtener_info_cuenta

go

go
create procedure sp_obtener_info_cuenta
	(
		@id_cliente int
	)
as
begin

select 
	 a.id_cliente_cuenta, a.id_cliente, c.nombre, c.apellido_paterno, c.apellido_materno, a.id_cuenta, b.nombre_cuenta, a.saldo_actual, a.fecha_contratacion, a.fecha_ultimo_movimento
from 
	TBL_CMV_TIPO_CUENTA a 
inner join 
	CAT_CMV_TIPO_CUENTA b on b.id_cuenta=a.id_cuenta
inner join 
	TBL_CMV_CLIENTE c on c.id_cliente =a.id_cliente
where 
	a.id_cliente = @id_cliente
end

go

------------------------- SP elimina cliente por ID -------------------------
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_eliminar_cliente')
DROP PROCEDURE sp_eliminar_cliente

go

create procedure sp_eliminar_cliente
	(
		@id_cliente int
	)
as
begin

delete from 
	TBL_CMV_CLIENTE 
where 
	id_cliente = @id_cliente

end

go