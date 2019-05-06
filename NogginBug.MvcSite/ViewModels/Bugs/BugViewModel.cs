using NogginBug.MvcSite.ViewModels.Shared;
using System;

namespace NogginBug.MvcSite.ViewModels.Bugs
{
    public class BugViewModel : BugSummaryViewModel
    {
        public string Description { get; set; }

        public DateTime OpenedDate { get; set; }

        public NogginBugUserViewModel AssignedUser { get; set; }
    }
}