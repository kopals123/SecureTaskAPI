using SecureTaskAPI.DTOs;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Interfaces
{

    public interface IAddAPI
    {
        Task<string> AddAPI(POSTDto dto);
    }
}
