using CsvHelper;
using CsvHelper.Configuration;
using Services.DTO;
using Services.Mappers;
using System.Data;
using System.Globalization;

namespace Services.Utilities
{
    public static class Util
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        public static DataTable ConvertCSVtoDataTable(string filePath)
        {
            DataTable dt = new();
            using (StreamReader sr = new(filePath))
            {
                string[] headers = sr.ReadLine().Split(';');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public static IEnumerable<ChartDTO> CsvReader(string filename)
        {
            using var reader = new StreamReader(filename);
            var config = new CsvConfiguration(CultureInfo.GetCultureInfo("pt-BR"))
            {
                Delimiter = ";",
            };
            using var csv = new CsvReader(reader, config);
            csv.Context.RegisterClassMap<ChartDTOMap>();
            var records = csv.GetRecords<ChartDTO>();

            return records;
        }
        public static DataTable GetData(string _filename)
        {
            //var dt = Util.ConvertCSVtoDataTable(_filename);
            var dt = GetDataTableFromCsv(_filename);
            return dt;
        }

        public static DataTable GetDataTableFromCsv(string filename)
        {
            using var reader = new StreamReader(filename);
            var config = new CsvConfiguration(CultureInfo.GetCultureInfo("pt-BR"))
            {
                Delimiter = ";",
            };
            using var csv = new CsvReader(reader, config);
            using var dr = new CsvDataReader(csv);
            var dt = new DataTable();
            dt.Load(dr);

            return dt;
        }

        public static bool CreateCsvFile(string filename, List<ChartDTO> records)
        {
            bool ret = false;
            try
            {
                if (records.Count != 0)
                {
                    using var writer = new StreamWriter(filename);
                    var config = new CsvConfiguration(CultureInfo.GetCultureInfo("pt-BR"))
                    {
                        Delimiter = ";",
                    };
                    using var csv = new CsvWriter(writer, config);
                    csv.WriteRecords(records);
                    ret = true;
                }
            }
            catch (Exception)
            {
                ret = false;
            }

            return ret;
        }

        public static string? GetFullDefaultFilename()
        {
            return GetFullFilename("query_finance_yahoo_v8.csv");
        }

        public static string? GetFullFilename(string _filename)
        {
            return Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), _filename);
        }

        public static List<string> GetSymbols(DataRowCollection rows)
        {
            return (from DataRow row in rows
                    select new string(row["Symbol"].ToString())
                    ).ToList();
        }
    }
}
