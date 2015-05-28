using System.Linq;
using System.Web.Mvc;
using VehicleManager.Business;
using VehicleManager.Web.Models;

namespace VehicleManager.Web.Controllers
{
    [Authorize(Roles = "administrator")]
    public class ReportsController : Controller
    {
        private readonly IVehicleReportManager _vehicleReportManager;

        public ReportsController(IVehicleReportManager vehicleReportManager)
        {
            _vehicleReportManager = vehicleReportManager;
        }

        public ReportsController()
        {
            _vehicleReportManager = new Business.VehicleManager();
        }

        // GET: Reports
        public ActionResult Index()
        {
            var allMakes = _vehicleReportManager.GetAllMakesMpgStatsitics();
            var report = allMakes.Select(x => new MpgReportViewModel
            {
                Make = x.Make,
                MinimumMpg = x.MinimumMpg,
                MaximumMpg = x.MaximumMpg,
                AverageMpg = x.AverageMpg
            });
            return View(report);
        }
    }
}