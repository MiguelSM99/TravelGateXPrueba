using Classes.TravelGateXPrueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGateXPrueba
{
    public class HotelAtalaya
    {
        private string code;
        private string name;
        private string city;
        private List<Room> rooms;

        public HotelAtalaya()
        {
        }

        public HotelAtalaya(string code, string name, string city, List<Room> rooms)
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

    public class ListaHotelesAtalaya
    {
        public List<HotelAtalaya> hotels;
        public List<HotelAtalaya> Hotels { get; set; }
    }
}
