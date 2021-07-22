using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Peliculas.Business;
using Peliculas.DTOs;
using Peliculas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Peliculas.Web.Controllers
{
    public class PeliculaController : Controller
    {
        PeliculasBusiness peliculasBusiness = new PeliculasBusiness();        

        public async Task<ActionResult> Index(int id)
        {
            DTO_Pelicula reg = await peliculasBusiness.ObtenerDetalleXIdAsync(id);

            var model = new PeliculasModel
            {
                Titulo = "Más populares",
                Pelicula = reg
            };

            return View(model);
        }
    }
}