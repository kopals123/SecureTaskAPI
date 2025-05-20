using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Interfaces;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Service
{
    public class GetAllApis :IGetAllApis
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllApis(AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetDTOList>> getAllApis()
        {
            try
            {
                var result = await _context.ApiModel.ToListAsync();

                if (result == null)
                    return null;

                return _mapper.Map<List<GetDTOList>>(result);
            }
            catch (Exception ex)
            {
                //Logging and clean up
                throw;

            }
        }
    }
}
