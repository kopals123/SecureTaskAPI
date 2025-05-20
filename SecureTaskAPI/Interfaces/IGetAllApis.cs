using SecureTaskAPI.DTOs;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Interfaces
{
    public interface IGetAllApis
    {
        Task<List<GetDTOList>> getAllApis();
    }
}
