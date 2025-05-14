using System.ComponentModel.DataAnnotations;

namespace SecureTaskAPI.DTOs
{
    public class GetDTO
    {
        [Required]
        public string ApiName { get; set; }

        [Required]
        public string ApiType { get; set; }

        [Required]
        public string ApiVersion { get; set; }
    }
}
