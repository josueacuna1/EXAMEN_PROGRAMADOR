insert into TBL_CMV_CLIENTE(nombre, apellido_paterno, apellido_materno, rfc, curp,fecha_alta) values ('Josué', 'Alacaraz', 'Acuña', 'qwertylaasdfg','EUAJ030830HMNCLSA5','2022-03-10')
insert into TBL_CMV_CLIENTE(nombre, apellido_paterno, apellido_materno, rfc, curp,fecha_alta) values ('Alejandro', 'Cortes', 'Alcaraz', 'vwertyuiasdfg','IUAJ020830HMNCLSA5','2022-05-07')
insert into TBL_CMV_CLIENTE(nombre, apellido_paterno, apellido_materno, rfc, curp,fecha_alta) values ('Juan', 'Perez', 'Lopez', 'xwertyuiasdfg','OUAJ020830HMNCLSA5','2022-01-18')
insert into TBL_CMV_CLIENTE(nombre, apellido_paterno, apellido_materno, rfc, curp,fecha_alta) values ('Pedro', 'Rios', 'Arias', 'ywertyuiasdfg','UUAJ020830HMNCLSA5','2022-02-18')

insert into CAT_CMV_TIPO_CUENTA(nombre_cuenta) values('Ahorro')
insert into CAT_CMV_TIPO_CUENTA(nombre_cuenta) values('Débito')
insert into CAT_CMV_TIPO_CUENTA(nombre_cuenta) values('Crédito')

insert into TBL_CMV_TIPO_CUENTA(id_cliente, id_cuenta, saldo_actual, fecha_contratacion, fecha_ultimo_movimento) values (1014, 1, 2308.10,'2020-01-16', '2022-04-17')
insert into TBL_CMV_TIPO_CUENTA(id_cliente, id_cuenta, saldo_actual, fecha_contratacion, fecha_ultimo_movimento) values (1014, 2, 15280,'2022-02-20', '2022-05-17')
insert into TBL_CMV_TIPO_CUENTA(id_cliente, id_cuenta, saldo_actual, fecha_contratacion, fecha_ultimo_movimento) values (1015, 2, 5470,'2022-01-17', '2022-04-08')
insert into TBL_CMV_TIPO_CUENTA(id_cliente, id_cuenta, saldo_actual, fecha_contratacion, fecha_ultimo_movimento) values (1016, 3, 13000,'2022-03-16', '2022-04-16')
