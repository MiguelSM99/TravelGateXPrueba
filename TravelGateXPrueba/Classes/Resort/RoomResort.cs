namespace TravelGateXPrueba.Classes
{
    public class RoomResort
    {
        private string code;
        private string name;
        private string meal_plan;
        private double price;
        
        public RoomResort()
        {
        }

        public RoomResort(string code, string name, string meal_plan, double price)
        {
            this.code = code;
            this.name = name;
            this.Meal_plan = meal_plan;
            this.price = price;
        }

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Meal_plan { get => meal_plan; set => meal_plan = value; }
        public double Price { get => price; set => price = value; }

        public class ListaRoomResort
        {
            public List<RoomResort> rooms;
            public List<RoomResort> Rooms { get; set; }
        }
    }
}
