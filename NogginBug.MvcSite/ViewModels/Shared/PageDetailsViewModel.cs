using Microsoft.AspNetCore.Html;

namespace NogginBug.MvcSite.ViewModels.Shared
{
    public class PageDetailsViewModel
    {
        public void SetTitle(string pageTitle, string siteTitle)
        {
            Title = new HtmlString($"{pageTitle} &ndash; {siteTitle}");
        }

        public HtmlString Title { get; private set; }
    }
}