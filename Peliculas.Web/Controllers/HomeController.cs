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
    public class HomeController : Controller
    {
        PeliculasBusiness peliculasBusiness = new PeliculasBusiness();
        public async Task<ActionResult> Index()
        {
            List<DTO_Pelicula> lista = await  peliculasBusiness.ObtenerUltimasAsync();

            var model = new PeliculasModel
            {
                Titulo = "Películas en cartelera",
                Peliculas = lista.OrderByDescending(s => s.release_date).ToList()
            };

            return View(model);
        }

        public async Task<ActionResult> MejorCalificadas()
        {
            List<DTO_Pelicula> lista = await peliculasBusiness.ObtenerMejorCalificadasAsync();

            var model = new PeliculasModel
            {
                Titulo = "Mejor calificadas",
                Peliculas = lista.OrderByDescending(s => s.vote_average).ToList()
            };

            return View("~/Views/Home/Index.cshtml", model);
        }

        public async Task<ActionResult> Populares()
        {
            List<DTO_Pelicula> lista = await peliculasBusiness.ObtenerMasPopularesAsync();

            var model = new PeliculasModel
            {
                Titulo = "Más populares",
                Peliculas = lista.OrderByDescending(s => s.popularity).ToList()
            };

            return View("~/Views/Home/Index.cshtml", model);
        }

        public async Task<ActionResult> BuscarPelicula(int id)
        {
            DTO_Pelicula reg = await peliculasBusiness.ObtenerDetalleXIdAsync(id);

            var model = new PeliculasModel
            {
                Pelicula = reg
            };

            return View("~/Views/Home/Index.cshtml", model);
        }

        public async Task<ActionResult> Buscar(string nombre)
        {
            List<DTO_Pelicula> lista = await peliculasBusiness.ObtenerPeliculasXNombreAsync(nombre);

            var model = new PeliculasModel
            {
                Titulo = "Buscar: " + nombre,
                Peliculas = lista
            };

            return View("~/Views/Home/Index.cshtml", model);
        }
    }
}