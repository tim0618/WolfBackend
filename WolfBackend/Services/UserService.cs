using WolfGame.IService;
using WolfGame.IRepo;
using WolfGame.Model;
using WolfGame.Request;
using System.Security.Cryptography;
using System.Text;
using WolfGame.Response;

namespace WolfGame.Service;
public class UserService : IUserService
{
    private readonly IUserRepo _userRepo;
    public UserService(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }
    public bool Register(RegisterRequest registerRequest)
    {
        var registerUser = new UserModel
        {
            Account = registerRequest.Account,
            Password = SaltPassword(registerRequest.Password),
            Name = registerRequest.Name
        };
        return _userRepo.Register(registerUser);
    }
    public LoginResponse Login(LoginRequest loginRequest)
    {
        var userData = _userRepo.GetUserByAccount(loginRequest.Account);
        if (userData != null)
        {
            if (SaltPassword(loginRequest.Password).Equals(userData.Password))
            {
                return new LoginResponse
                {
                    Account = userData.Account,
                    Name = userData.Name,
                };
            }
        }
        return null!;
    }
    private string SaltPassword(string password)
    {
        var hash = SHA256.Create();
        var byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(byteArray).ToLower();
    }
}