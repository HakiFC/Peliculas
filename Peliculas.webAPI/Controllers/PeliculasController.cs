using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Peliculas.Data;
using Peliculas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace Peliculas.webAPI.Controllers
{
    public class PeliculasController : ApiController
    {
        private Datos data = new Datos();

        // GET api/values
        public async Task<List<DTO_Pelicula>> Get(string t, string nombre = "")
        {
            List<DTO_Pelicula> rta = await data.obtenerListaPeliculasAsync(t, nombre);

            return rta;
        }

        // GET api/values/5
        public async Task<DTO_Pelicula> Get(int id)
        {
            DTO_Pelicula rta = await data.obtenerPeliculaAsync(id);

            return rta;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
