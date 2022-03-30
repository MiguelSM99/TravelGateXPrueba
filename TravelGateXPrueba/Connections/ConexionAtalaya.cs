using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TravelGateXPrueba;

namespace Classes.TravelGateXPrueba
{
    public class ConexionAtalaya
    {
        public ListaHotelesAtalaya Conexion()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.mocky.io/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = client.GetAsync("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253").Result)
            {
                if (response.IsSuccessStatusCode)
                {
                    var response2 = response.Content;
                    string json = response2.ReadAsStringAsync().Result;
                    ListaHotelesAtalaya atalayaHotels = JsonConvert.DeserializeObject<ListaHotelesAtalaya>(json);
                    return atalayaHotels;
                }
                else
                {
                    return null;
                }
            }
        }
    }
        /*
        public async Task ConexionResort()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.mocky.io/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = await client.GetAsync("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    ListaHotelesAtalaya atalaya = JsonConvert.DeserializeObject<ListaHotelesAtalaya>(json);

                    foreach (var hotel in atalaya.hotels)
                    {
                        Console.WriteLine(hotel.Name);
                    }
                }
            }
        }*/
}
