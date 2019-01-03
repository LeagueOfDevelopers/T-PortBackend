using System;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<ResponseModel> GetAllAirTickets(string origin, string destination, string beginningOfPeriod,
            bool oneWay = true, string limit = "1000")
        {
            _client.DefaultRequestHeaders.Add("X-Access-Token", _apiToken);
            var response = await _client.GetAsync(
                    $"{_apiUrl}?origin={origin}&destination={destination}" + 
                    $"&beginning_of_period={beginningOfPeriod}&one_way={oneWay}&period_type=month&limit={limit}");

            return response.EnsureSuccessStatusCode().Content.ReadAsAsync<ResponseModel>().Result;
        }

        private readonly string _apiToken;
        private readonly string _apiUrl;
        private readonly HttpClient _client = new HttpClient();
    }
}