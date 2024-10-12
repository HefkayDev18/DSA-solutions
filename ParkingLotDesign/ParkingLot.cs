using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ParkingLotDesign
{
    public class ParkingLot
    {
        private readonly List<ParkingSpot> motorcycleSpots;
        private readonly List<ParkingSpot> compactSpots;
        private readonly List<ParkingSpot> regularSpots;

        private int SpotsTakenByVan = 0;
        private readonly List<Vehicle> VansTracker = [];

        public ParkingLot(int designatedMotorcyleSpots, int designatedCompactSpots, int designatedRegularSpots)
        {
            motorcycleSpots = new List<ParkingSpot>(designatedMotorcyleSpots);
            compactSpots = new List<ParkingSpot>(designatedCompactSpots);
            regularSpots = new List<ParkingSpot>(designatedRegularSpots);

            for (int i = 0; i < designatedMotorcyleSpots; i++)
                motorcycleSpots.Add(new ParkingSpot(SpotType.Motorcycle));

            for (int i = 0; i < designatedCompactSpots; i++)
                compactSpots.Add(new ParkingSpot(SpotType.Compact));

            for (int i = 0; i < designatedRegularSpots; i++)
                regularSpots.Add(new ParkingSpot(SpotType.Regular));
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            if (vehicle is Motorcycle)
                return ParkInAvailableSpot(vehicle, motorcycleSpots) || ParkInAvailableSpot(vehicle, compactSpots) ||
                    ParkInAvailableSpot(vehicle, regularSpots);

            if (vehicle is Car)
                return ParkInAvailableSpot(vehicle, compactSpots) || ParkInAvailableSpot(vehicle, regularSpots);

            if (vehicle is Van)
                return ParkVanInRegularSpot(vehicle);

            return false;
        }

        public static bool ParkInAvailableSpot(Vehicle vehicle, List<ParkingSpot> spots)
        {
            foreach (var spot in spots)
            {
                if (spot.IsSpotAvailable && spot.VehicleFitToPark(vehicle))
                {
                    return true;
                }

            }
            return false;
        }

        public bool ParkVanInRegularSpot(Vehicle van)
        {
            int SpotsRequired = 3;

            for (int i = 0; i < regularSpots.Count - SpotsRequired; i++)
            {
                if (regularSpots[i].IsSpotAvailable && regularSpots[i + 1].IsSpotAvailable && regularSpots[i + 2].IsSpotAvailable)
                {
                    for (int j = 0; j < SpotsRequired; j++)
                    {
                        regularSpots[i + j].VehicleFitToPark(van);                   
                    }

                    VansTracker.Add(van);
                    SpotsTakenByVan = VansTracker.Count * SpotsRequired;

                    return true;
                }
            }
            return false;
        }

        public int TotalSpotsInLot()
        {
            return motorcycleSpots.Count + compactSpots.Count + regularSpots.Count;
        }

        public int GetSpotsRemaining()
        {
            return motorcycleSpots.Count(s => s.IsSpotAvailable) + compactSpots.Count(s => s.IsSpotAvailable) + regularSpots.Count(s => s.IsSpotAvailable);
        }

        public string CertainSpotsFull()
        {
            List<string> filledSpots = [];

            if (!motorcycleSpots.Any(k => k.IsSpotAvailable))
                filledSpots.Add("Motorcycle spots");

            if (!compactSpots.Any(k => k.IsSpotAvailable))
                filledSpots.Add("Compact spots");

            if (!regularSpots.Any(k => k.IsSpotAvailable))
                filledSpots.Add("Regular spots");

            if(filledSpots.Count == 0)
                return "All spots are not yet filled";

            return string.Join(", ", filledSpots) + " are filled";
        }

        public bool IsLotFull()
        {
            return GetSpotsRemaining() == 0;
        }

        public bool IsLotEmpty()
        {
            return motorcycleSpots.All(s => s.IsSpotAvailable) && compactSpots.All(s => s.IsSpotAvailable) && regularSpots.All(s => s.IsSpotAvailable);
        }

        public int SpotsVanTake()
        {
            return SpotsTakenByVan;
        }
    }
}
