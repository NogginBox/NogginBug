using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NogginBug.Data;

namespace NogginBug.MvcSite.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IDataContext Data;
        protected readonly ILogger Logger;

        public BaseController(IDataContext data, ILogger logger)
        {
            Data = data;
            Logger = logger;
        }
    }
}