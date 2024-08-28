using Consumer.Interfaces;
using Consumer.ViewModels;
using Newtonsoft.Json;
using RestSharp;

namespace Consumer
{
    public class YahooFinanceIntegration : IYahooFinanceIntegration
    {
        public async Task<RootChart?> GetChart(string symbol, string interval, string range)
        {
            var options = new RestClientOptions();
            var client = new RestClient(options);
            var request = new RestRequest($"https://query1.finance.yahoo.com/v8/finance/chart/{symbol}?metrics=high?&interval={interval}&range={range}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
            {
                var ret = JsonConvert.DeserializeObject<RootChart>(response.Content);
                return ret;
            }
            else
            {
                return null;
            }
        }
    }
}
