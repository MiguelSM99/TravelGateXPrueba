using Classes.TravelGateXPrueba;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TravelGateXPrueba.Connections
{
    public class ConexionResort
    {
        public ListaHotelesResort Conexion()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.mocky.io/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = client.GetAsync("http://www.mocky.io/v2/5e4e43272f00006c0016a52b").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    var response2 = response.Content;
                    string json = response2.ReadAsStringAsync().Result;
                    ListaHotelesResort resortHotels = JsonConvert.DeserializeObject<ListaHotelesResort>(json);
                    return resortHotels;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
