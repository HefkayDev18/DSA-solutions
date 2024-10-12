using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign
{
    public class Motorcycle(string numberPlate) : Vehicle(numberPlate)
    {
        //public Motorcycle(string licensePlate) : base(licensePlate) { }

        public override bool CanParkInAnySpot(ParkingSpot parkingSpot)
        {
            return true;
        }
    }

    public class Car(string numberPlate) : Vehicle(numberPlate)
    {
        public override bool CanParkInAnySpot(ParkingSpot parkingSpot)
        {
            return parkingSpot.Type == SpotType.Compact || parkingSpot.Type == SpotType.Regular;
        }
    }

    public class Van(string numberPlate) : Vehicle(numberPlate)
    {
        public override bool CanParkInAnySpot(ParkingSpot parkingSpot)
        {
            return parkingSpot.Type == SpotType.Regular;
        }
    }
}
