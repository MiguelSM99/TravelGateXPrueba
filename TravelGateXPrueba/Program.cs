using TravelGateXPrueba;
using Newtonsoft.Json;
using Classes.TravelGateXPrueba;
using TravelGateXPrueba.Classes;
using TravelGateXPrueba.Utils;
using static Classes.TravelGateXPrueba.Room;
using TravelGateXPrueba.Tests;

namespace TravelgateXPrueba
{
    public class MainStart
    {
        static void Main(string[] args)
        {
           Punto1 punto1 = new Punto1();
            ListaHoteles hotelList = punto1.Test();
            string jsonNew = JsonConvert.SerializeObject(hotelList, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            Console.WriteLine(jsonNew);

            Punto2 punto2 = new Punto2();
            IDictionary<string, string> mealPlanCity = new Dictionary<string, string>();
            mealPlanCity.Add("Malaga", "");
            mealPlanCity.Add("Cancun", "ad");
            double max_price = 700;
            bool cheap = true;
            string cheaper_city = "Malaga";
            Console.WriteLine(punto2.Test(hotelList, mealPlanCity, max_price, cheap, cheaper_city));
        }
    }
}

