using Application.Models.DTOs;
using Application.Models.VMs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            CreateMap<Business, BusinessVm>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => string.Join(", ", src.Tags.Select(t => t.Name))));

            // Business to BusinessDto mapping
            CreateMap<Business, BusinessDto>().ReverseMap();
            CreateMap<Business, BusinessVm>().ReverseMap();
            CreateMap<CreateBusinessVm, Business>();

            // User to UserDto mapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserVm>().ReverseMap();

            // Tag to TagDto mapping
            CreateMap<Tag, TagDto>().ReverseMap();

            // SocialMediaLinks mapping
            CreateMap<SocialMediaLinks, SocialMediaLinksVm>().ReverseMap();


        }
    }
}
