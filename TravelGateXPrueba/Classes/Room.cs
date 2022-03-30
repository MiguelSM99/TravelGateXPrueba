using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGateXPrueba.Classes;

namespace Classes.TravelGateXPrueba
{
    public class Room
    {
        private string name;
        private int room_type;
        private string meals_plan;
        private double price;
        private MealPlan mealPlan;
        public Room()
        {
        }

        public Room(string name, int room_type, string meals_plan, double price, MealPlan mealPlan)
        {
            this.Name = name;
            this.Room_type = room_type;
            this.Meals_plan = meals_plan;
            this.Price = price;
            this.mealPlan = mealPlan;
        }

        public string Name { get => name; set => name = value; }
        public int Room_type { get => room_type; set => room_type = value; }
        public string Meals_plan { get => meals_plan; set => meals_plan = value; }
        public double Price { get => price; set => price = value; }
        public MealPlan MealPlan { get => mealPlan; set => mealPlan = value; }
    }
}
