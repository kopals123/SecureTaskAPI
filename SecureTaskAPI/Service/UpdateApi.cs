using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Interfaces;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Service
{
    public class UpdateApi : IUpdateApi
    {
        private readonly AppDbContext _dbcontext;
        private readonly IMapper _mapper;
        public UpdateApi(AppDbContext dbContext , IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public async Task<string> UpdateApiAsync(UpdateDTO updateDTO)
        {
            var result = await _dbcontext.ApiModel.FirstOrDefaultAsync(x => x.ApiName.ToLower() == updateDTO.ApiName.ToLower());

            if (result == null)
            {
                return "API Doesn't Exists";
            }

            _mapper.Map(updateDTO, result);
            _dbcontext.Update(result);
            await _dbcontext.SaveChangesAsync();

            return "Succesfully Update API";
        }

    }
}
