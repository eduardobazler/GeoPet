using System.ComponentModel.DataAnnotations;

namespace GeoPet.Controllers.TypesReq;

public class AuthUser
{
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}