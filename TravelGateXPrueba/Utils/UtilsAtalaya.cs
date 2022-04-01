using Classes.TravelGateXPrueba;
using TravelGateXPrueba.Classes;

namespace TravelGateXPrueba
{
    internal class UtilsAtalaya
    {
        public ListaHoteles transAtalaya(ListaHotelesAtalaya la)
        {
            ListaHoteles ListaHoteles = new ListaHoteles();
            ListaHoteles.hotels = new List<Hotel>();
            foreach (var hotel in la.hotels)
            {
                Hotel hotelTmp = new Hotel();
                hotelTmp.Name = hotel.Name;
                hotelTmp.City = hotel.City;
                hotelTmp.Code = hotel.Code;
                List<Room> listRoomTmp = new List<Room>();
                foreach(RoomAtalaya room in hotel.Rooms)
                {
                    Room roomTmp = new Room();
                    roomTmp.Room_type = room.Code;
                    roomTmp.Name = room.Name;
                    roomTmp.Meals_plan = room.Meal_plan;
                    roomTmp.Price = room.Price;
                    listRoomTmp.Add(roomTmp);
                }
                hotelTmp.Rooms = listRoomTmp;
                ListaHoteles.hotels.Add(hotelTmp);
            }
            return ListaHoteles;
        }

    }
}
