using System.Collections.Generic;

namespace VehicleManager.Business
{
    public interface IVehicleReportManager
    {
        IEnumerable<MakeMpgStatistics> GetAllMakesMpgStatsitics();
    }
}