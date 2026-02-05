using DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Mediators
{
    public interface IChatMediator
    {
        void Register(ChatUser user);
        void Send(string message, ChatUser sender);
        IReadOnlyList<ChatUser> Users { get; }
    }
}
