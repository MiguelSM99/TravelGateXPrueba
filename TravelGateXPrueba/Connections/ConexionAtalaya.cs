using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TravelGateXPrueba;
using TravelGateXPrueba.Classes;
using static TravelGateXPrueba.Classes.RoomAtalaya;

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
            using (HttpResponseMessage hotels = client.GetAsync("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253").Result)
            {
                if (hotels.IsSuccessStatusCode)
                {
                    var hotelsContent = hotels.Content;
                    var json = hotelsContent.ReadAsStringAsync().Result;
                    ListaHotelesAtalaya atalayaHotels = JsonConvert.DeserializeObject<ListaHotelesAtalaya>(json);
                    using (HttpResponseMessage rooms = client.GetAsync("https://run.mocky.io/v3/132af02e-8beb-438f-ac6e-a9902bc67036").Result)
                    {
                        if (rooms.IsSuccessStatusCode)
                        {
                            var roomsContent = rooms.Content;
                            json = roomsContent.ReadAsStringAsync().Result;
                            ListaRoomAtalaya atalayaRooms = JsonConvert.DeserializeObject<ListaRoomAtalaya>(json);
                            foreach (var hotel in atalayaHotels.hotels)
                            {
                                hotel.Rooms = new List<RoomAtalaya>();
                                foreach (RoomAtalaya room in atalayaRooms.rooms_type)
                                {
                                    foreach (var codeHotel in room.Hotels)
                                    {
                                        if (codeHotel == hotel.Code)
                                        {
                                            hotel.Rooms.Add(room);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return atalayaHotels;
                } else
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
