using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VehicleManager.Web.Models
{
    public class UserVehicleViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Mile Per Galon")]
        [Range(0, byte.MaxValue)]
        public byte Mpg { get; set; }

        [Required]
        [ReadOnly(true)]
        public string Make { get; set; }

        public IEnumerable<SelectListItem> Makes { get; set; }
    }
}