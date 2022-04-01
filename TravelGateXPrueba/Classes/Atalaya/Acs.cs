namespace TravelGateXPrueba.Classes
{
    public class Acs
    {
        private string room;
        private double price;

        public string Room { get => room; set => room = value; }
        public double Price { get => price; set => price = value; }

        public Acs()
        {
        }

        public Acs(string room, double price)
        {
            this.Room = room;
            this.Price = price;
        }
    }
}