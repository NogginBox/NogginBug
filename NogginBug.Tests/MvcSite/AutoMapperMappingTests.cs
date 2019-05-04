using AutoFixture;
using AutoMapper;
using NogginBug.Data.Model;
using NogginBug.MvcSite.Areas.Api.Dtos;
using NogginBug.MvcSite.Startup.Mapping;
using System;
using Xunit;

namespace NogginBug.Tests.MvcSite
{
    public class AutoMapperMappingTests
    {
        [Fact]
        public void ApiMappingProfileTest()
        {
            var config = CreateCigurationForProfile<ApiMappingProfile>();
            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void CanMapBugDtoToBug()
        {
            // Arrange
            var config = CreateCigurationForProfile<ApiMappingProfile>();
            var mapper = config.CreateMapper();
            var fixture = new Fixture();
            var bugDto = fixture.Build<BugDto>()
                .With(d => d.Id, Guid.NewGuid().ToString())
                .Create();

            // Act
            var bug = mapper.Map<Bug>(bugDto);

            // Assert
            Assert.Equal(0, bug.Id);
            Assert.Equal(bugDto.Id, bug.IdExternal.ToString());

            // Assert - private setters were set
            Assert.Equal(bugDto.OpenedDate, bug.OpenedDate);
            Assert.Equal(bugDto.Status, bug.Status);
        }

        private MapperConfiguration CreateCigurationForProfile<TProfile>() where TProfile : Profile, new()
        {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile<TProfile>();
            });
        }
    }
}
