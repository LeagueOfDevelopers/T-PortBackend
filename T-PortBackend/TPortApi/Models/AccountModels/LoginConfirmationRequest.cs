using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.AccountModels
{
    public class LoginConfirmationRequest
    {
        [Required]
        [RegularExpression(@"^\+[2-9]\d{3}-\d{3}-\d{4}$")]
        public string Phone { get; set; }
        
        [Required]
        public int Code { get; set; }
    }
}