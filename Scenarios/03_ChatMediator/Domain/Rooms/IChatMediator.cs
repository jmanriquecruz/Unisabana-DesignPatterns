using DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Users;

namespace DesignPatternsDemo.Scenarios._03_ChatMediator.Domain.Rooms
{
    public interface IChatMediator
    {
        void Register(ChatUser user);
        void Send(string message, ChatUser sender);
        IReadOnlyList<ChatUser> Users { get; }
    }
}
