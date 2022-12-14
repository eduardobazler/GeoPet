namespace GeoPet.Utils;

public interface IJwtTokenManager
{
    string Authenticate(string email, string password);
}