using AutoMapper;
using MvcCoreCv.DTOs;
using MvcCoreCv.Entities;

namespace MvcCoreCv.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //SADECE 2 SINIF İÇİN MAPLEME YAPTIM.
            //Çift yönlü mapleme.
            CreateMap<TblAward,AwardDto>().ReverseMap();
            //CreateMap<TblAward,AwardDto>().ForMember(x=>x.Date,opt=>opt.MapFrom(y=>y.Description)).ReverseMap();
            CreateMap<TblAbout,AboutDto>().ReverseMap();
            CreateMap<TblEducation,EducationDto>().ReverseMap();
        }
    }
}
