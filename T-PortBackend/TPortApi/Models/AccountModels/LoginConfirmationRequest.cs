using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TPortApi.Models.AccountModels
{
    [JsonObject]
    public class LoginConfirmationRequest
    {
        [Required]
        [JsonProperty("phone")]
        [RegularExpression(@"^\+[1-9][1-9]?[1-9]?\d{3}\d{3}\d{4}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
        
        [Required]
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}