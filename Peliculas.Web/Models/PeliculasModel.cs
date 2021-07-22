using Newtonsoft.Json.Linq;
using Peliculas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Peliculas.Web.Models
{
    public class PeliculasModel
    {
        public List<DTO_Pelicula> Peliculas { get; set; }
        public string Titulo { get; set; }
        public DTO_Pelicula Pelicula { get; set; }
    }
}