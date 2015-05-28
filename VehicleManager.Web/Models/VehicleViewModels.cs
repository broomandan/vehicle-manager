using System.ComponentModel.DataAnnotations;

namespace VehicleManager.Web.Models
{
    public class VehicleMakeViewModel
    {
        [Required(ErrorMessage = "Make should always be defined.")]
        public string Make { get; set; }
    }
}