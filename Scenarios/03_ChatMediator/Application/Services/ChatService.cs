using DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Rooms;
using DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Users;
namespace DesignPatternsDemo.Scenarios._03_ChatMediator.Application.Services
{
    public class ChatService
    {
        private readonly IChatMediator _mediator;

        public ChatService(IChatMediator mediator)
        {
            _mediator = mediator;
        }

        public ChatUser AddUser(string name)
        {
            var user = new ChatUser(name, _mediator);
            _mediator.Register(user);
            return user;
        }

        public IReadOnlyList<ChatUser> GetUsers()
        {
            return _mediator.Users;
        }
    }
}
