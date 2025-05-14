using System.ComponentModel.DataAnnotations;

namespace SecureTaskAPI.DTOs
{
    public class POSTDto
    {
        [Required]
        public string ApiName { get; set; }

        [Required]
        public string ApiType { get; set; }

        public string ApiVersion { get; set; }

    }
}
