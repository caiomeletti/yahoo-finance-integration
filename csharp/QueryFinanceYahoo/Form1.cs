using Consumer;
using Services.Services;
using Services.Utilities;
using System.Data;

namespace QueryFinanceYahoo
{
    public partial class Form1 : Form
    {
        private string filename;
        private BindingSource bindingSource = [];
        private DataTable dataTable = new();

        private readonly YahooFinanceService yahooFinanceService;

        public Form1()
        {
            InitializeComponent();

            filename = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "query_finance_yahoo_v8.csv");
            txtFilename.Text = filename;
            //InitializeDataGridView();
            yahooFinanceService = new YahooFinanceService(new YahooFinanceIntegration());
        }

        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = true;

            dataTable = GetData(filename);
            bindingSource.DataSource = dataTable;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.Sort(dataGridView1.Columns[0], System.ComponentModel.ListSortDirection.Ascending);

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
        }

        private static DataTable GetData(string _filename)
        {
            //var dt = Util.ConvertCSVtoDataTable(_filename);
            var dt = Util.GetDataTableFromCsv(_filename);
            return dt;
        }

        private async void cmdAtualizar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            EnabledButtons(false);

            var tickers = (from DataRow row in dataTable.Rows
                           select new string(row["Symbol"].ToString())
                           ).ToList();

            var ret = await yahooFinanceService.GetChartAndSave(tickers, filename);
            if (ret)
            {
                InitializeDataGridView();
                MessageBox.Show($"{dataTable.Rows.Count} itens atualizados com sucesso!", "Yahoo Finance Query", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Cursor.Current = Cursors.Default;
            EnabledButtons(true);
        }

        private void cmdCarregar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            InitializeDataGridView();
            cmdAtualizar.Enabled = true;
            MessageBox.Show($"{dataTable.Rows.Count} itens carregados!", "Yahoo Finance Query", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Cursor.Current = Cursors.Default;
        }

        private void EnabledButtons(bool enabled)
        {
            cmdAtualizar.Enabled = enabled;
            cmdCarregar.Enabled = enabled;
        }

        private void cmdSelecionarArquivo_Click(object sender, EventArgs e)
        {
            var filePath = OpenFileDialogToSelect();
            txtFilename.Text = filename = !string.IsNullOrEmpty(filePath)
                ? filePath
                : txtFilename.Text;
        }

        private static string OpenFileDialogToSelect()
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new())
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                }
            }

            return filePath;
        }
    }
}
