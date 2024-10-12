using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign
{
    public abstract class Vehicle(string numberPlate)
    {
        public string NumberPlate { get; private set; } = numberPlate;

        //public Vehicle(string numberPlate)
        //{
        //    NumberPlate = numberPlate;
        //}

        public abstract bool CanParkInAnySpot(ParkingSpot parkingSpot);
    }
}
