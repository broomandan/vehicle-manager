using System.Linq;
using System.Web.Mvc;
using VehicleManager.Business;
using VehicleManager.Web.Models;

namespace VehicleManager.Web.Controllers
{
    [Authorize(Roles = "administrator")]
    public class VehiclesController : Controller
    {
        private readonly IVehicleManager _vehicleManager;

        public VehiclesController(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        public VehiclesController()
        {
            _vehicleManager = new Business.VehicleManager();
        }

        // GET: Vehicles
        public ActionResult Index()
        {
            var model = _vehicleManager.GetMakes();
            // TODO: use AutoMapper
            var viewModel = model.Select(x => new VehicleMakeViewModel
            {
                Make = x.Make
            });
            return View(viewModel);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //TODO make this a strongly typed paramter
                var make = collection["Make"];
                _vehicleManager.AddMake(make);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehicles/Edit/5
        [Route("Vehicles/Edit/{id:string}")]
        public ActionResult Edit(string id)
        {
            var viewModel = FindVehicleMakeModel(id);
            return View(viewModel);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [Route("Vehicles/Edit/{id:string}")]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                //TODO make this a strongly typed paramter
                var make = collection["Make"];
                _vehicleManager.UpdateMake(id, make);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehicles/Delete/5
        [Route("Vehicles/Delete/{id:string}")]
        public ActionResult Delete(string id)
        {
            var viewModel = FindVehicleMakeModel(id);
            return View(viewModel);
        }

        // POST: Vehicles/Delete/5
        [HttpPost]
        [Route("Vehicles/Delete/{id:string}")]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                _vehicleManager.DeleteMake(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private VehicleMakeViewModel FindVehicleMakeModel(string id)
        {
            var make = _vehicleManager.FindMake(id);
            var viewModel = new VehicleMakeViewModel {Make = make.Make};
            return viewModel;
        }
    }
}