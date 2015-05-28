using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VehicleManager.Web.Models
{
    public class UserVehicleViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Mile Per Galon")]
        public uint Mpg { get; set; }

        [Required]
        [ReadOnly(true)]
        public string Make { get; set; }
    }
}