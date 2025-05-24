using AutoMapper;
using SecureTaskAPI.Data;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SecureTaskAPI.Service
{
    public class DeleteApi : IDeleteApi
    {
        private readonly AppDbContext _dbcontext;
        private readonly IMapper _mapper;

        public DeleteApi(AppDbContext context, IMapper mapper)
        {
            _dbcontext = context;
            _mapper = mapper;
        }
        public async Task<string> DeleteApiByName(string name)
        {
            var result = await _dbcontext.ApiModel.FirstOrDefaultAsync(x => x.ApiName.ToLower() == name.ToLower());

            if (result == null)
            {
                return "Api Doesnt exists";
            }

            _dbcontext.ApiModel.Remove(result);

            await _dbcontext.SaveChangesAsync();

            return "Succesfully Delete Api";
        }

    }
}
