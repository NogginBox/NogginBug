using NogginBug.MvcSite.ViewModels.Shared;

namespace NogginBug.MvcSite.ViewModels.Bugs
{
    public class CreatePageViewModel : BasePageViewModel
    {
        public CreatePageViewModel(string title) : base(title) { }

        public BugEditViewModel Bug { get; set; }
    }
}
