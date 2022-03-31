
namespace TravelGateXPrueba.Classes
{
    public class MealHotelAtalaya
    {
        private List<Ave> ave;
        private List<Acs> acs;

        public List<Ave> Ave { get => ave; set => ave = value; }
        public List<Acs> Acs { get => acs; set => acs = value; }

        public MealHotelAtalaya()
        {
        }

        public MealHotelAtalaya(List<Ave> ave, List<Acs> acs)
        {
            this.Ave = ave;
            this.Acs = acs;
        }

        /*public class ListaHotelCode
{
public List<MealHotelAtalaya> hotel_code;
public List<MealHotelAtalaya> Hotel_code { get; set; }
}*/
    }
}
