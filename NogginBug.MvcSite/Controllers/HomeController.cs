using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NogginBug.Data;
using NogginBug.Data.Extensions;
using NogginBug.MvcSite.ViewModels.Home;
using System.Collections.Generic;
using System.Linq;

namespace NogginBug.MvcSite.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;

        public HomeController(IDataContext data, ILogger<HomeController> logger, IMapper mapper) : base(data)
        {
            _mapper = mapper;
        }

        public IActionResult IndexPage()
        {
            var bugs = Data.Bugs
                    .WhereOpen()
                    .ToList();

            var model = new IndexPageViewModel("Home")
            {
                Bugs = _mapper.Map<List<BugViewModel>>(bugs)
            };

            return View(model);
        }
        
    }

}