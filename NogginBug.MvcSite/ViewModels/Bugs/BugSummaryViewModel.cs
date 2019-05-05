using NogginBug.Data.Model;

namespace NogginBug.MvcSite.ViewModels.Bugs
{
    public class BugSummaryViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public BugStatus Status { get; set; }
    }
}