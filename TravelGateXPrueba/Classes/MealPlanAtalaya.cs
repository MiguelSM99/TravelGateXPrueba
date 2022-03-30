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
        private string hotel;
        private string room_type;
        private double price;

        public MealPlanAtalaya()
        {
        }

        public MealPlanAtalaya(string code, string name, string hotel, string room_type, double price)
        {
            this.Code = code;
            this.Name = name;
            this.Hotel = hotel;
            this.Room_type = room_type;
            this.Price = price;
        }

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Hotel { get => hotel; set => hotel = value; }
        public string Room_type { get => room_type; set => room_type = value; }
        public double Price { get => price; set => price = value; }

        public class ListaMealPlan
        {
            public List<MealPlanAtalaya> meals;
            public List<MealPlanAtalaya> Meals { get; set; }
        }
    }
}
