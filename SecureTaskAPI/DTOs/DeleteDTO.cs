using System.ComponentModel.DataAnnotations;

namespace SecureTaskAPI.DTOs
{
    public class DeleteDTO
    {
        [Required]
        public string ApiName {  get; set; }
    }
}
