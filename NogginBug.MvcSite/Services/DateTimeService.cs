using System;
using NogginBug.MvcSite.Services.Interfaces;

namespace NogginBug.MvcSite.Services
{

    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
