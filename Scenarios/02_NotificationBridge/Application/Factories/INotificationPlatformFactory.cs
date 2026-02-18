using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;

namespace DesignPatternsDemo.Scenarios._02_NotificationBridge.Application.Factories
{
    public interface INotificationPlatformFactory
    {
        INotificationPlatform Create(string option);
    }
}
