using AutoMapper;
using Lottery.Api.Models;
using Lottery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.Api.Profiles
{
    public class CreateCampaignResponseProfile : Profile
    {
        public CreateCampaignResponseProfile()
        {
            CreateMap<Campaign, CreateCampaignResponse>()
                .ForMember(dest => dest.Id, m => m.MapFrom(x => x.Id))
                .ForMember(dest => dest.Name, m => m.MapFrom(x => x.Name))
                .ForMember(dest => dest.StartDate, m => m.MapFrom(x => x.Period.StartDate))
                .ForMember(dest => dest.EndDate, m => m.MapFrom(x => x.Period.EndDate))
                .ForMember(dest => dest.Description, m => m.MapFrom(x => x.Description));
        }
    }
}
