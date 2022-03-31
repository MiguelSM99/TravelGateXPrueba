namespace TravelGateXPrueba.Classes
{
    public class Ave
    {
        private string room;
        private double price;

        public string Room { get => room; set => room = value; }
        public double Price { get => price; set => price = value; }

        public Ave()
        {
        }

        public Ave(string room, double price)
        {
            this.Room = room;
            this.Price = price;
        }
    }
}