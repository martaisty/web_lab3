namespace Abstractions.DTOs
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class UserDataDto
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}