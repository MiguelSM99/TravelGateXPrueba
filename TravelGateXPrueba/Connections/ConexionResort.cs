using Newtonsoft.Json;
using System.Net.Http.Headers;
using TravelGateXPrueba.Classes;
using static TravelGateXPrueba.Classes.MealPlanResort;
using static TravelGateXPrueba.Classes.RoomResort;

namespace Classes.TravelGateXPrueba
{
    public class ConexionResort
    {
        HttpClient client = new HttpClient();
        string json;
        public ListaHotelesResort Conexion()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.mocky.io/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ListaHotelesResort resortListHotels = new ListaHotelesResort();
            GetHotels(ref resortListHotels);

            ListaMealPlanResort resortListMeals = new ListaMealPlanResort();
            GetMeals(ref resortListMeals);

            resortListHotels = iterateHotels(resortListHotels, resortListMeals);
            client.Dispose();
            return resortListHotels;
        }

        private ListaHotelesResort iterateHotels(ListaHotelesResort resortListHotels, ListaMealPlanResort resortListMeals)
        {
            ListaHotelesResort hotelList = new ListaHotelesResort();
            hotelList.hotels = new List<HotelResort>();
            foreach (var hotel in resortListHotels.hotels)
            {
                ListaRoomResort listaRoomResort = new ListaRoomResort();
                listaRoomResort.rooms = new List<RoomResort>();
                foreach (RoomResort room in hotel.Rooms)
                {
                    foreach (MealPlanResort meal in resortListMeals.regimenes)
                    {
                        CheckMeal(hotel, room, meal, ref listaRoomResort);
                    }
                }
                hotel.Rooms = listaRoomResort.rooms;
                hotelList.hotels.Add(hotel);
            }
            return hotelList;
        }

        private void CheckMeal(HotelResort hotel, RoomResort room, MealPlanResort meal, ref ListaRoomResort listaRoomResort)
        {
            if (meal.Room_type == room.Code)
            {
                if (meal.Hotel == hotel.Code)
                {
                    if (room.Meal_plan == null)
                    {
                        room.Meal_plan = meal.Code;
                        room.Price = meal.Price;
                        listaRoomResort.rooms.Add(room);
                    }
                    else
                    {
                        if (meal.Code != room.Meal_plan)
                        {
                            RoomResort roomResort = new RoomResort(room.Code, room.Name, meal.Code, meal.Price);
                            listaRoomResort.rooms.Add(roomResort);
                        }
                    }
                }
            }
        }

        private void GetMeals(ref ListaMealPlanResort resortMeals)
        {
            using (HttpResponseMessage meals = client.GetAsync("http://www.mocky.io/v2/5e4a7dd02f0000290097d24b").Result)
            {
                if (meals.IsSuccessStatusCode)
                {
                    RoomResort oldRoom = new RoomResort();
                    var roomsContent = meals.Content;
                    json = roomsContent.ReadAsStringAsync().Result;
                    resortMeals = JsonConvert.DeserializeObject<ListaMealPlanResort>(json);
                }
            }
        }

        private void GetHotels(ref ListaHotelesResort resortHotels)
        {            
            using (HttpResponseMessage hotels = client.GetAsync("http://www.mocky.io/v2/5e4e43272f00006c0016a52b").Result)
            {
                if (hotels.IsSuccessStatusCode)
                {
                    var hotelsContent = hotels.Content;
                    var json = hotelsContent.ReadAsStringAsync().Result;
                    resortHotels = JsonConvert.DeserializeObject<ListaHotelesResort>(json);
                }
            }
        }
    }
}
