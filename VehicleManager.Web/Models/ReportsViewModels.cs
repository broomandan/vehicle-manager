using System.ComponentModel.DataAnnotations;

namespace VehicleManager.Web.Models
{
    public class MpgReportViewModel
    {
        public string Make { get; set; }

        [Display(Name = "Minimum MPG")]
        public byte MinimumMpg { get; set; }

        [Display(Name = "Maximum MPG")]
        public byte MaximumMpg { get; set; }

        [Display(Name = "Average MPG")]
        public byte AverageMpg { get; set; }
    }
}