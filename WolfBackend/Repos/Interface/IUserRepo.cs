using WolfGame.Model;

namespace WolfGame.IRepo;
public interface IUserRepo
{
    bool Register(UserModel registeruser);
    UserModel GetUserByAccount(string account);
}