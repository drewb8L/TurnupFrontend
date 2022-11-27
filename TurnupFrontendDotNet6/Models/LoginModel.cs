namespace TurnupFrontendDotNet6.Models;

public class LoginModel
{
    public LoginModel(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public string Email { get; set; }
    public string Password { get; set; }
}