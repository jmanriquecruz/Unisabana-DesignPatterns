using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Abstractions;
using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Notifications
{
    public class AlertNotification : Notification
    {
        public AlertNotification(INotificationPlatform platform)
            : base(platform) { }

        public override void Send()
        {
            Platform.Show("Alerta", "Algo requiere tu atención inmediata");
        }
    }
}
