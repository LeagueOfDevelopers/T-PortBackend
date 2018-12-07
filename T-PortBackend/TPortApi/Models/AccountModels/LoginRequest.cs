using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.AccountModels
{
    public class LoginRequest
    {
        [Required]
        [RegularExpression(@"^[\d\w\s-]+$")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}