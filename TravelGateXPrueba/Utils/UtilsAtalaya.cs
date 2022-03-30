using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGateXPrueba.Classes;

namespace TravelGateXPrueba
{
    internal class UtilsAtalaya
    {
        public ListaHoteles transAtalaya(ListaHotelesAtalaya la)
        {
            ListaHoteles ListaHoteles = new ListaHoteles();
            ListaHoteles.hotels = new List<Hotels>();
            Hotels hotelTmp = new Hotels();
            foreach (var hotel in la.hotels)
            {
                hotelTmp.Name = hotel.Name;
                hotelTmp.City = hotel.City;
                hotelTmp.Code = hotel.Code;
                //hotelTmp.Rooms = hotel.Rooms;
                ListaHoteles.hotels.Add(hotelTmp);
            }
            return ListaHoteles;
        }

    }
}
