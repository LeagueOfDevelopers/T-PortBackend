using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.AccountModels
{
    public class LoginConfirmationRequest
    {
        [Required]
        [RegularExpression(@"^\+[1-9][1-9]?[1-9]?\d{3}\d{3}\d{4}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        
        [Required]
        public int Code { get; set; }
    }
}