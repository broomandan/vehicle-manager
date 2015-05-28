using System;

namespace VehicleManager.Business
{
    public class VehicleMake
    {
        public string Make { get; set; }
    }

    class Vehicle : VehicleMake
    {
        public Guid Id { get; set; }
        public uint Mpg { get; set; }
    }
}