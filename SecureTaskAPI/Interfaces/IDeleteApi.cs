using SecureTaskAPI.DTOs;

namespace SecureTaskAPI.Interfaces
{
    public interface IDeleteApi
    {
        Task<string> DeleteApiByName(string name);
    }
}
