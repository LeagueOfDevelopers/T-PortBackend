using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.AccountModels
{
    public class LoginConfirmationRequest //TODO Подумать над названиями
    {
        [Required]
        [RegularExpression(@"^\+[1-9][1-9]?[1-9]?[- ]?\(?\d{3}\)?[- ]?\d{3}[- ]?\d{2}[- ]?\d{2}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        
        [Required]
        public string Code { get; set; }
    }
}