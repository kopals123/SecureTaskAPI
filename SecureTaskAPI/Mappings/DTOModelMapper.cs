using AutoMapper;
using SecureTaskAPI.DTOs;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Mappings
{
    public class DTOModelMapper : Profile
    {
        public DTOModelMapper() 
        {
            CreateMap<POSTDto ,ApiModel>().ForMember(dest => dest.CreatedAt , opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdateDTO, ApiModel>();

            CreateMap<ApiModel, UpdateDTO>();

            CreateMap<GetDTO, ApiModel>();

            CreateMap<ApiModel , POSTDto>();

            CreateMap<ApiModel, GetDTO>();

            CreateMap<GetDTOList, ApiModel>();

            CreateMap<ApiModel, GetDTOList>();

        }
    }
}
