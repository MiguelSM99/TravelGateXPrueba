using Newtonsoft.Json;
using System.Net.Http.Headers;
using TravelGateXPrueba.Classes;
using static TravelGateXPrueba.Classes.MealPlanResort;
using static TravelGateXPrueba.Classes.RoomResort;

namespace Classes.TravelGateXPrueba
{
    public class ConexionResort
    {
        public ListaHotelesResort Conexion()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.mocky.io/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage hotels = client.GetAsync("http://www.mocky.io/v2/5e4e43272f00006c0016a52b").Result)
            {
                if (hotels.IsSuccessStatusCode)
                {
                    var hotelsContent = hotels.Content;
                    var json = hotelsContent.ReadAsStringAsync().Result;
                    ListaHotelesResort resortHotels = JsonConvert.DeserializeObject<ListaHotelesResort>(json);
                    using (HttpResponseMessage meals = client.GetAsync("http://www.mocky.io/v2/5e4a7dd02f0000290097d24b").Result)
                    {
                        if (meals.IsSuccessStatusCode)
                        {
                            RoomResort oldRoom = new RoomResort();
                            var roomsContent = meals.Content;
                            json = roomsContent.ReadAsStringAsync().Result;
                            ListaMealPlanResort resortMeals = JsonConvert.DeserializeObject<ListaMealPlanResort>(json);
                            foreach (var hotel in resortHotels.hotels)
                            {
                                ListaRoomResort listaRoomResort = new ListaRoomResort();
                                listaRoomResort.rooms = new List<RoomResort>();
                                foreach (RoomResort room in hotel.Rooms)
                                {
                                    foreach (MealPlanResort meal in resortMeals.regimenes)
                                    {
                                        if(meal.Room_type == room.Code)
                                        {
                                            if (meal.Hotel == hotel.Code)
                                            {
                                                if(room.Meal_plan == null)
                                                {
                                                    room.Meal_plan = meal.Code;
                                                    room.Price = meal.Price;
                                                    listaRoomResort.rooms.Add(room);
                                                    oldRoom = room;
                                                } else
                                                {
                                                    if(meal.Code != room.Meal_plan)
                                                    {
                                                        RoomResort roomResort = new RoomResort(room.Code, room.Name, meal.Code, meal.Price);
                                                        listaRoomResort.rooms.Add(roomResort);
                                                    }
                                                }
                                            }
                                        } else
                                        {
     
                                        }
                                    }
                                }
                                hotel.Rooms = listaRoomResort.rooms;
                            }
                        }
                    }
                    //string jsonNew = JsonConvert.SerializeObject(resortHotels);
                    //Console.WriteLine(jsonNew);
                    return resortHotels;
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
                ListaHotelesResort Resort = JsonConvert.DeserializeObject<ListaHotelesResort>(json);

                foreach (var hotel in Resort.hotels)
                {
                    Console.WriteLine(hotel.Name);
                }
            }
        }
    }*/
}
