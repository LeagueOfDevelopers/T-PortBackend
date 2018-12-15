using System;

namespace TPortApi.Models.AccountModels
{
    public class LoginResponse
    {
        public LoginResponse(string token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        public string Token { get; }
        
        //TODO : Решить что еще возвращать
    }
}