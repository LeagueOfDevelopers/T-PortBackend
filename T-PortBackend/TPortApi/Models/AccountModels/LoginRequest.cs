using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TPortApi.Models.AccountModels
{
    [JsonObject]
    public class LoginRequest
    {
        [Required]
        [JsonProperty("phone")]
        [RegularExpression(@"^\+[1-9][1-9]?[1-9]?[ ]?[(]?\d{3}[)]?[ ]?\d{3}[ ]?\d{2}[ ]?\d{2}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }
    }
}