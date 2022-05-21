using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApi.Models
{
    //--- Creamos un modelo llamado cuenta el cual obtendrá los datos de las cuentas asociadas a un cliente --\\
    public class Cuenta
    {
        //--- Agregamos los campos que utilizaremos ---\\
        public int id_cliente_cuenta { get; set; }
        public int id_cliente { get; set; }
        public String nombre { get; set; }
        public String apellido_paterno { get; set; }
        public String apellido_materno { get; set; }
        public String nombre_cuenta { get; set; }
        public int id_cuenta { get; set; }
        public decimal saldo_actual { get; set; }
        public DateTime fecha_contratacion { get; set; }
        public DateTime fecha_ultimo_movimento { get; set; }

    }
}