namespace SecureTaskAPI.Models
{
    public class ApiModel
    {
        public int Id { get; set; }
        public string ApiName { get; set; }
        public string ApiVersion { get; set; }
        public string ApiType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
