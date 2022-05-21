using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebApi.Models
{
    //--- Creamos un modelo llamado cliente el cual obtendrá los datos de un cliente --\\
    public class Cliente
    {
        //--- Agregamos los campos que utilizaremos ---\\
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string rfc { get; set; }
        public string curp { get; set; }
        public DateTime fecha_alta { get; set; }
    }
}