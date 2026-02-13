using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;
using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Platforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._02_NotificationBridge.Application.Factories
{
    public class NotificationPlatformFactory : INotificationPlatformFactory
    {
        public INotificationPlatform Create(string option)
        {
            return option switch
            {
                "1" => new WebPlatform(),
                "2" => new MobilePlatform(),
                "3" => new DesktopPlatform(),
                _ => throw new ArgumentException("Plataforma inválida")
            };
        }
    }
}
