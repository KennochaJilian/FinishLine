using FinishLine.Models;

namespace FinishLine.Services.Models.Auth;

public class TokenModel
{
    public AppUser User { get; set; }
    public string Token { get; set; }
}