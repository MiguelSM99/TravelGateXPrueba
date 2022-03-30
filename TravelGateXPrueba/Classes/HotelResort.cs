﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.TravelGateXPrueba
{
    public class HotelResort
    {
        private string code;
        private string name;
        private string location;
        private List<Room> rooms;

        public HotelResort()
        {
        }

        public HotelResort(string code, string name, string location, List<Room> rooms)
        {
            this.Code = code;
            this.Name = name;
            this.Location = location;
            this.rooms = rooms;
        }

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Location { get => location; set => location = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }
    }

    public class ListaHotelesResort
    {
        public List<HotelResort> hotels;
        public List<HotelResort> Hotels { get; set; }
    }
}