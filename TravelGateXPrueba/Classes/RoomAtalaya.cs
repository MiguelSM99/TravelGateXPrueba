﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGateXPrueba.Classes
{
    public class RoomAtalaya
    {
        private List<string> hotels;
        private string code;
        private string name;

        public RoomAtalaya()
        {
        }

        public RoomAtalaya(List<string> hotelAtalayaList, string code, string name)
        {
            this.hotels = hotelAtalayaList;
            this.code = code;
            this.name = name;
        }

        public List<string> Hotels { get => hotels; set => hotels = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }

        public class ListaRoomAtalaya
        {
            public List<RoomAtalaya> rooms_type;
            public List<RoomAtalaya> Rooms_type { get; set; }
        }
    }
}