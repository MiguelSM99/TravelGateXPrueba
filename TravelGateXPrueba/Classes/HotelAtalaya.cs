using TravelGateXPrueba.Classes;

namespace TravelGateXPrueba
{
    public class HotelAtalaya
    {
        private string code;
        private string name;
        private string city;
        private List<RoomAtalaya> rooms;

        public HotelAtalaya()
        {
        }

        public HotelAtalaya(string code, string name, string city, List<RoomAtalaya> rooms)
        {
            this.Code = code;
            this.Name = name;
            this.City = city;
            this.rooms = rooms;
        }

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public List<RoomAtalaya> Rooms { get => rooms; set => rooms = value; }
    }

    public class ListaHotelesAtalaya
    {
        public List<HotelAtalaya> hotels;
    }
}
