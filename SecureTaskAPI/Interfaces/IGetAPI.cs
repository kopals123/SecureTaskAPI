using SecureTaskAPI.DTOs;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Interfaces
{
    public interface IGetAPI
    {
        Task<ApiModel?> GetAPI(string apiName);
    }
}
