using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models
{
    public class RegisterUserRequest
    {
        [MaxLength(50)]
        [RegularExpression(@"^[\d\w\s-]+$")]
        public string FirstName { get; set; }
        
        [MaxLength(50)]
        [RegularExpression(@"^[\d\w\s-]+$")]
        public string LastName { get; set; }
        
        [EmailAddress]
        [RegularExpression(@"\b[a-z0-9.%-]+@[a-z0-9.-]+.[a-z]{2,4}\b")]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }
}