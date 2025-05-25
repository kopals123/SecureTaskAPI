using SecureTaskAPI.DTOs;

namespace SecureTaskAPI.Interfaces
{

    public interface IAddAPI
    {
        Task<string> AddAPI(POSTDto dto);
    }
}
