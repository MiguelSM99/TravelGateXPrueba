using TravelGateXPrueba;

using System.Net.Http.Headers;
using Newtonsoft.Json;
using Classes.TravelGateXPrueba;
using TravelGateXPrueba.Connections;
using TravelGateXPrueba.Classes;
using TravelGateXPrueba.Utils;
using System.Linq;

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
            string joselito = JsonConvert.SerializeObject(listaHotel);

            Console.WriteLine(joselito);

            /*MainStart mainStart = new MainStart();
            List<Room> rooms = new List<Room>();
            Room habitacion = new Room("Room1", 2, "Desayuno", 15.5);
            Room habitacion1 = new Room("Room1", 2, "Desayuno", 15.5);
            rooms.Add(habitacion);
            rooms.Add(habitacion1);
            Hotel hotelito = new Hotel("1", "Atalaya", "City", rooms);
            string jsonHotelito = System.Text.Json.JsonSerializer.Serialize(hotelito);
            Console.WriteLine(jsonHotelito);*/

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

