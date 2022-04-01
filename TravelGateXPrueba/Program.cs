using TravelGateXPrueba;
using Newtonsoft.Json;
using Classes.TravelGateXPrueba;
using TravelGateXPrueba.Classes;
using TravelGateXPrueba.Utils;
using static Classes.TravelGateXPrueba.Room;

namespace TravelgateXPrueba
{
    public class MainStart
    {
        static void Main(string[] args)
        {
            //Punto1
            Console.WriteLine("\nPUNTO 1. RECOGIDA CONSENSUADA DE LA INFORMACIO DE LOS HOTELES\n");

            ListaHoteles hotelList = new ListaHoteles();
            hotelList.hotels = new List<Hotel>();

            ConexionAtalaya ca = new ConexionAtalaya();
            ListaHotelesAtalaya la = ca.Conexion();
            UtilsAtalaya uA = new UtilsAtalaya();

            ConexionResort lr = new ConexionResort();
            ListaHotelesResort lhr = lr.Conexion();
            UtilsResort uR = new UtilsResort();

            ListaHoteles transAt = uA.transAtalaya(la);
            ListaHoteles transRe = uR.transResort(lhr);

            hotelList.hotels.AddRange(transRe.hotels);
            hotelList.hotels.AddRange(transAt.hotels);
            string jsonNew = JsonConvert.SerializeObject(hotelList);
            Console.WriteLine(jsonNew);

            //Punto2
            IDictionary<string, string> mealPlanCity = new Dictionary<string, string>();
            mealPlanCity.Add("Malaga", "");
            mealPlanCity.Add("Cancun", "ad");
            double max_price = 700;
            bool cheap = true;
            string cheaper_city = "Malaga";
            string itinerario = Punto2(hotelList, mealPlanCity, max_price, cheap, cheaper_city);
            Console.WriteLine("\nPUNTO 2. ITINERARIO PARA CLIENTE\n");
            Console.WriteLine(itinerario);

        }

        private static string Punto2(ListaHoteles listaHoteles, IDictionary<string, string> mealPlanCity, double max_price, bool cheap, string cheaper_city)
        {
            List<ListaHoteles> itineraryList = new List<ListaHoteles>();
            Room cheapestRoom = null;
            if (cheap) { cheapestRoom = CheckCheapest(listaHoteles, cheaper_city); }
            cheapestRoom.Price = (cheapestRoom.Price * 2) * 3;
            foreach (Hotel hotel in listaHoteles.hotels)
            {
                if (hotel.City == "Cancun")
                {
                    foreach (Room room in hotel.Rooms)
                    {
                        foreach (Hotel hotel2 in listaHoteles.hotels)
                        {
                            if (hotel2.City == "Malaga")
                            {
                                if (room.Meals_plan == mealPlanCity["Cancun"])
                                {
                                    foreach (Room room2 in hotel2.Rooms)
                                    {
                                        double cancunRoom = (room.Price * 2) * 5;
                                        double malagaRoom = (room2.Price * 2) * 3;
                                        double totalPrice = cancunRoom + malagaRoom;
                                        if (totalPrice <= 700)
                                        {
                                            if (cheapestRoom != null)
                                            {
                                                ListaRoom roomsCancun = new ListaRoom();
                                                roomsCancun.rooms = new List<Room>();
                                                ListaRoom roomsMalaga = new ListaRoom();
                                                roomsMalaga.rooms = new List<Room>();
                                                room.Price = cancunRoom;

                                                roomsCancun.rooms.Add(room);
                                                roomsMalaga.rooms.Add(cheapestRoom);
                                                Hotel hotelCancun = new Hotel(hotel.Code, hotel.Name, hotel.City, roomsCancun.rooms);
                                                Hotel hotelMalaga = new Hotel(hotel2.Code, hotel2.Name, hotel2.City, roomsMalaga.rooms);
                                                ListaHoteles provisionalList = new ListaHoteles();
                                                provisionalList.hotels = new List<Hotel>();
                                                provisionalList.hotels.Add(hotelCancun);
                                                provisionalList.hotels.Add(hotelMalaga);
                                                itineraryList.Add(provisionalList);
                                            }
                                            else
                                            {
                                                ListaRoom roomsCancun = new ListaRoom();
                                                roomsCancun.rooms = new List<Room>();
                                                ListaRoom roomsMalaga = new ListaRoom();
                                                roomsMalaga.rooms = new List<Room>();
                                                roomsCancun.rooms.Add(room);
                                                roomsMalaga.rooms.Add(room2);
                                                Hotel hotelCancun = new Hotel(hotel.Code, hotel.Name, hotel.City, roomsCancun.rooms);
                                                Hotel hotelMalaga = new Hotel(hotel2.Code, hotel2.Name, hotel2.City, roomsMalaga.rooms);
                                                ListaHoteles provisionalList = new ListaHoteles();
                                                provisionalList.hotels = new List<Hotel>();
                                                provisionalList.hotels.Add(hotelCancun);
                                                provisionalList.hotels.Add(hotelMalaga);
                                                itineraryList.Add(provisionalList);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            string jsonNew = JsonConvert.SerializeObject(itineraryList);
            return jsonNew;
        }

        private static Room CheckCheapest(ListaHoteles listaHoteles, string cheaper_city)
        {
            Room roomTmp = new Room();
            foreach (Hotel hotel in listaHoteles.hotels)
            {
                if (hotel.City == cheaper_city)
                {
                    foreach (Room room in hotel.Rooms)
                    {
                        if (roomTmp.Room_type == null)
                        {
                            roomTmp = room;
                        }
                        else
                        {
                            if (roomTmp.Price > room.Price)
                            {
                                roomTmp = room;
                            }
                        }
                    }
                }
            }
            return roomTmp;
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

