using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Platforms
{
    public class MobilePlatform : INotificationPlatform
    {
        public void Show(string title, string message)
        {
            Console.WriteLine($"[MÓVIL] {title}: {message}");
        }
    }
}
