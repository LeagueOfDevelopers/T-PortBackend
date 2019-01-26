using System;
using System.ComponentModel.DataAnnotations;

namespace TPortApi.Models.AccountModels
{
    public class BankCardModel
    {
        [Required]
        public string CardNumber { get; set; } //TODO Составить регулярку для валидации номера карты
        
        [Required]
        public DateTime Validity { get; set; }
    }
}