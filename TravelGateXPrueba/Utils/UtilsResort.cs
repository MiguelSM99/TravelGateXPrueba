using Classes.TravelGateXPrueba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGateXPrueba.Classes;

namespace TravelGateXPrueba.Utils
{
    internal class UtilsResort
    {
        public ListaHoteles transResort(ListaHotelesResort la)
        {
            ListaHoteles ListaHoteles = new ListaHoteles();
            ListaHoteles.hotels = new List<Hotels>();
            Hotels hotelTmp = new Hotels();
            foreach (var hotel in la.hotels)
            {
                hotelTmp.Name = hotel.Name;
                hotelTmp.City = hotel.Location;
                hotelTmp.Code = hotel.Code;
                hotelTmp.Rooms = hotel.Rooms;
                ListaHoteles.hotels.Add(hotelTmp);
            }
            return ListaHoteles;
        }

    }
}
