using Consumer.Interfaces;
using Services.DTO;
using Services.Enums;
using Services.Interfaces;
using Services.Utilities;

namespace Services.Services
{
    public class YahooFinanceService : IYahooFinanceService
    {
        private readonly IYahooFinanceIntegration _yahooFinanceIntegration;

        public YahooFinanceService(
            IYahooFinanceIntegration yahooFinanceIntegration
            )
        {
            _yahooFinanceIntegration = yahooFinanceIntegration;
        }

        public async Task<bool> GetChartAndSave(List<string> tickers, string filename)
        {
            var tasks = new List<Task>();
            var records = new Dictionary<string, ChartDTO>();

            foreach (var ticker in tickers)
            {
                records.Add(ticker, new ChartDTO { Symbol = ticker });
                Task t = Task.Run(async () =>
                {
                    var ret = await _yahooFinanceIntegration.GetChart(ticker, ValidRange.D1.ToString(), ValidRange.D1.ToString());

                    if (ret != null)
                    {
                        //Debug.WriteLine($"{ticker} {ret.Chart.Result.First().Indicators.Adjclose.First().AdjcloseValues.First()}");
                        records[ticker] = new ChartDTO
                        {
                            Symbol = ret.Chart.Result.First().Meta.Symbol,
                            ShortName = ret.Chart.Result.First().Meta.ShortName,
                            RegularMarketTime = Util.UnixTimeStampToDateTime(ret.Chart.Result.First().Meta.RegularMarketTime),
                            High = ret.Chart.Result.First().Indicators.Quote.First().High.First(),
                            Low = ret.Chart.Result.First().Indicators.Quote.First().Low.First(),
                            Close = ret.Chart.Result.First().Indicators.Quote.First().Close.First(),
                            Open = ret.Chart.Result.First().Indicators.Quote.First().Open.First(),
                            Volume = ret.Chart.Result.First().Indicators.Quote.First().Volume.First(),
                            Adjclose = ret.Chart.Result.First().Indicators.Adjclose.First().AdjcloseValues.First(),
                            Currency = ret.Chart.Result.First().Meta.Currency
                        };
                    }
                });
                tasks.Add(t);
            }
            Task.WaitAll([.. tasks], -1);

            return Util.CreateCsvFile(filename, [.. records.Values]);
        }
    }
}
