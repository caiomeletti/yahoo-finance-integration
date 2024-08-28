using Consumer.ViewModels;

namespace Consumer.Interfaces
{
    public interface IYahooFinanceIntegration
    {
        Task<RootChart?> GetChart(string symbol, string interval, string range);
    }
}