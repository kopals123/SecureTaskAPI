using Microsoft.AspNetCore.Mvc;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Interfaces;

namespace SecureTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IGetAPI _getAPI;
        private readonly IAddAPI _addAPI;
        private readonly IGetAllApis _getAllApis;
        private readonly IDeleteApi _deleteApi;
        private readonly IUpdateApi _updateApi;

        public APIController(IGetAPI getAPI , IAddAPI addAPI, IGetAllApis getAllApis , IDeleteApi deleteApi , IUpdateApi updateApi)
        {
            _getAPI = getAPI;
            _addAPI = addAPI;
            _getAllApis = getAllApis;
            _deleteApi = deleteApi;
            _updateApi = updateApi;
        }

        [HttpGet("GetApi")]
        public async Task<ActionResult<GetDTO?>> GetApi(string name)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            try
            {
                var modelData = await _getAPI.GetAPI(name.ToLower());

                if (modelData == null)
                {
                    return NotFound("Data Doesn't Exist");
                }

                stopwatch.Stop();
                HttpContext.Response.Headers.Append("X-Response-Time", $"{stopwatch.ElapsedMilliseconds}ms");
                
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

        [HttpDelete("DeleteApi")]
        public async Task<ActionResult> DeleteApi(string name)
        {
            try
            {
                var result = await _deleteApi.DeleteApiByName(name.ToLower());

                if (result.Contains("Doesnt"))
                    return NotFound(result);

                return Ok(name);
            }
            catch(Exception ex)
            {
                return StatusCode(500 , ex.Message);
            }
        }

        [HttpPatch("UpdateApi")]
        public async Task<ActionResult> UpdateApi(UpdateDTO updateDTO)
        {
            try
            {
                var result = await _updateApi.UpdateApiAsync(updateDTO);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
