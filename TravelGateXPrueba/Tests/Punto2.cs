using Classes.TravelGateXPrueba;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGateXPrueba.Classes;
using static Classes.TravelGateXPrueba.Room;

namespace TravelGateXPrueba.Tests
{
    public class Punto2
    {
        List<ListaHoteles> itineraryList = new List<ListaHoteles>();
        public string Test(ListaHoteles listaHoteles, IDictionary<string, string> mealPlanCity, double max_price, bool cheap, string cheaper_city)
        {
            Console.WriteLine("\nPUNTO 2. ITINERARIO PARA CLIENTE\n");

            Room cheapestRoom = new Room();

            if (cheap) cheapestRoom = CheckCheapest(listaHoteles, cheaper_city);

            foreach (Hotel hotel in listaHoteles.hotels)
            {
                if (hotel.City == "Cancun")
                {
                    foreach (Room room in hotel.Rooms)
                    {
                        foreach (Hotel hotel2 in listaHoteles.hotels)
                        {
                            checkMalagaHotel(hotel, room, hotel2, cheapestRoom, mealPlanCity);
                        }
                    }
                }
            }
            string itinerario = JsonConvert.SerializeObject(itineraryList);
            return itinerario;
        }

        private void checkMalagaHotel(Hotel hotel, Room room, Hotel hotel2, Room cheapestRoom, IDictionary<string, string> mealPlanCity)
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
                        checkTotalPrice(hotel, room, hotel2, cheapestRoom, totalPrice, cancunRoom, room2);
                    }
                }
            }
        }

        private void checkTotalPrice(Hotel hotel, Room room, Hotel hotel2, Room cheapestRoom, 
                                    double totalPrice, double cancunRoom, Room room2)
        {
            if (totalPrice <= 700)
            {
                if (cheapestRoom != null)
                {
                    ListaRoom roomsCancun = new ListaRoom();
                    roomsCancun.rooms = new List<Room>();
                    ListaRoom roomsMalaga = new ListaRoom();
                    roomsMalaga.rooms = new List<Room>();
                    room.Price = cancunRoom;
                    room.Nights = "5";
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
        private Room CheckCheapest(ListaHoteles listaHoteles, string cheaper_city)
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
            roomTmp.Nights = "3";
            roomTmp.Price = (roomTmp.Price * 2) * 3;
            return roomTmp;
        }
    }
}
