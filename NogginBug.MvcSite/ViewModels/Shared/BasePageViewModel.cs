namespace NogginBug.MvcSite.ViewModels.Shared
{
    /// <summary>
    /// All main page view models should inherit from this.
    /// It is used by the main layout to display things common to all pages
    /// </summary>
    public abstract class BasePageViewModel
    {
        public BasePageViewModel(string title)
        {
            Page = new PageDetailsViewModel();
            Page.SetTitle(title, "NogginBug");
        }

        public PageDetailsViewModel Page { get; set; }
    }
}