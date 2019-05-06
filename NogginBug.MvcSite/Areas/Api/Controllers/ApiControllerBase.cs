using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NogginBug.Data;

namespace NogginBug.MvcSite.Areas.Api.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IDataContext Data;
        protected readonly ILogger Logger;

        public ApiControllerBase(IDataContext data, Microsoft.Extensions.Logging.ILogger<BugsApiController> logger)
        {
            Data = data;
            Logger = logger;
        }
    }
}