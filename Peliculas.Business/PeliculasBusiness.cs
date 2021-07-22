using Newtonsoft.Json;
using Peliculas.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Peliculas.Business
{
    public class PeliculasBusiness
    {
        public static HttpClient Client = new HttpClient();
        private string webAPI = "https://localhost:44387/api/";

        public async Task<List<DTO_Pelicula>> ObtenerUltimasAsync()
        {
            string content = "";

            Uri uri = new Uri(webAPI + "peliculas?t=ultimas");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<List<DTO_Pelicula>>(content);
        }

        public async Task<List<DTO_Pelicula>> ObtenerMejorCalificadasAsync()
        {
            string content = "";

            Uri uri = new Uri(webAPI + "peliculas?t=mejorcalificadas");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<List<DTO_Pelicula>>(content);
        }

        public async Task<List<DTO_Pelicula>> ObtenerMasPopularesAsync()
        {
            string content = "";

            Uri uri = new Uri(webAPI + "peliculas?t=maspopulares");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<List<DTO_Pelicula>>(content);
        }

        public async Task<List<DTO_Pelicula>> ObtenerPeliculasXNombreAsync(string nombre)
        {
            string content = "";

            Uri uri = new Uri(webAPI + "peliculas?t=buscar&nombre=" + nombre);

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<List<DTO_Pelicula>>(content);
        }

        public async Task<DTO_Pelicula> ObtenerDetalleXIdAsync(int id)
        {
            string content = "";

            Uri uri = new Uri(webAPI + "peliculas/" + id);

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<DTO_Pelicula>(content); ;
        }

    }
}
