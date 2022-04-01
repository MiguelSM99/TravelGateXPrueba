using Classes.TravelGateXPrueba;
using Newtonsoft.Json;
using TravelGateXPrueba.Classes;
using TravelGateXPrueba.Utils;

namespace TravelGateXPrueba.Tests
{
    internal class Punto1
    {
        public ListaHoteles Test()
        {
            //Punto1
            Console.WriteLine("\nPUNTO 1. RECOGIDA CONSENSUADA DE LA INFORMACIO DE LOS HOTELES\n");
            ListaHoteles hotelList = new ListaHoteles();
            hotelList.hotels = new List<Hotel>();

            ConexionAtalaya ca = new ConexionAtalaya();
            ListaHotelesAtalaya la = ca.Conexion();
            UtilsAtalaya uA = new UtilsAtalaya();

            ConexionResort lr = new ConexionResort();
            ListaHotelesResort lhr = lr.Conexion();
            UtilsResort uR = new UtilsResort();

            ListaHoteles transAt = uA.transAtalaya(la);
            ListaHoteles transRe = uR.transResort(lhr);

            hotelList.hotels.AddRange(transRe.hotels);
            hotelList.hotels.AddRange(transAt.hotels);
            return hotelList;
        }
    }
}
