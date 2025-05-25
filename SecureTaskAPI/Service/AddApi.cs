using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Interfaces;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Service
{
    public class AddApi : IAddAPI
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbcontext;
        private readonly ILogger<AddApi> _logger;

        public AddApi(IMapper mapper , AppDbContext dbContext, ILogger<AddApi> logger)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
            _logger = logger;
        }

        public async Task<string> AddAPI(POSTDto dto)
        {
            try
            {
                var ifexists = await _dbcontext.ApiModel.AnyAsync(x => x.ApiName.ToLower() == dto.ApiName.ToLower());

                if (ifexists)
                {
                    return "API Already Exists";
                }

                var result = _mapper.Map<ApiModel>(dto);
                result.CreatedAt = DateTime.Now;

                await _dbcontext.ApiModel.AddAsync(result);
                await _dbcontext.SaveChangesAsync();
                _logger.LogInformation("API Added Succesfully at " + DateTime.Now.ToString() + dto.ApiName);

                return "Successfully Added to DB";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString(), "AddAPI" + dto);
                throw;
            }

        }
    }
}
