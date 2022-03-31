namespace Classes.TravelGateXPrueba
{
    public class Room
    {
        private string code;
        private string name;
        private string meal_plan;
        private double price;

        public Room()
        {
        }

        public Room(string code, string name, string meal_plan, double price)
        {
            this.Code = code;
            this.Name = name;
            this.Meal_plan = meal_plan;
            this.Price = price;
        }

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Meal_plan { get => meal_plan; set => meal_plan = value; }
        public double Price { get => price; set => price = value; }
    }
}
