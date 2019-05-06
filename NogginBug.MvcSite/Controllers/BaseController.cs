using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NogginBug.Data;
using NogginBug.MvcSite.Extensions;
using NogginBug.MvcSite.ViewModels.Shared;

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

        protected void ShowSuccessNotification(string message)
        {
            TempData.AddNotifcation(message, NotificationViewModel.NotificationType.Success);
        }
    }
}