using DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Mediators
{
    public class ChatRoom : IChatMediator
    {
        private readonly List<ChatUser> _users = new();

        public IReadOnlyList<ChatUser> Users => _users;

        public void Register(ChatUser user)
        {
            if (!_users.Contains(user))
                _users.Add(user);
        }

        public void Send(string message, ChatUser sender)
        {
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.Receive(message, sender.Name);
                }
            }
        }
    }
}
