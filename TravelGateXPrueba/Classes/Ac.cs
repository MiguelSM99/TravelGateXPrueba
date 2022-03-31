namespace TravelGateXPrueba.Classes
{
    public class Ac
    {
        private string room;
        private string price;

        public string Room { get => room; set => room = value; }
        public string Price { get => price; set => price = value; }

        public Ac()
        {
        }

        public Ac(string room, string price)
        {
            this.Room = room;
            this.Price = price;
        }
    }
}