using System.Collections.Generic;
using System.Linq;

namespace VehicleManager.Business
{
    public class VehicleManager : IVehicleManager
    {
        private static readonly IList<VehicleMake> VehicleMakes;

        //Work around for not having DI container 
        static VehicleManager()
        {
            VehicleMakes = new List<VehicleMake>
            {
                new VehicleMake {Make = "BMW"},
                new VehicleMake {Make = "Chevrolet"},
                new VehicleMake {Make = "Mini"},
                new VehicleMake {Make = "Toyota"}
            };
        }

        public ICollection<VehicleMake> GetMakes()
        {
            return VehicleMakes;
        }

        public void AddMake(string vehicleMake)
        {
            if (FindMake(vehicleMake) != null)
            {
                throw new DuplicateEntryException();
            }

            VehicleMakes.Add(new VehicleMake
            {
                Make = vehicleMake
            });
        }

        public void UpdateMake(string oldMake, string newMake)
        {
            var updatingVehicle = FindMake(oldMake);
            if (updatingVehicle == null)
            {
                throw new VehicleNotFoundException(string.Format("No vehicle found to update. Make={0}", oldMake));
            }
            updatingVehicle.Make = newMake;
        }

        public VehicleMake FindMake(string make)
        {
            return VehicleMakes.FirstOrDefault(v => v.Make == make);
        }

        public void DeleteMake(string make)
        {
            var deletingMake = FindMake(make);
            VehicleMakes.Remove(deletingMake);
        }
    }
}