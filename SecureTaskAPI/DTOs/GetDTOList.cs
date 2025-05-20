using System.ComponentModel.DataAnnotations;

namespace SecureTaskAPI.DTOs
{
    public class GetDTOList
    {
        public DateTime CreatedAt { get; set; }
        public string ApiName { get; set; }

        public string ApiVersion { get; set; }

        public string ApiType { get; set; }

    }
}
