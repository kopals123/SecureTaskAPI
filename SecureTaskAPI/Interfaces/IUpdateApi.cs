using SecureTaskAPI.DTOs;

namespace SecureTaskAPI.Interfaces
{
    public interface IUpdateApi
    {
        Task<string> UpdateApiAsync(UpdateDTO updateDTO);
    }
}
