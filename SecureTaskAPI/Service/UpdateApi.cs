using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Interfaces;

namespace SecureTaskAPI.Service
{
    public class UpdateApi : IUpdateApi
    {
        private readonly AppDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateApi> _logger;
        public UpdateApi(AppDbContext dbContext , IMapper mapper, ILogger<UpdateApi> logger)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> UpdateApiAsync(UpdateDTO updateDTO)
        {
            try
            {

                var result = await _dbcontext.ApiModel.FirstOrDefaultAsync(x => x.ApiName.ToLower() == updateDTO.ApiName.ToLower());

                if (result == null)
                {
                    return "API Doesn't Exists";
                }

                _mapper.Map(updateDTO, result);
                _dbcontext.Update(result);
                await _dbcontext.SaveChangesAsync();

                _logger.LogInformation("UpdateApi" + DateTime.Now.ToString() + updateDTO.ApiName);

                return "Succesfully Update API";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString(), "UpdateApi");
                throw;
            }
        }

    }
}
