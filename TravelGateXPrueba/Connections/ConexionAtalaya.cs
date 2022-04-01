using Newtonsoft.Json;
using System.Net.Http.Headers;
using TravelGateXPrueba;
using TravelGateXPrueba.Classes;
using static TravelGateXPrueba.Classes.MealPlanAtalaya;
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
                            using (HttpResponseMessage meals = client.GetAsync("http://www.mocky.io/v2/5e4a7e282f0000490097d252").Result)
                            {
                                if (meals.IsSuccessStatusCode)
                                {
                                    var mealsContent = meals.Content;
                                    json = mealsContent.ReadAsStringAsync().Result;
                                    ListaMealPlanAtalaya atalayaMeals = JsonConvert.DeserializeObject<ListaMealPlanAtalaya>(json);
                                    foreach (var hotel in atalayaHotels.hotels)
                                    {
                                        ListaRoomAtalaya listaRoomAtalaya = new ListaRoomAtalaya();
                                        listaRoomAtalaya.rooms_type = new List<RoomAtalaya>();
                                        foreach (RoomAtalaya room in atalayaRooms.rooms_type)
                                        {
                                            foreach (MealPlanAtalaya meal in atalayaMeals.meal_plans)
                                            {
                                                if (room.Hotels.Contains(hotel.Code))
                                                {
                                                    if (meal.Hotel.Ave.Count > 0)
                                                    {
                                                        foreach(Ave ave in meal.Hotel.Ave)
                                                        {
                                                            if(hotel.Code == "ave")
                                                            {
                                                                if (room.Code == ave.Room)
                                                                {
                                                                    RoomAtalaya roomAtalaya = new RoomAtalaya(null, room.Code, room.Name, meal.Code, ave.Price);
                                                                    listaRoomAtalaya.rooms_type.Add(roomAtalaya);
                                                                }
                                                            }
                                                            
                                                        }
                                                    } if (meal.Hotel.Acs.Count > 0)
                                                    {
                                                        foreach (Acs ac in meal.Hotel.Acs)
                                                        {
                                                            if (hotel.Code == "acs")
                                                            {
                                                                if (room.Code == ac.Room)
                                                                {
                                                                    RoomAtalaya roomAtalaya = new RoomAtalaya(null, room.Code, room.Name, meal.Code, ac.Price);
                                                                    listaRoomAtalaya.rooms_type.Add(roomAtalaya);
                                                                }
                                                            }   
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        hotel.Rooms = listaRoomAtalaya.rooms_type;
                                    }
                                }
                            }
                        }
                    }
                    //string jsonNew = JsonConvert.SerializeObject(atalayaHotels);
                    //Console.WriteLine(jsonNew);
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
