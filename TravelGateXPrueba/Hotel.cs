using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGateXPrueba
{
    public class Hotel
    {
        private int code;
        private string name;
        private string city;
        private List<Room> rooms;

        public Hotel()
        {
        }

        public Hotel(int code, string name, string city, List<Room> rooms)
        {
            this.Code = code;
            this.Name = name;
            this.City = city;
            this.rooms = rooms;
        }

        public int Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }
    }
}
