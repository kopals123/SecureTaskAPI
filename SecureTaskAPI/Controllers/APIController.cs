using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureTaskAPI.Interfaces;
using SecureTaskAPI.Models;
using SecureTaskAPI.Service;

namespace SecureTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IGetAPI _getAPI;

        public APIController(IGetAPI getAPI)
        {
            _getAPI = getAPI;
        }

        [HttpGet("GetApi")]
        public async Task<ApiModel?> GetApi(string name)
        {
            try
            {
                var modelData = await _getAPI.GetAPI(name);
                if (modelData == null)
                {
                    return null;
                }
                return modelData;
            }
            catch (Exception ex) {
                return null;
            }
        }
    }
}
