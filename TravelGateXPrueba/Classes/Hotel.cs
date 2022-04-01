using Classes.TravelGateXPrueba;

namespace TravelGateXPrueba.Classes
{
    public class Hotel
    {
        private string code;
        private string name;
        private string city;
        private List<Room> rooms;

        public Hotel()
        {
        }

        public Hotel(string code, string name, string city, List<Room> rooms)
        {
            this.Code = code;
            this.Name = name;
            this.City = city;
            this.rooms = rooms;
        }

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }
    }

    public class ListaHoteles
    {
        public List<Hotel> hotels;
    }
}
