using Microsoft.AspNetCore.Mvc.Rendering;
using NogginBug.MvcSite.ViewModels.Shared;

namespace NogginBug.MvcSite.ViewModels.Bugs
{
    public class DetailPageViewModel : BasePageViewModel
    {
        public DetailPageViewModel(string title) : base(title) { }

        public BugViewModel Bug { get; set; }

        public SelectList AvailableUsers { get; set; }
    }
}