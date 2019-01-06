using System;
using System.Net.Http;
using TPort.Infrastructure.WorkingWithApi.Models;

namespace TPort.Infrastructure.WorkingWithApi
{
    public class AirTicketsApi
    {
        public AirTicketsApi(string apiToken, string apiUrl)
        {
            _apiToken = apiToken ?? throw new ArgumentNullException(nameof(apiToken));
            _apiUrl = apiUrl ?? throw new ArgumentNullException(nameof(apiUrl));
        }

        public ApiResponseModel GetAllAirTickets(string origin, string destination, string beginningOfPeriod,
            bool oneWay = true, int limit = 1000)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Access-Token", _apiToken);
            var response = client.GetAsync(
                $"{_apiUrl}?origin={origin}&destination={destination}" +
                $"&beginning_of_period={beginningOfPeriod}&one_way={oneWay}&limit={limit}&period_type=year");
                
            return response.Result.EnsureSuccessStatusCode().Content.ReadAsAsync<ApiResponseModel>().Result;
        }

        private readonly string _apiToken;
        private readonly string _apiUrl;
    }
}