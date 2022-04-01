using Classes.TravelGateXPrueba;
using TravelGateXPrueba.Classes;

namespace TravelGateXPrueba.Utils
{
    internal class UtilsResort
    {
        public ListaHoteles transResort(ListaHotelesResort la)
        {
            ListaHoteles ListaHoteles = new ListaHoteles();
            ListaHoteles.hotels = new List<Hotel>();
            
            foreach (var hotel in la.hotels)
            {
                Hotel hotelTmp = new Hotel();
                hotelTmp.Name = hotel.Name;
                hotelTmp.City = hotel.Location;
                hotelTmp.Code = hotel.Code;
                List<Room> listRoomTmp = new List<Room>();
                foreach (RoomResort room in hotel.Rooms)
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
