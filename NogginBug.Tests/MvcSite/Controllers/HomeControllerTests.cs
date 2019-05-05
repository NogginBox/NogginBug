using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NogginBug.Data;
using NogginBug.Data.Model;
using NogginBug.MvcSite.Controllers;
using NogginBug.MvcSite.Startup.Mapping;
using NogginBug.MvcSite.ViewModels.Home;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NogginBug.Tests.MvcSite.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task IndexPageShowsOpenBugs()
        {
            // Arrange - DataContext
            var options = CreateInMemoryDbContextOptions("IndexPageShowsOpenBugs");
            // Insert seed data into the database using one instance of the context
            using (var context = new DataContext(options))
            {
                context.Bugs.Add(Bug.CreateNewOpenBug("Bug 1", "Description 1", DateTime.Now));
                context.Bugs.Add(Bug.CreateNewOpenBug("Bug 2", "Description 2", DateTime.Now));
                context.Bugs.Add(Bug.CreateNewOpenBug("Bug 3", "Description 3", DateTime.Now));
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new DataContext(options))
            {
                // Arrange
                var logger = Substitute.For<ILogger<HomeController>>();
                var config = CreateCigurationForProfile<ViewModelMappingProfile>();
                var mapper = config.CreateMapper();
                var controller = new HomeController(context, logger, mapper);

                // Act
                var result = await controller.IndexPage();
                var model = (result as ViewResult)?.Model as IndexPageViewModel;

                // Assert
                Assert.Equal(3, model.Bugs.Count);
 
            }
        }
        private DbContextOptions<DataContext> CreateInMemoryDbContextOptions(string dbDame)
        {
            return new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbDame)
                .Options;
        }

        private MapperConfiguration CreateCigurationForProfile<TProfile>() where TProfile : Profile, new()
        {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile<TProfile>();
            });
        }
    }
}