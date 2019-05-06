using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using NogginBug.MvcSite.ViewModels.Shared;

namespace NogginBug.MvcSite.Extensions
{
    public static class TempDataExtensions
    {
        /// <summary>
        /// Puts an object in TempData using Json serialisation
        /// </summary>
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// Gets an object from TempData using Json serialisation
        /// </summary>
        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out object o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }

        private const string NotificationToShowKey = "NOTIFCATION";

        public static void AddNotifcation(this ITempDataDictionary tempData, string message, NotificationViewModel.NotificationType type = NotificationViewModel.NotificationType.Info)
        {
            var notificationToShow = new NotificationViewModel(type, message);
            tempData.Put(NotificationToShowKey, notificationToShow);
        }

        public static NotificationViewModel GetNotification(this ITempDataDictionary tempData)
        {
            return tempData.Get<NotificationViewModel>(NotificationToShowKey);
        }
    }
}
