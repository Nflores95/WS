using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication2.Models;
using System;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;

namespace WebApplication2.Controllers
{
    
    public class CuotasController : ApiController
    {
        conexion _conexion = new conexion();
        //public CuotasController() { }
        //public CuotasController(conexion conexion)
        //{
        //    this._conexion = conexion ?? throw new ArgumentNullException(nameof(conexion));
        //}
        // GET: api/Cuotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get(int _IdCanal, int _TipoAvance)
        {
            var lista_coutas = await _conexion.GetCuotas(_IdCanal, _TipoAvance);

            if(lista_coutas == null)
            {
               
            }
            return lista_coutas;
        }

    }
}
