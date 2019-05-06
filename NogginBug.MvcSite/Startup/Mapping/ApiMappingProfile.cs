using AutoMapper;
using NogginBug.Data.Model;
using NogginBug.MvcSite.Areas.Api.Dtos;
using System;

namespace NogginBug.MvcSite.Startup.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<BugDto, Bug>()
                //.ConstructUsing((s) => Bug.CloneFrom(s))
                //.ForAllOtherMembers(opt => opt.Ignore());
                .ForMember(d => d.IdExternal, opt => opt.MapFrom(s => new Guid(s.Id)))
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<Bug, BugDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdExternal));

            CreateMap<NogginBugUserDto, NogginBugUser>()
                .ForMember(d => d.IdExternal, opt => opt.MapFrom(s => new Guid(s.Id)))
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<NogginBugUser, NogginBugUserDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdExternal));
        }
    }
}