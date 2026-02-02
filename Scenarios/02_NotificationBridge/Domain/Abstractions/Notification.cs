using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Abstractions
{
    public abstract class Notification
    {
        protected readonly INotificationPlatform Platform;

        protected Notification(INotificationPlatform platform)
        {
            Platform = platform;
        }

        public abstract void Send();
    }
}
