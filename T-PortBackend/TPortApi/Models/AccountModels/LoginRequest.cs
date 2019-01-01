using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.AccountModels
{
    public class LoginRequest
    {
        [Required]
        [RegularExpression(@"^\+[2-9]\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }
    }
}