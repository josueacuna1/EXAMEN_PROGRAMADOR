using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    //--- Creamos nuestro controlador ---\\
    public class ClienteController : ApiController
    {
        //--- Agregamos los Get, Put, y Delete ---\\
        public List<Cliente> Get()
        {
            return ClienteData.Listar();
        }
        public List<Cuenta> Get(int id_cliente)
        {
            return ClienteData.Obtener_cuenta(id_cliente);
        }
        public bool Put([FromBody]Cliente _Cliente)
        {
            return ClienteData.Actualizar_cliente(_Cliente);
        }
        public bool Delete(int id_cliente)
        {
            return ClienteData.Eliminar_Cliente(id_cliente);
        }

    }
}