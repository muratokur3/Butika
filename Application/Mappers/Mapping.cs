using Application.Models.DTOs.User;
using Application.Models.VMs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            CreateMap<AddBusinessDto, Business>()
                      .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                      .ForMember(dest => dest.SocialMediaLinks, opt => opt.MapFrom(src => src.SocialMediaLinks));

            CreateMap<TagDto, Tag>();
            CreateMap<SocialMediaLinksDto, SocialMediaLinks>();
            CreateMap<UserDto, User>();


            // Business to BusinessDto mapping
            CreateMap<Business, AddBusinessDto>().ReverseMap();
            CreateMap<Business, BusinessDto>().ReverseMap();
            CreateMap<Business, UpdateBusinessDto>().ReverseMap();
            CreateMap<Business, BusinessVm>().ReverseMap();
            CreateMap<Business, BusinessSummaryVm>().ReverseMap();
            CreateMap<Business, BusinessVm>();

            // User to UserDto mapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, UserVm>().ReverseMap();

            // Tag to TagDto mapping
            CreateMap<Tag, TagDto>().ReverseMap();

            // SocialMediaLinks mapping
            CreateMap<SocialMediaLinks, SocialMediaLinksVm>().ReverseMap();


        }
    }
}
