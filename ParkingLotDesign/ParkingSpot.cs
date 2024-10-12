using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotDesign
{
    public enum SpotType { Motorcycle, Compact, Regular }

    public class ParkingSpot(SpotType spotType)
    {
        public SpotType Type { get; private set; } = spotType;
        public bool IsSpotAvailable { get; private set; } = true; //Spot is initially empty
        public Vehicle? ParkedVehicle { get; private set; }

        //public ParkingSpot(SpotType spotType)
        //{
        //    Type = spotType;
        //}

        public bool VehicleFitToPark(Vehicle vehicleObj)
        {
            if(vehicleObj.CanParkInAnySpot(this) && IsSpotAvailable)
            {
                ParkedVehicle = vehicleObj;
                IsSpotAvailable = false;
                return true;
            }

            return false;
        }

        public void CarVacatesSpot()
        {
            ParkedVehicle = null;
            IsSpotAvailable = true;
        }


    }
}
