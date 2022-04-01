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
        HttpClient client = new HttpClient();
        string json;
        public ListaHotelesAtalaya Conexion()
        {
            client.BaseAddress = new Uri("http://www.mocky.io/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ListaHotelesAtalaya atalayaHotels = new ListaHotelesAtalaya();
            GetHotels(ref atalayaHotels);

            ListaRoomAtalaya atalayaRooms = new ListaRoomAtalaya(); 
            GetRooms(ref atalayaRooms);

            ListaMealPlanAtalaya atalayaMeals = new ListaMealPlanAtalaya();
            GetMeals(ref atalayaMeals);

            atalayaHotels = iterateHotels(atalayaHotels, atalayaRooms, atalayaMeals);
            client.Dispose();
            return atalayaHotels;
        }

        private ListaHotelesAtalaya iterateHotels(ListaHotelesAtalaya atalayaHotels, ListaRoomAtalaya atalayaRooms, ListaMealPlanAtalaya atalayaMeals)
        {
            ListaHotelesAtalaya hotelList = new ListaHotelesAtalaya();
            hotelList.hotels = new List<HotelAtalaya>();
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
                            listaRoomAtalaya.rooms_type.AddRange(checkHotel(room, hotel, meal));
                        }
                    }
                }
                hotel.Rooms = listaRoomAtalaya.rooms_type;
                hotelList.hotels.Add(hotel);
            }
            return hotelList;
        }

        private List<RoomAtalaya> checkHotel(RoomAtalaya room, HotelAtalaya hotel, MealPlanAtalaya meal)
        {
            List<RoomAtalaya> roomAtalaya = new List<RoomAtalaya>();
            if (meal.Hotel.Ave.Count > 0)
            {
                foreach (Ave ave in meal.Hotel.Ave)
                {
                    if (hotel.Code == "ave")
                    {
                        if (room.Code == ave.Room)
                        {
                            roomAtalaya.Add(new RoomAtalaya(null, room.Code, room.Name, meal.Code, ave.Price));
                        }
                    }
                }
            }
            if (meal.Hotel.Acs.Count > 0)
            {
                foreach (Acs ac in meal.Hotel.Acs)
                {
                    if (hotel.Code == "acs")
                    {
                        if (room.Code == ac.Room)
                        {
                            roomAtalaya.Add(new RoomAtalaya(null, room.Code, room.Name, meal.Code, ac.Price));
                        }
                    }
                }
            }
            return roomAtalaya;
        }

        private void GetHotels(ref ListaHotelesAtalaya atalayaHotels)
        {
            using (HttpResponseMessage hotels = client.GetAsync("http://www.mocky.io/v2/5e4a7e4f2f00005d0097d253").Result)
            {
                if (hotels.IsSuccessStatusCode)
                {
                    var hotelsContent = hotels.Content;
                    var json = hotelsContent.ReadAsStringAsync().Result;
                    atalayaHotels = JsonConvert.DeserializeObject<ListaHotelesAtalaya>(json);
                }
            }
        }

        private void GetMeals(ref ListaMealPlanAtalaya atalayaMeals)
        {
            using (HttpResponseMessage meals = client.GetAsync("http://www.mocky.io/v2/5e4a7e282f0000490097d252").Result)
            {
                if (meals.IsSuccessStatusCode)
                {
                    var mealsContent = meals.Content;
                    json = mealsContent.ReadAsStringAsync().Result;
                    atalayaMeals = JsonConvert.DeserializeObject<ListaMealPlanAtalaya>(json);
                }
            }
        }

        private void GetRooms(ref ListaRoomAtalaya atalayaRooms)
        {
            using (HttpResponseMessage rooms = client.GetAsync("https://run.mocky.io/v3/132af02e-8beb-438f-ac6e-a9902bc67036").Result)
            {
                if (rooms.IsSuccessStatusCode)
                {
                    var roomsContent = rooms.Content;
                    json = roomsContent.ReadAsStringAsync().Result;
                    atalayaRooms = JsonConvert.DeserializeObject<ListaRoomAtalaya>(json);
                }
            }
        }
    }
}
