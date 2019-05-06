using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NogginBug.Data;
using NogginBug.Data.Extensions;
using NogginBug.Data.Model;
using NogginBug.MvcSite.Services.Interfaces;
using NogginBug.MvcSite.ViewModels.Bugs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NogginBug.MvcSite.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class BugsController : BaseController
    {
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper _mapper;

        public BugsController(IDataContext data, IDateTimeService dateTimeService, ILogger<BugsController> logger, IMapper mapper) : base(data, logger)
        {
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> IndexPage()
        {
            var bugs = await Data.Bugs
                    .WhereOpen()
                    .ToListAsync();

            var model = new IndexPageViewModel("Home")
            {
                Bugs = _mapper.Map<List<BugSummaryViewModel>>(bugs)
            };

            return View(model);
        }

        [HttpGet("bug-{id}")]
        public async Task<IActionResult> DetailPage(string id)
        {
            Guid.TryParse(id, out var guidId);
            if (guidId == null) return NotFound();
            var bug = await Data.Bugs
                .Include(b => b.AssignedUser)
                .FirstOrDefaultAsync(b => b.IdExternal == guidId);
            if (bug == null) return NotFound();

            var allUsers = await Data.Users
                .OrderBy(u => u.Name)
                .ToListAsync();
            var availableUsersList = new SelectList(allUsers, "IdExternal", "Name");

            var model = new DetailPageViewModel($"Bug: {bug.Title}")
            {
                AvailableUsers = availableUsersList,
                Bug = _mapper.Map<BugViewModel>(bug)
            };

            return View(model);
        }

        [HttpGet("create")]
        public IActionResult CreatePage()
        {
            var model = new CreatePageViewModel($"Bug: Create new")
            {
                Bug = new BugEditViewModel()
            };

            return View(model);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePage(BugEditViewModel bug)
        {
            if(!ModelState.IsValid)
            {
                var model = new CreatePageViewModel($"Bug: Create new") { Bug = bug };

                ShowErrorNotification("Please check the details and try again");
                return View(model);
            }

            try
            {
                var newBug = Bug.CreateNewOpenBug(bug.Title, bug.Description, _dateTimeService.Now);
                Data.Bugs.Add(newBug);
                await Data.SaveChangesAsync();

                ShowSuccessNotification("New bug saved");
                return RedirectToAction("DetailPage", new { id = newBug.IdExternal });
            }
            catch(Exception ex)
            {
                Logger.LogError(ex, "Could not save new bug");
                var model = new CreatePageViewModel($"Bug: Create new") { Bug = bug };

                ShowErrorNotification("An error stopped this bug being created");
                return View(model);
            }
        }
    }

}