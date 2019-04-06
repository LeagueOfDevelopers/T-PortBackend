using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TPortApi.Models.AccountModels
{
    [JsonObject]
    public class BankCardModel
    {
        [Required]
        [JsonProperty("cardNumber")]
        [RegularExpression("^[0-9]{15}(?:[0-9]{1})?$")]
        public string CardNumber { get; set; }
        
        [Required]
        [JsonProperty("validity")]
        public DateTime Validity { get; set; }
    }
}