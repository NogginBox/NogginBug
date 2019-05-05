using NogginBug.Data.Model;

namespace NogginBug.MvcSite.ViewModels.Home
{
    public class BugSummaryViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public BugStatus Status { get; set; }
    }
}