using Application.Models.DTOs.Branch;
using Application.Models.DTOs.Business;
using Application.Models.DTOs.Campaign;
using Application.Models.DTOs.Category;
using Application.Models.DTOs.Certification;
using Application.Models.DTOs.Contact;
using Application.Models.DTOs.HighlightFeature;
using Application.Models.DTOs.MarketingChannel;
using Application.Models.DTOs.Marketplace;
using Application.Models.DTOs.ShippingCompany;
using Application.Models.DTOs.Tag;
using Application.Models.VMs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            

            // Business mapping
            CreateMap<Business, BusinessDTO>().ReverseMap();
            CreateMap<Business, RegisterBusinessDTO>().ReverseMap();
            CreateMap<Business, BusinessBasicInfoDTO>().ReverseMap();

            CreateMap<Business, BusinessVM>().ReverseMap();
            CreateMap<Business, BusinessSummaryVM>().ReverseMap();
            CreateMap<Business, BusinessDetailVM>().ReverseMap();

            //Tag
            CreateMap<BusinessTag, BusinessTagDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();

            //Contact
            CreateMap<BusinessContact, ContactDTO>().ReverseMap();

            //Branch
            CreateMap<Branch, BranchDTO>().ReverseMap();

            //Campaign
            CreateMap<Campaign, CampaignDTO>().ReverseMap();

            //Category
            CreateMap<Category, CategoryDTO>().ReverseMap();

            //Certification
            CreateMap<SpecialCertification, CertificationDTO>().ReverseMap();

            //HighlightFeature
            CreateMap<HighlightFeature, HighlightFeatureDTO>().ReverseMap();

            //MarketingChannel
            CreateMap<MarketingChannel, MarketingChannelDTO>().ReverseMap();

            //MarketPlace
            CreateMap<Marketplace, MarketplaceDTO>().ReverseMap();

            //ShippingCompany
            CreateMap<ShippingCompany, ShippingCompanyDTO>().ReverseMap();
        }
    }
}
