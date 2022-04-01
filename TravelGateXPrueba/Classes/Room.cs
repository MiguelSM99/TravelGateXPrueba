using TravelGateXPrueba.Classes;

namespace Classes.TravelGateXPrueba
{
    public class Room
    {
        private string name;
        private string room_type;
        private string meals_plan;
        private double price;
        private string nights;

        public Room()
        {
        }

        public Room(string room_type, string name, string meals_plan, double price, string nights)
        {
            this.Room_type = room_type;
            this.Name = name;
            this.Meals_plan = meals_plan;
            this.Price = price;
            this.nights = nights;
        }

        public string Room_type { get => room_type; set => room_type = value; }
        public string Name { get => name; set => name = value; }
        public string Meals_plan { get => meals_plan; set => meals_plan = value; }
        public double Price { get => price; set => price = value; }
        public string Nights { get => nights; set => nights = value; }

        public class ListaRoom
        {
            public List<Room> rooms;
        }
    }
}
