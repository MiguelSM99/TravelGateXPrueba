using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelGateXPrueba.Classes
{
    public class MealPlanAtalaya
    {
        private string code;
        private string name;
        private MealHotelAtalaya hotel;

        public MealPlanAtalaya()
        {
        }

        public MealPlanAtalaya(string code, string name, MealHotelAtalaya hotel_code)
        {
            this.Code = code;
            this.Name = name;
            this.Hotel = hotel_code;
        }

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public MealHotelAtalaya Hotel { get => hotel; set => hotel = value; }

        public class ListaMealPlanAtalaya
        {
            public List<MealPlanAtalaya> meal_plans;
            public List<MealPlanAtalaya> Meal_plans { get; set; }
        }
    }
}
