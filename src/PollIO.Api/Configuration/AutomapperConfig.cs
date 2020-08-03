using AutoMapper;
using PollIO.Api.ViewModels;

namespace PollIO.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Business.Models.Poll, PollDto>().ReverseMap();
            CreateMap<Business.Models.OptionsPoll, OptionPollDto>().ReverseMap();
        }
    }
}
