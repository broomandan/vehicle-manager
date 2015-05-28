using System;
using System.Collections.Generic;

namespace VehicleManager.Business
{
    public interface IUserVehicleManager
    {
        IEnumerable<UserVehicle> GetVehicles(string userIdentifier);
        void AddVehicle(string userIdentity, string make, uint mpg);
        void DeleteVehicle(Guid id);
        UserVehicle FindVehicle(Guid id);
        void UpdateVehicleMpg(Guid id, uint mpg);
    }
}