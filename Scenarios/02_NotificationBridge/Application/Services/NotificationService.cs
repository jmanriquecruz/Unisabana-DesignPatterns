using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Abstractions;
using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;
using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Notifications;

namespace DesignPatternsDemo.Scenarios._02_NotificationBridge.Application.Services
{
    public class NotificationService
    {
        public void SendMessage(INotificationPlatform platform)
        {
            Notification notification = new MessageNotification(platform);
            notification.Send();
        }

        public void SendAlert(INotificationPlatform platform)
        {
            Notification notification = new AlertNotification(platform);
            notification.Send();
        }

        public void SendWarning(INotificationPlatform platform)
        {
            Notification notification = new WarningNotification(platform);
            notification.Send();
        }
    }
}
