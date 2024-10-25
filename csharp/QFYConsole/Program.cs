using Consumer;
using Services.Services;
using Services.Utilities;

namespace QFYConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Yahoo Finance Query Console");
            Console.WriteLine("---------------------------");

            if (args.Length > 0 && args[0] == "?")
            {
                ShowUsage();
                return;
            }

            var filename = (args.Length > 0)
                ? Util.GetFullFilename(args[0])
                : Util.GetFullDefaultFilename() + "";
            Console.WriteLine($"Carregando arquivo:");
            Console.WriteLine($"{filename}");

            var dataTable = Util.GetData(filename);
            var tickers = Util.GetSymbols(dataTable.Rows);
            Console.WriteLine($"Arquivo carregado com sucesso!");

            var yahooFinanceService = new YahooFinanceService(new YahooFinanceIntegration());
            var ret = await yahooFinanceService.GetChartAndSave(tickers, filename);
            if (ret)
            {
                Console.WriteLine();
                Console.WriteLine($"{dataTable.Rows.Count} itens atualizados com sucesso no arquivo:");
                Console.WriteLine($"{filename}");
            }
        }

        private static void ShowUsage()
        {
            Console.WriteLine();
            Console.WriteLine("Sintaxe:");
            Console.WriteLine("   QFYConsole.exe");
            Console.WriteLine("ou");
            Console.WriteLine("   QFYConsole.exe <NomeDoArquivo.csv>");
            Console.WriteLine();
            Console.WriteLine("Quando o nome do arquivo não for fornecido, o arquivo default (query_finance_yahoo_v8.csv)");
            Console.WriteLine("será utilizado (obrigatório que o mesmo esteja disponível na mesma pasta).");
            Console.WriteLine("Os dados atualizados serão salvos no arquivo que estiver sendo processado.");

        }
    }
}
