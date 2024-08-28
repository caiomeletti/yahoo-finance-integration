using Newtonsoft.Json;

namespace Consumer.ViewModels
{
    public class Adjclose
    {
        public Adjclose()
        {
            AdjcloseValues = [];
        }

        [JsonProperty("adjclose")]
        public IList<double> AdjcloseValues { get; set; }
    }

    public class Chart
    {
        public Chart()
        {
            Result = [];
        }

        [JsonProperty("result")]
        public IList<Result> Result { get; set; }

        [JsonProperty("error")]
        public object? Error { get; set; }
    }

    public class CurrentTradingPeriod
    {
        public CurrentTradingPeriod()
        {
            Pre = new();
            Regular = new();
            Post = new();
        }

        [JsonProperty("pre")]
        public Pre Pre { get; set; }

        [JsonProperty("regular")]
        public Regular Regular { get; set; }

        [JsonProperty("post")]
        public Post Post { get; set; }
    }

    public class Indicators
    {
        public Indicators()
        {
            Quote = [];
            Adjclose = [];
        }

        [JsonProperty("quote")]
        public IList<Quote> Quote { get; set; }

        [JsonProperty("adjclose")]
        public IList<Adjclose> Adjclose { get; set; }
    }

    public class Meta
    {
        public Meta()
        {
            Currency = string.Empty;
            Symbol = string.Empty;
            ExchangeName = string.Empty;
            FullExchangeName = string.Empty;
            InstrumentType = string.Empty;
            Timezone = string.Empty;
            ExchangeTimezoneName = string.Empty;
            LongName = string.Empty;
            ShortName = string.Empty;
            CurrentTradingPeriod = new();
            DataGranularity = string.Empty;
            Range = string.Empty;
            ValidRanges = [];
        }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonProperty("fullExchangeName")]
        public string FullExchangeName { get; set; }

        [JsonProperty("instrumentType")]
        public string InstrumentType { get; set; }

        [JsonProperty("firstTradeDate")]
        public long? FirstTradeDate { get; set; }

        [JsonProperty("regularMarketTime")]
        public long RegularMarketTime { get; set; }

        [JsonProperty("hasPrePostMarketData")]
        public bool HasPrePostMarketData { get; set; }

        [JsonProperty("gmtoffset")]
        public int Gmtoffset { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }

        [JsonProperty("regularMarketPrice")]
        public double RegularMarketPrice { get; set; }

        [JsonProperty("fiftyTwoWeekHigh")]
        public double FiftyTwoWeekHigh { get; set; }

        [JsonProperty("fiftyTwoWeekLow")]
        public double FiftyTwoWeekLow { get; set; }

        [JsonProperty("regularMarketDayHigh")]
        public double RegularMarketDayHigh { get; set; }

        [JsonProperty("regularMarketDayLow")]
        public double RegularMarketDayLow { get; set; }

        [JsonProperty("regularMarketVolume")]
        public int RegularMarketVolume { get; set; }

        [JsonProperty("longName")]
        public string LongName { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("chartPreviousClose")]
        public double ChartPreviousClose { get; set; }

        [JsonProperty("priceHint")]
        public int PriceHint { get; set; }

        [JsonProperty("currentTradingPeriod")]
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }

        [JsonProperty("dataGranularity")]
        public string DataGranularity { get; set; }

        [JsonProperty("range")]
        public string Range { get; set; }

        [JsonProperty("validRanges")]
        public IList<string> ValidRanges { get; set; }
    }

    public class TradingPeriodBase
    {
        public TradingPeriodBase()
        {
            Timezone = string.Empty;
        }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("end")]
        public long End { get; set; }

        [JsonProperty("gmtoffset")]
        public int Gmtoffset { get; set; }
    }

    public class Post : TradingPeriodBase
    {
        public Post() : base()
        {
        }
    }

    public class Pre : TradingPeriodBase
    {
        public Pre() : base()
        {
        }
    }

    public class Quote
    {
        public Quote()
        {
            Volume = [];
            Close = [];
            Open = [];
            High = [];
            Low = [];
        }

        [JsonProperty("volume")]
        public IList<int> Volume { get; set; }

        [JsonProperty("close")]
        public IList<double> Close { get; set; }

        [JsonProperty("open")]
        public IList<double> Open { get; set; }

        [JsonProperty("high")]
        public IList<double> High { get; set; }

        [JsonProperty("low")]
        public IList<double> Low { get; set; }
    }

    public class Regular : TradingPeriodBase
    {
        public Regular() : base()
        {
        }
    }

    public class Result
    {
        public Result()
        {
            Meta = new();
            Timestamp = [];
            Indicators = new();
        }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("timestamp")]
        public IList<int> Timestamp { get; set; }

        [JsonProperty("indicators")]
        public Indicators Indicators { get; set; }
    }

    public class RootChart
    {
        public RootChart()
        {
            Chart = new();
        }

        [JsonProperty("chart")]
        public Chart Chart { get; set; }
    }
}
