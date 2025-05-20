using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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

        public AddApi(IMapper mapper , AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbcontext = dbContext;
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

                return "Successfully Added to DB";
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
