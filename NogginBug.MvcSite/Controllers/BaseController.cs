using Microsoft.AspNetCore.Mvc;
using NogginBug.Data;

namespace NogginBug.MvcSite.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IDataContext Data;

        public BaseController(IDataContext data)
        {
            Data = data;
        }
    }

}