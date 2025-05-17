using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Interfaces;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Service
{
    public class GetApi : IGetAPI
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public GetApi(AppDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApiModel?> GetAPI(string apiName)
        {

            try
            {
                return await _dbContext?.ApiModel.FirstOrDefaultAsync(x => x.ApiName == apiName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
