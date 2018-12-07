using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.AccountModels
{
    public class RegisterUserRequest
    {
        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[\d\w\s-]+$")]
        public string FirstName { get; set; }
        
        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[\d\w\s-]+$")]
        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        [RegularExpression(@"\b[a-z0-9.%-]+@[a-z0-9.-]+.[a-z]{2,4}\b")]
        public string Email { get; set; }
        
        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}