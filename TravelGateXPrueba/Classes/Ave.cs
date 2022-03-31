namespace TravelGateXPrueba.Classes
{
    public class Ave
    {
        private string room;
        private string price;

        public string Room { get => room; set => room = value; }
        public string Price { get => price; set => price = value; }

        public Ave()
        {
        }

        public Ave(string room, string price)
        {
            this.Room = room;
            this.Price = price;
        }
    }
}