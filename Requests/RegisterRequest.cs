namespace WolfGame.Request;

public class RegisterRequest
{
    public string Account { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
}