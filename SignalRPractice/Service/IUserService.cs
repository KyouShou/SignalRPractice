using Microsoft.AspNetCore.Identity;

namespace SignalRPractice.Service
{
    public interface IUserService
    {
        UserInfo GetUser(string name, string password);
        //List<UserMessage> GetMessages();
    }
}
