using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using VehicleManager.Business;

namespace VehicleManager.Test
{
    [TestFixture]
    public class VehicleReportManagerTests
    {
        private IVehicleReportManager _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Business.VehicleManager();
            UserVehicleDataBuilder(_sut as IUserVehicleManager);
        }

        [Test]
        public void ShouldReturnEqualMpgStatisticWhenThereisOnlyOneEntry()
        {
            const string expectedMake = "BMW";
            const byte expectedMpg = 15;

            var actual = _sut.GetAllMakesMpgStatsitics()
                .First(x => x.Make == expectedMake);

            Assert.That(actual.Make, Is.EqualTo(expectedMake));
            Assert.That(actual.MinimumMpg, Is.EqualTo(expectedMpg));
            Assert.That(actual.MaximumMpg, Is.EqualTo(expectedMpg));
            Assert.That(actual.AverageMpg, Is.EqualTo(expectedMpg));
        }
        [Test]
        public void ShouldReturnCorrectMpgStatisticWhenThereAreTwoDataEntries()
        {
            const string expectedMake = "Mini";
            const byte expectedMinimumMpg = 25;
            const byte expectedMaximumMpg = 33;
            const byte expectedAverageMpg = 29;
            var actual = _sut.GetAllMakesMpgStatsitics()
                       .First(x => x.Make == expectedMake);

            Assert.That(actual.Make, Is.EqualTo(expectedMake));
            Assert.That(actual.MinimumMpg, Is.EqualTo(expectedMinimumMpg));
            Assert.That(actual.MaximumMpg, Is.EqualTo(expectedMaximumMpg));
            Assert.That(actual.AverageMpg, Is.EqualTo(expectedAverageMpg));
        }
        [Test]
        public void ShouldReturnCorrectMpgAverageWhenRoundingIsInvolved()
        {
            const string expectedMake = "Toyota";
            const byte expectedMinimumMpg = 29;
            const byte expectedMaximumMpg = 55;
            const byte expectedAverageMpg = 40;
            var actual = _sut.GetAllMakesMpgStatsitics()
                       .First(x => x.Make == expectedMake);

            Assert.That(actual.Make, Is.EqualTo(expectedMake));
            Assert.That(actual.MinimumMpg, Is.EqualTo(expectedMinimumMpg));
            Assert.That(actual.MaximumMpg, Is.EqualTo(expectedMaximumMpg));
            Assert.That(actual.AverageMpg, Is.EqualTo(expectedAverageMpg));
        }

        private static void UserVehicleDataBuilder(IUserVehicleManager vehicleManager)
        {
            vehicleManager.AddVehicle(Guid.NewGuid().ToString(), "BMW", 15);
            vehicleManager.AddVehicle(Guid.NewGuid().ToString(), "Mini", 25);
            vehicleManager.AddVehicle(Guid.NewGuid().ToString(), "Mini", 33);
            vehicleManager.AddVehicle(Guid.NewGuid().ToString(), "Toyota", 29);
            vehicleManager.AddVehicle(Guid.NewGuid().ToString(), "Toyota", 37);
            vehicleManager.AddVehicle(Guid.NewGuid().ToString(), "Toyota", 55);
        }
    }
}