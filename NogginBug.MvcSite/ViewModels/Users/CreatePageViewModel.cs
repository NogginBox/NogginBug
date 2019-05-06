using NogginBug.MvcSite.ViewModels.Shared;

namespace NogginBug.MvcSite.ViewModels.Users
{
    public class CreatePageViewModel : BasePageViewModel
    {
        public CreatePageViewModel(string title) : base(title) { }

        public UserEditViewModel User { get; set; }
    }
}
