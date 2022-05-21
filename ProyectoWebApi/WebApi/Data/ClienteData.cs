using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using WebApi.Models;

namespace WebApi.Data
{
    //--- Creamos nuestra clase que contendra todos los métodos para realizar acciones con respecto al Cliente --\\
    internal class ClienteData
    {
        //---- Creamos un método llamado listar que contendrá una lista con base en el modelo cliente ----\\
        public static List<Cliente> Listar()
        {
            List<Cliente> oListaCliente = new List<Cliente>();
            //----- Agregamos la conexión con la bd -----\\
            using (SqlConnection _Conexion = new SqlConnection(Conexion.rutaConexion))
            {
                //--- llamamos al SP ---\\
                SqlCommand cmd = new SqlCommand("sp_obtener_cliente_alta", _Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    //----- Ejecutamos el SP -----\\
                    _Conexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        //---- Leemos el resultado y lo vamos almacenando en una lista ----\\
                        while (dr.Read())
                        {
                            oListaCliente.Add(new Cliente()
                            {
                                id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                nombre = dr["nombre"].ToString(),
                                apellido_paterno = dr["apellido_paterno"].ToString(),
                                apellido_materno = dr["apellido_materno"].ToString(),
                                rfc = dr["rfc"].ToString(),
                                curp = dr["curp"].ToString(),
                                fecha_alta = Convert.ToDateTime(dr["fecha_alta"].ToString())
                            });
                        }

                    }
                    //---- Retornamos la lista ----\\
                    return oListaCliente;
                }
                catch (Exception ex)
                {
                    return oListaCliente;
                }
            }
        }
        //---- Creamos un método llamado Actualizar_cliente que actualizara los registros ----\\
        public static bool Actualizar_cliente(Cliente _Cliente)
        {
            //----- Agregamos la conexión con la bd -----\\
            using (SqlConnection _Conexion = new SqlConnection(Conexion.rutaConexion))
            {
                //--- llamamos al SP ---\\
                SqlCommand cmd = new SqlCommand("sp_modificar_cliente", _Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //--- Pasamos los parámetros con sus respectivos nombres tal cual están en el SP ---\\
                cmd.Parameters.AddWithValue("@id_cliente", _Cliente.id_cliente);
                cmd.Parameters.AddWithValue("@nombre", _Cliente.nombre);
                cmd.Parameters.AddWithValue("@apellido_paterno", _Cliente.apellido_paterno);
                cmd.Parameters.AddWithValue("@apellido_materno", _Cliente.apellido_materno);
                cmd.Parameters.AddWithValue("@rfc", _Cliente.rfc);
                cmd.Parameters.AddWithValue("@curp", _Cliente.curp);
                cmd.Parameters.AddWithValue("@fecha_alta", _Cliente.fecha_alta);

                try
                {
                    //----- Ejecutamos el SP -----\\
                    _Conexion.Open();
                    cmd.ExecuteNonQuery();
                    //--- Retornamos el resultado --\\
                    return true;
                }
                catch (Exception ex)
                {
                    //--- Retornamos el resultado --\\
                    return false;
                }
            }
        }
        //---- Creamos un método llamado Obtener_cuenta que obtendra la información de las cuentas asociadas a los clientes  ----\\
        public static List<Cuenta> Obtener_cuenta(int id_cliente)
        {
            //--- Creamos la lista para almacenar los datos --\\
            List<Cuenta> oCuenta = new List<Cuenta>();
            //----- Agregamos la conexión con la bd -----\\
            using (SqlConnection _Conexion = new SqlConnection(Conexion.rutaConexion))
            {
                //--- llamamos al SP ---\\
                SqlCommand cmd = new SqlCommand("sp_obtener_info_cuenta", _Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //--- Pasamos el párametro del id del cliente ---\\
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                try
                {
                    // -----Ejecutamos el SP -----\\
                    _Conexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        //---- Leemos el resultado y lo vamos almacenando en la lista ----\\
                        while (dr.Read())
                        {
                            oCuenta.Add(new Cuenta()
                            {
                                id_cliente_cuenta = Convert.ToInt32(dr["id_cliente_cuenta"]),
                                id_cliente = Convert.ToInt32(dr["id_cliente"]),
                                nombre= dr["nombre"].ToString(),
                                apellido_paterno = dr["apellido_paterno"].ToString(),
                                apellido_materno = dr["apellido_materno"].ToString(),
                                id_cuenta = Convert.ToInt32(dr["id_cuenta"]),
                                nombre_cuenta = dr["nombre_cuenta"].ToString(),
                                saldo_actual = Convert.ToDecimal(dr["saldo_actual"]),
                                fecha_contratacion = Convert.ToDateTime(dr["fecha_contratacion"].ToString()),
                                fecha_ultimo_movimento = Convert.ToDateTime(dr["fecha_ultimo_movimento"].ToString())
                            });
                        }

                    }
                    //---- Retornamos la lista ----\\
                    return oCuenta;
                }
                catch (Exception ex)
                {
                    return oCuenta;
                }
            }
        }
        //---- Creamos un método llamado Eliminar_Cliente que eliminara a los clientes por medio del id del cliente ----\\
        public static bool Eliminar_Cliente(int id_cliente)
        {
            //----- Agregamos la conexión con la bd -----\\
            using (SqlConnection _Conexion = new SqlConnection(Conexion.rutaConexion))
            {
                //--- llamamos al SP ---\\
                SqlCommand cmd = new SqlCommand("sp_eliminar_cliente", _Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                //--- Pasamos el párametro del id del cliente ---\\
                cmd.Parameters.AddWithValue("@id_cliente", id_cliente);

                try
                {
                    //---- Ejecutamos ----\\
                    _Conexion.Open();
                    cmd.ExecuteNonQuery();
                    //---- retornamos el resultado de la ejecución ----\\
                    return true;
                }
                catch (Exception ex)
                {
                //---- retornamos el resultado de la ejecución ----\\
                    return false;
                }
            }
        }
        
    }
}