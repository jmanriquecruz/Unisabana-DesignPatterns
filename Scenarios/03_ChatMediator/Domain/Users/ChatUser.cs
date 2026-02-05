using DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Mediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Users
{
    public class ChatUser
    {
        public string Name { get; }
        private readonly IChatMediator _mediator;

        public ChatUser(string name, IChatMediator mediator)
        {
            Name = name;
            _mediator = mediator;
        }

        public void Send(string message)
        {
            _mediator.Send(message, this);
        }

        public void Receive(string message, string from)
        {
            Console.WriteLine($"[{Name}] mensaje de {from}: {message}");
        }
    }
}
