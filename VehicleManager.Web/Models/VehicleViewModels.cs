using System.ComponentModel.DataAnnotations;

namespace VehicleManager.Web.Models
{
    public class VehicleMakeModel
    {
        [Required(ErrorMessage = "Make should always be defined.")]
        public string Make { get; set; }
    }
}