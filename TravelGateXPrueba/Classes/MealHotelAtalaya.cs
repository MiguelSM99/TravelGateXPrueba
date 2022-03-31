using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGateXPrueba.Classes
{
    public class MealHotelAtalaya
    {
        private List<Ave> ave;
        private List<Ac> acs;

        public List<Ave> Ave { get => ave; set => ave = value; }
        public List<Ac> Acs { get => acs; set => acs = value; }

        public MealHotelAtalaya()
        {
        }

        public MealHotelAtalaya(List<Ave> ave, List<Ac> acs)
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
