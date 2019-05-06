using AutoMapper;
using NogginBug.Data.Model;

namespace NogginBug.MvcSite.Startup.Mapping
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<Bug, ViewModels.Bugs.BugViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdExternal));

            CreateMap<Bug, ViewModels.Bugs.BugSummaryViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdExternal));

            CreateMap<NogginBugUser, ViewModels.Shared.NogginBugUserViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdExternal));
        }
    }
}