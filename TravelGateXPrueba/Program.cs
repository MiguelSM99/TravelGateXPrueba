using TravelGateXPrueba;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TravelgateXPrueba
{
    public class MainStart
    {
        static void Main(string[] args)
        {
            MainStart mainStart = new MainStart();
            mainStart.PruebaConexion().Wait();
            List<Room> rooms = new List<Room>();
            Room habitacion = new Room("Room1", 2, "Desayuno", 15.5);
            Room habitacion1 = new Room("Room1", 2, "Desayuno", 15.5);
            rooms.Add(habitacion);
            rooms.Add(habitacion1);
            Hotel hotelito = new Hotel("1", "Atalaya", "City", rooms);
            string jsonHotelito = System.Text.Json.JsonSerializer.Serialize(hotelito);
            //Console.WriteLine(jsonHotelito);
        }

        public async Task PruebaConexion()
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

        }
    }
}

