using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
                                    Console.WriteLine(atalayaMeals.meal_plans);
                                    foreach (var hotel in atalayaHotels.hotels)
                                    {
                                        ListaRoomAtalaya listaRoomAtalaya = new ListaRoomAtalaya();
                                        listaRoomAtalaya.rooms_type = new List<RoomAtalaya>();
                                        foreach (RoomAtalaya room in hotel.Rooms)
                                        {
                                            foreach (MealPlanAtalaya meal in atalayaMeals.Meal_plans)
                                            {

                                                if (meal == room.Code)
                                                {
                                                    if (meal.Hotel == hotel.Code)
                                                    {
                                                        if (room.Meal_plan == null)
                                                        {
                                                            room.Meal_plan = meal.Code;
                                                            listaRoomResort.rooms.Add(room);
                                                            oldRoom = room;
                                                        }
                                                        else
                                                        {
                                                            if (meal.Code != room.Meal_plan)
                                                            {
                                                                RoomResort roomResort = new RoomResort(room.Code, room.Name, meal.Code);
                                                                listaRoomResort.rooms.Add(roomResort);
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {

                                                }
                                            }
                                        }
                                        hotel.Rooms = listaRoomResort.rooms;
                                    }
                                }
                            }
                        }
                    }
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
