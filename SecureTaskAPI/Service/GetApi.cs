using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Interfaces;

namespace SecureTaskAPI.Service
{
    public class GetApi : IGetAPI
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly ILogger<GetApi> _logger;

        public GetApi(AppDbContext dbContext , IMapper mapper, ILogger<GetApi> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetDTO?> GetAPI(string apiName)
        {

            try
            {
                var result =  await _dbContext?.ApiModel.FirstOrDefaultAsync(x => x.ApiName == apiName);

                _logger.LogInformation("GetApi Successfull" + DateTime.Now.ToString() + apiName);
                
                return result == null ? null : _mapper.Map<GetDTO>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString(), "GetApi" + apiName);
                throw;
            }
        }
    }
}
