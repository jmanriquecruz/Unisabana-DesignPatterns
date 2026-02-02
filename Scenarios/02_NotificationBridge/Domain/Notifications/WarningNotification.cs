using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Abstractions;
using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Notifications
{

    public class WarningNotification : Notification
    {
        public WarningNotification(INotificationPlatform platform)
            : base(platform) { }

        public override void Send()
        {
            Platform.Show("Warning", "Existe una condición que requiere atención, pero no es crítica.");
        }
    }

}
