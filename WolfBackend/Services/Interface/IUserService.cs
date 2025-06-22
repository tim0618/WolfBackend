using WolfGame.Request;
using WolfGame.Response;

namespace WolfGame.IService;
public interface IUserService
{
    bool Register(RegisterRequest registerRequest);
    LoginResponse Login(LoginRequest loginRequest);
}