using System;
using Newtonsoft.Json;

namespace TPortApi.Models.AccountModels
{
    [JsonObject]
    public class LoginResponse
    {
        public LoginResponse(string token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }

        [JsonProperty("token")]
        public string Token { get; }
    }
}