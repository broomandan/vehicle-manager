﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleManager.Business
{
    public class VehicleManager : IVehicleManager, IUserVehicleManager, IVehicleReportManager
    {
        // These to static objects playing the role of database/database access in this implemenation  
        private static readonly IList<VehicleMake> VehicleMakes;
        private static readonly IList<UserVehicle> UserVehicles;

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

            UserVehicles = new List<UserVehicle>();
        }

        public IEnumerable<VehicleMake> GetMakes()
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

        public IEnumerable<UserVehicle> GetVehicles(string userIdentifier)
        {
            return UserVehicles
                .Where(x => x.UserId == userIdentifier);
        }

        public void AddVehicle(string userIdentity, string make, byte mpg)
        {
            var vehicle = new UserVehicle
            {
                Id = Guid.NewGuid(),
                UserId = userIdentity,
                Make = new VehicleMake {Make = make},
                Mpg = mpg
            };
            UserVehicles.Add(vehicle);
        }

        public void DeleteVehicle(Guid id)
        {
            var deletingVehicle = FindVehicle(id);
            UserVehicles.Remove(deletingVehicle);
        }

        public UserVehicle FindVehicle(Guid id)
        {
            return UserVehicles
                .FirstOrDefault(x => x.Id == id);
        }

        public void UpdateVehicleMpg(Guid id, byte mpg)
        {
            var updatingVehicle = FindVehicle(id);
            updatingVehicle.Mpg = mpg;
        }

        public IEnumerable<MakeMpgStatistics> GetAllMakesMpgStatsitics()
        {
            return UserVehicles
                .GroupBy(m => m.Make.Make)
                .Select(g => new MakeMpgStatistics
                {
                    Make = g.Key,
                    MinimumMpg = g.Min(i => i.Mpg),
                    MaximumMpg = g.Max(i => i.Mpg),
                    AverageMpg = (byte) g.Average(i => i.Mpg)
                });
        }
    }
}