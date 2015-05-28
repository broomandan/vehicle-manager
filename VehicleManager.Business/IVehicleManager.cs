using System.Collections.Generic;

namespace VehicleManager.Business
{
    public interface IVehicleManager
    {
        IEnumerable<VehicleMake> GetMakes();
        void AddMake(string vehicleMake);
        void UpdateMake(string oldMake, string newMake);
        VehicleMake FindMake(string make);
        void DeleteMake(string make);
    }
}