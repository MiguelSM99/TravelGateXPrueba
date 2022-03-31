using TravelGateXPrueba;
using Newtonsoft.Json;
using Classes.TravelGateXPrueba;
using TravelGateXPrueba.Classes;
using TravelGateXPrueba.Utils;

namespace TravelgateXPrueba
{
    public class MainStart
    {
        static void Main(string[] args)
        {
            ListaHoteles listaHotel = new ListaHoteles();
            listaHotel.hotels = new List<Hotels>();

            ConexionAtalaya ca = new ConexionAtalaya();
            ListaHotelesAtalaya la = ca.Conexion();
            UtilsAtalaya uA = new UtilsAtalaya();

            ConexionResort lr = new ConexionResort();
            ListaHotelesResort lhr = lr.Conexion();
            UtilsResort uR = new UtilsResort();

            ListaHoteles transAt = uA.transAtalaya(la);
            ListaHoteles transRe = uR.transResort(lhr);

            listaHotel.hotels.AddRange(transRe.hotels);
            listaHotel.hotels.AddRange(transAt.hotels);
            string jsonNew = JsonConvert.SerializeObject(listaHotel);

            Console.WriteLine(jsonNew);
        }

        /*public async Task PruebaConexion()
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
                    ListaHoteles atalaya = JsonConvert.DeserializeObject<ListaHoteles>(json);

                    foreach (var hotel in atalaya.hotels)
                    {
                        Console.WriteLine(hotel.Name);
                    }
                }
            }

        }*/
    }
}

