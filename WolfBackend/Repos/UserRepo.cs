using WolfGame.Context;
using WolfGame.IRepo;
using WolfGame.Model;

namespace WolfGame.Repo;
public class UserRepo : IUserRepo
{
    private readonly WolfGameDbContext _context;
    public UserRepo(WolfGameDbContext context)
    {
        _context = context;
    }
    public bool Register(UserModel registeruser)
    {
        try
        {
            _context.User.Add(registeruser);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    public UserModel GetUserByAccount(string account)
    {
        return _context.User.SingleOrDefault(x => x.Account == account)!;
    }
}