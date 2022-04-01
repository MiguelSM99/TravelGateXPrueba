namespace TravelGateXPrueba.Classes
{
    public class Hot
    {
        private string room;
        private int price;

        public string Room { get => room; set => room = value; }
        public int Price { get => price; set => price = value; }

        public Hot()
        {
        }

        public Hot(string room, int price)
        {
            this.Room = room;
            this.Price = price;
        }
    }
}