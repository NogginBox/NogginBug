using NogginBug.MvcSite.ViewModels.Shared;
using System.Collections.Generic;

namespace NogginBug.MvcSite.ViewModels.Users
{
    public class IndexPageViewModel : BasePageViewModel
    {
        public IndexPageViewModel(string title) : base(title) {}

        public IList<NogginBugUserViewModel> Users { get; set; }
    }
}