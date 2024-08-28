namespace Services.Interfaces
{
    public interface IYahooFinanceService
    {
        Task<bool> GetChartAndSave(List<string> tickers, string filename);
    }
}