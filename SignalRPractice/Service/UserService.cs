using SignalRPractice.Repositorys;

namespace SignalRPractice.Service
{
    public class UserService : IUserService
    {
        IRepository _repository;

        public UserService()
        {
            _repository = new Repository();
        }

        public UserService(IRepository repository)
        {
            _repository = repository;
        }


        public UserInfo GetUser(string name, string password)
        {
            UserInfo userInfo = _repository.QueryUserInfo(name);
            if (userInfo == null)
            {
                return new UserInfo();
            }
            else if (userInfo.Password != password)
            {
                return new UserInfo();
            }
            return userInfo;
        }
    }
}
