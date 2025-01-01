using System.ComponentModel.DataAnnotations;

namespace InventoryService.RequestAndResponseModels
{
    public class InventoryRequestModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string? Application { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Environment { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? HostName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? IpAddress { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? OperatingSystem { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? DatabaseVersion { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? DatabaseName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? InstanceName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? TNS { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? SysNSystCred { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? OraCred { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string? DbAdCred { get; set; }


        public string? Remark { get; set; }
    }
}
