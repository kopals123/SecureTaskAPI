using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Data;
using SecureTaskAPI.Interfaces;

namespace SecureTaskAPI.Service
{
    public class DeleteApi : IDeleteApi
    {
        private readonly AppDbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteApi> _logger;
        public DeleteApi(AppDbContext context, IMapper mapper, ILogger<DeleteApi> logger)
        {
            _dbcontext = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> DeleteApiByName(string name)
        {
            try
            {
                var result = await _dbcontext.ApiModel.FirstOrDefaultAsync(x => x.ApiName.ToLower() == name.ToLower());

                if (result == null)
                {
                    return "Api Doesnt exists";
                }

                _dbcontext.ApiModel.Remove(result);

                await _dbcontext.SaveChangesAsync();

                _logger.LogInformation("API Deleted Succesfully at " + DateTime.Now.ToString() + name);

                return "Succesfully Delete Api";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString(), "DeleteAPI" + name);
                throw;
            }
        }

    }
}
