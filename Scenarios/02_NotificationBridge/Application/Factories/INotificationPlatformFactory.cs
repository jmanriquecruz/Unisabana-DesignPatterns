using DesignPatternsDemo.Scenarios._02_NotificationBridge.Domain.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._02_NotificationBridge.Application.Factories
{
    public interface INotificationPlatformFactory
    {
        INotificationPlatform Create(string option);
    }
}
