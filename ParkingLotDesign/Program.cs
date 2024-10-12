namespace ParkingLotDesign
{
    public class Solution
    {
        public static void Main(string[] args)
        {
            ArgumentNullException.ThrowIfNull(args);

            ParkingLot HefkayParkingLot = new/*ParkingLot*/(1, 1, 4);

            var temiladeBike = new Motorcycle("IKD423EA");
            var bashirCar = new Car("AAA45AJK");
            var mobilVan = new Van("EPE231AY");
            var totalVan = new Van("AKD441DY");

            HefkayParkingLot.ParkVehicle(temiladeBike);
            HefkayParkingLot.ParkVehicle(bashirCar);
            HefkayParkingLot.ParkVehicle(mobilVan);
            HefkayParkingLot.ParkVehicle(totalVan);

            Console.WriteLine(HefkayParkingLot.GetSpotsRemaining());

            Console.WriteLine(HefkayParkingLot.TotalSpotsInLot());

            Console.WriteLine(HefkayParkingLot.IsLotFull());

            Console.WriteLine(HefkayParkingLot.IsLotEmpty());

            Console.WriteLine(HefkayParkingLot.CertainSpotsFull());

            Console.WriteLine(HefkayParkingLot.SpotsVanTake());

        }
    }
}