using NogginBug.Data.Model;
using System;

namespace NogginBug.MvcSite.Areas.Api.Dtos
{
    public class BugDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public DateTime OpenedDate { get; set; }
    }
}
