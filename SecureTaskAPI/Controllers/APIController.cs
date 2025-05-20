using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureTaskAPI.DTOs;
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
        private readonly IAddAPI _addAPI;
        private readonly IGetAllApis _getAllApis;

        public APIController(IGetAPI getAPI , IAddAPI addAPI, IGetAllApis getAllApis)
        {
            _getAPI = getAPI;
            _addAPI = addAPI;
            _getAllApis = getAllApis;
        }

        [HttpGet("GetApi")]
        public async Task<ActionResult<GetDTO?>> GetApi(string name)
        {
            try
            {
                var modelData = await _getAPI.GetAPI(name.ToLower());

                if (modelData == null)
                {
                    return NotFound("Data Doesn't Exist");
                }
                return Ok(modelData);
            }
            catch (Exception ex) {
                return StatusCode(500 , ex.Message);
            }
        }

        [HttpPost("AddApi")]
        public async Task<ActionResult<POSTDto?>> AddApi(POSTDto model)
        {
            try
            {
                var result = await _addAPI.AddAPI(model);
                
                return Ok(result);
            }
            catch(Exception ex) 
            { 
                return StatusCode(500 , ex.Message);
            }
        }

        [HttpGet("GetAllApis")]
        public async Task<List<GetDTOList>> GetAllApis()
        {
            try
            {
                var result = await _getAllApis.getAllApis();
                return result;
            }
            catch (Exception ex) 
            {
                return new List<GetDTOList>();
            }
        }
    }
}
