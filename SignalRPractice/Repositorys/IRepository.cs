using SignalRPractice.Service;

namespace SignalRPractice.Repositorys
{
    public interface IRepository
    {
        public UserInfo QueryUserInfo(string name);
    }
}
