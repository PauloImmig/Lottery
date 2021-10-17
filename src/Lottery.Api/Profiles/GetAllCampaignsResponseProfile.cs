using AutoMapper;
using Lottery.Api.Models;
using Lottery.Domain.Entities;

namespace Lottery.Api.Profiles
{
    public class GetAllCampaignsResponseProfile : Profile
    {
        public GetAllCampaignsResponseProfile()
        {
            CreateMap<Campaign, GetAllCampaignsResponse>()
                .ForMember(dest => dest.Id, m => m.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, m => m.MapFrom(x => x.Name))
                .ForMember(dest => dest.StartDate, m => m.MapFrom(x => x.Period.StartDate))
                .ForMember(dest => dest.EndDate, m => m.MapFrom(x => x.Period.EndDate))
                .ForMember(dest => dest.Description, m => m.MapFrom(x => x.Description))
                .ForMember(dest => dest.Active, m => m.MapFrom(x => x.Active))
                .ForMember(dest => dest.EmailContent, m => m.MapFrom(x => x.EmailTemplate.Content))
                .ForMember(dest => dest.EmailPlaceholders, m => m.MapFrom(x => x.EmailTemplate.Placeholders.Value))
                .ForMember(dest => dest.EmailSubject, m => m.MapFrom(x => x.EmailTemplate.Subject))
                .ReverseMap();
        }
    }
}