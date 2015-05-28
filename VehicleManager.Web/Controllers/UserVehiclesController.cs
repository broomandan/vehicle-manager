using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using VehicleManager.Business;
using VehicleManager.Web.Models;

namespace VehicleManager.Web.Controllers
{
    public class UserVehiclesController : Controller
    {
        private readonly IUserVehicleManager _userVehicleManager;
        private readonly string _currentUserName;

        public UserVehiclesController(IUserVehicleManager userVehicleManager)
        {
            //TODO Extend user identity to include userId 
            _currentUserName = User.Identity.GetUserId();
            _userVehicleManager = userVehicleManager;
        }

        public UserVehiclesController()
        {
            _userVehicleManager = new Business.VehicleManager();
        }

        // GET: UserVehicles
        public ActionResult Index()
        {
            var vehicles = _userVehicleManager.GetVehicles(_currentUserName);
            //TODO utilize AutoMapper
            var viewModel = vehicles.Select(x => new UserVehicleViewModel
            {
                Id = x.Id,
                Mpg = x.Mpg,
                Make = x.Make.Make
            });
            return View(viewModel);
        }

        // GET: UserVehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserVehicles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var make = collection["Make"];
                var mpg = uint.Parse(collection["Mpg"]);

                _userVehicleManager.AddVehicle(_currentUserName, make, mpg);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserVehicles/Edit/5
        [Route("UserVehicles/Edit/{id:guid}")]
        public ActionResult Edit(Guid id)
        {
            return View();
        }

        // POST: UserVehicles/Edit/5
        [HttpPost]
        [Route("UserVehicles/Edit/{id:guid}")]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                var mpg = uint.Parse(collection["mpg"]);
                _userVehicleManager.UpdateVehicleMpg(id, mpg);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserVehicles/Delete/5
        [Route("UserVehicles/Delete/{id:guid}")]
        public ActionResult Delete(Guid id)
        {
            var vehicle = _userVehicleManager.FindVehicle(id);
            var viewModel = new UserVehicleViewModel
            {
                Id = id,
                Make = vehicle.Make.Make,
                Mpg = vehicle.Mpg
            };
            return View(viewModel);
        }

        // POST: UserVehicles/Delete/5
        [HttpPost]
        [Route("UserVehicles/Delete/{id:guid}")]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                _userVehicleManager.DeleteVehicle(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}