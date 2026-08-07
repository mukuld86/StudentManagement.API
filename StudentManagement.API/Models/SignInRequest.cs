using System.ComponentModel.DataAnnotations;

namespace StudentManagement.API.Models
{
    public class SignInRequest
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
