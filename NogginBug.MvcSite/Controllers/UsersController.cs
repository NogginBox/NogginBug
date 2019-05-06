using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NogginBug.Data;
using NogginBug.Data.Model;
using NogginBug.MvcSite.ViewModels.Shared;
using NogginBug.MvcSite.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NogginBug.MvcSite.Controllers
{
    [Route("users")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;

        public UsersController(IDataContext data, ILogger<BugsController> logger, IMapper mapper) : base(data, logger)
        {
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> IndexPage()
        {
            var users = await Data.Users
                .OrderBy(u => u.Name)
                .ToListAsync();

            var model = new IndexPageViewModel("Users")
            {
                Users = _mapper.Map<List<NogginBugUserViewModel>>(users)
            };

            return View(model);
        }

        [HttpGet("create")]
        public IActionResult CreatePage()
        {
            var model = new CreatePageViewModel($"User: Create new")
            {
                User = new UserEditViewModel()
            };

            return View(model);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePage(UserEditViewModel user)
        {
            ViewResult ErrorView(string notificationMessage)
            {
                ShowErrorNotification(notificationMessage);
                var model = new CreatePageViewModel($"User: Create new") { User = user };
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return ErrorView("Please check the details and try again");
            }

            var userExists = await Data.Users.AnyAsync(u => u.Name == user.Name);
            if (userExists)
            {
                return ErrorView("A user with that name already exists");
            }

            try
            {
                var newUser = NogginBugUser.CreateNewUser(user.Name);
                Data.Users.Add(newUser);
                await Data.SaveChangesAsync();

                ShowSuccessNotification("New user saved");
                return RedirectToAction("IndexPage");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Could not save new user");
                return ErrorView("An error stopped this user being created");
            }
        }
    }

}