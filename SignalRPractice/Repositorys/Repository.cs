using SignalRPractice.Service;

namespace SignalRPractice.Repositorys
{
    public class Repository : IRepository
    {
        public UserInfo QueryUserInfo(string name)
        {
            if (name == "jing")
            {
                return new UserInfo()
                {
                    ID = "0",
                    Name = "jing",
                    Password = "111"
                };
            }
            else if (name == "admin")
            {
                return new UserInfo()
                {
                    ID = "0",
                    Name = "admin",
                    Password = "111"
                };
            }
            else if (name == "guest")
            {
                return new UserInfo()
                {
                    ID = "0",
                    Name = "guest",
                    Password = "111"
                };
            }           
            else
            {
                return null;
            }
        }
    }
}
