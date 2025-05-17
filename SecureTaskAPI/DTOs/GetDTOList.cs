using System.ComponentModel.DataAnnotations;

namespace SecureTaskAPI.DTOs
{
    public class GetDTOList
    {
        [Required]
        public string ApiType { get; set; }

    }
}
