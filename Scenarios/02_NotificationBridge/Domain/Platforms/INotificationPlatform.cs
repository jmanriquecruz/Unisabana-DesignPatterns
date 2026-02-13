using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations
{
    public interface INotificationPlatform
    {
        void Show(string title, string message);
    }
}
