using AutoMapper;
using SocialMedia.Core.Dtos;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>().ForMember(dest => dest.Updatetime, opt => opt.MapFrom(src => src.LastModified)).ReverseMap();
        }
    }
}
