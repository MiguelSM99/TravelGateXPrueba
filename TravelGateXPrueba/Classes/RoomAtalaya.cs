namespace TravelGateXPrueba.Classes
{
    public class RoomAtalaya
    {
        private List<string> hotels;
        private string code;
        private string name;
        private string meal_plan;
        private double price;

        public RoomAtalaya()
        {
        }

        public RoomAtalaya(List<string> hotelAtalayaList, string code, string name, string meal_plan, double price)
        {
            this.hotels = hotelAtalayaList;
            this.code = code;
            this.name = name;
            this.Meal_plan = meal_plan;
            this.price = price;
        }

        public List<string> Hotels { get => hotels; set => hotels = value; }
        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public string Meal_plan { get => meal_plan; set => meal_plan = value; }
        public double Price { get => price; set => price = value; }

        public class ListaRoomAtalaya
        {
            public List<RoomAtalaya> rooms_type;
            public List<RoomAtalaya> Rooms_type { get; set; }
        }
    }
}
