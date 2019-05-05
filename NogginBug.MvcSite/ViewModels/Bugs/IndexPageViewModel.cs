using NogginBug.MvcSite.ViewModels.Shared;
using System.Collections.Generic;

namespace NogginBug.MvcSite.ViewModels.Bugs
{
    public class IndexPageViewModel : BasePageViewModel
    {
        public IndexPageViewModel(string title) : base(title) {}

        public IList<BugSummaryViewModel> Bugs { get; set; }
    }
}
