using TravelGateXPrueba;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TravelgateXPrueba
{
    public class MainStart
    {
        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>();
            Room habitacion = new Room("Room1", 2, "Desayuno", 15.5);
            Room habitacion1 = new Room("Room1", 2, "Desayuno", 15.5);
            rooms.Add(habitacion);
            rooms.Add(habitacion1);
            Hotel hotelito = new Hotel(1, "Atalaya", "City", rooms);
            string jsonHotelito = JsonSerializer.Serialize<Hotel>(hotelito);
            Console.WriteLine(jsonHotelito);
        }
    }
}

