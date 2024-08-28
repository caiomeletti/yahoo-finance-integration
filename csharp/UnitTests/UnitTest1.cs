using Consumer;

namespace UnitTests
{
    public class UnitTest1
    {
        private readonly YahooFinanceIntegration _yahooFinanceIntegration;

        public UnitTest1(            )
        {
            _yahooFinanceIntegration = new YahooFinanceIntegration();
        }

        [Fact]
        public async Task Test1()
        {
            var ret = await _yahooFinanceIntegration.GetChart("ABEV3.SA", "1d", "1d");
            Assert.NotNull(ret);
        }
    }
}