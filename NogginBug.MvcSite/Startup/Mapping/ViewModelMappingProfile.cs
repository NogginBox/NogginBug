using AutoMapper;
using NogginBug.Data.Model;

namespace NogginBug.MvcSite.Startup.Mapping
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<Bug, ViewModels.Home.BugViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdExternal));

            CreateMap<Bug, ViewModels.Home.BugSummaryViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdExternal));
        }
    }
}