using System.ComponentModel.DataAnnotations;

namespace SecureTaskAPI.DTOs
{
    public class UpdateDTO
    {
        [Required]
        public string ApiName { get; set; }

        public string? ApiVersion { get; set; }

        public string? ApiType { get; set; }
    }
}
