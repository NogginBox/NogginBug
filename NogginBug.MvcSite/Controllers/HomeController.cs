using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NogginBug.Data;
using NogginBug.Data.Extensions;
using NogginBug.MvcSite.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NogginBug.MvcSite.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;

        public HomeController(IDataContext data, ILogger<HomeController> logger, IMapper mapper) : base(data)
        {
            _mapper = mapper;
        }

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

        [Route("bug-{id}")]
        public async Task<IActionResult> DetailPage(string id)
        {
            Guid.TryParse(id, out var guidId);
            if (guidId == null) return NotFound();
            var bug = await Data.Bugs.FirstOrDefaultAsync(b => b.IdExternal == guidId);
            if (bug == null) return NotFound();

            var model = new DetailPageViewModel($"Bug: {bug.Title}")
            {
                Bug = _mapper.Map<BugViewModel>(bug)
            };

            return View(model);
        }
        
    }

}