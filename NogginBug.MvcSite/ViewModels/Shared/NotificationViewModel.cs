namespace NogginBug.MvcSite.ViewModels.Shared
{
    public class NotificationViewModel
    {
        public NotificationViewModel(NotificationType type, string message)
        {
            Message = message;
            Type = type;

            switch(Type)
            {
                case NotificationType.Info: CssClass = "alert-info"; break;
                case NotificationType.Warning: CssClass = "alert-warning"; break;
                case NotificationType.Error: CssClass = "alert-danger"; break;
                case NotificationType.Success: CssClass = "alert-success"; break;
            }
        }

        public readonly string Message;

        public readonly NotificationType Type;

        public readonly string CssClass;

        public enum NotificationType
        {
            Info, Warning, Error, Success
        }
    }
}
