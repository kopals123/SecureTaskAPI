using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Interfaces;

namespace SecureTaskAPI.Service
{
    public class GetAllApis :IGetAllApis
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllApis> _logger;

        public GetAllApis(AppDbContext context , IMapper mapper, ILogger<GetAllApis> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetDTOList>> getAllApis()
        {
            try
            {
                var result = await _context.ApiModel.ToListAsync();

                if (result == null)
                    return null;

                _logger.LogInformation("GetAllApis" + DateTime.Now.ToString());

                return _mapper.Map<List<GetDTOList>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString(), "GetAllApi");

                throw;

            }
        }
    }
}
