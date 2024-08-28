namespace Services.DTO
{
    public class ChartDTO
    {
        public string? Symbol { get; set; }
        public string? ShortName { get; set; }
        public DateTime RegularMarketTime { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Open { get; set; }
        public long Volume { get; set; }
        public double Adjclose { get; set; }
        public string? Currency { get; set; }
    }
}
