using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Abstractions.DTOs
{
    public class LoginDto
    {
        [Required] public string UserName { get; set; }
        [Required] public string Password { get; set; }
    }

    public class RegisterDto
    {
        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
    }

    public class UserDataDto
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class AuthorizedUserDto
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> Roles { get; set; } = new();
    }

    public class AuthDto
    {
        public AuthorizedUserDto User { get; set; }

        public string AccessToken { get; set; }
    }
}