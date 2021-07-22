using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Peliculas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Data
{
    public class Datos
    {
        public static HttpClient Client = new HttpClient();

        public async Task<List<DTO_Pelicula>> obtenerListaPeliculasAsync(string tipo, string nombre)
        {
            string content = "";
            string t = "";
            List<DTO_Pelicula> lista = new List<DTO_Pelicula>();

            if (tipo == "ultimas")
                t = "movie/now_playing?";
            else if (tipo == "mejorcalificadas")
                t = "movie/top_rated?";
            else if (tipo == "maspopulares")
                t = "movie/popular?";
            else if (tipo == "buscar")
                t = "search/movie?include_adult=true&query=" + nombre + "&";

            Uri uri = new Uri("https://api.themoviedb.org/3/" + t + "api_key=4f2ab6910e860172ca9af05b4189d51d&language=es-ES&page=1");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(content);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                lista = JsonConvert.DeserializeObject<List<DTO_Pelicula>>(json["results"].ToString(), settings);
            }           

            return lista;
        }

        public async Task<DTO_Pelicula> obtenerPeliculaAsync(int id)
        {
            string content = "";
            string t = "";
            DTO_Pelicula reg = new DTO_Pelicula();

            Uri uri = new Uri("https://api.themoviedb.org/3/movie/" + id.ToString() + "?api_key=4f2ab6910e860172ca9af05b4189d51d&language=es-ES&page=1");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                reg = JsonConvert.DeserializeObject<DTO_Pelicula>(content, settings);
            }

            return reg;
        }

    }
}
