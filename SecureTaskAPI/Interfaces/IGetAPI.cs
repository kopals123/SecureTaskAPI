using SecureTaskAPI.DTOs;

namespace SecureTaskAPI.Interfaces
{
    public interface IGetAPI
    {
        Task<GetDTO?> GetAPI(string apiName);
    }
}
