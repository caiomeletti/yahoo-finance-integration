using CsvHelper.Configuration;
using Services.DTO;

namespace Services.Mappers
{
    public sealed class ChartDTOMap : ClassMap<ChartDTO>
    {
        public ChartDTOMap()
        {
            Map(m => m.Symbol);
            Map(m => m.ShortName);
            Map(m => m.RegularMarketTime);
            Map(m => m.High);
            Map(m => m.Low);
            Map(m => m.Close);
            Map(m => m.Open);
            Map(m => m.Volume);
            Map(m => m.Adjclose);
            Map(m => m.Currency);
        }
    }
}
