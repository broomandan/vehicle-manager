using System;

namespace VehicleManager.Business
{
    public class UserVehicle
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public byte Mpg { get; set; }
        public VehicleMake Make { get; set; }
    }
}