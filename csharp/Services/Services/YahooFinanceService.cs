using Consumer.Interfaces;
using CsvHelper;
using CsvHelper.Configuration;
using Services.DTO;
using Services.Interfaces;
using Services.Utilities;
using System.Globalization;

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
            // service atualiza valores da lista
            // service salva o arquivo
            var records = new List<ChartDTO>();

            foreach (var ticker in tickers)
            {
                //todo mapear ticker (.sa e ibov)
                var ret = await _yahooFinanceIntegration.GetChart(ticker,
                    ValidRange.D1.ToString(), ValidRange.D1.ToString());

                if (ret == null)
                    continue;

                records.Add(new ChartDTO
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
                });
            }

            return Util.CreateCsvFile(filename, records);
        }
    }
}
