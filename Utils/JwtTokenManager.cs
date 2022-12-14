using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GeoPet.Data;
using Microsoft.IdentityModel.Tokens;

namespace GeoPet.Utils;

public class JwtTokenManager : IJwtTokenManager
{
    private readonly IConfiguration _configuration;
    private readonly IGeoPetRepository _geoPetRepository;
    
    public JwtTokenManager(IConfiguration configuration, IGeoPetRepository geoPetRepository)
    {
        _configuration = configuration;
        _geoPetRepository = geoPetRepository;
    }
    
    public string Authenticate(string email, string password)
    {
        //var hasUser = true; //_geoPetRepository.GetUserById();
        //if (hasUser is null) return null;
        
        var key = _configuration.GetValue<string>("JwtConfig:Key");
        var keyBytes = Encoding.ASCII.GetBytes(key);

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, email)
            }),
            SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}