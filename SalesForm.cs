using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesForecastingApp
{
    public partial class SalesForm : Form
    {
        private string connectionString = "Data Source =CT-RUBEEL;Initial Catalog = DB_Sales;Integrated Security=True";
        public SalesForm()
        {
            InitializeComponent();
        }
        private void btnGetSales_Click(object sender, EventArgs e)
        {
            int year = int.Parse(cmbYear.SelectedItem.ToString());
            decimal totalSales = GetTotalSalesByYear(year);
            DataTable salesByState = GetSalesByYear(year);

            lblTotalSales.Text = "Total Sales: " + totalSales.ToString("C");
            dgvSalesByState.DataSource = salesByState;
        }

        private void btnApplyIncrement_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(cmbYear.SelectedItem.ToString(), out int year))
            {
                MessageBox.Show("Please select a valid year.");
                return;
            }

            if (!decimal.TryParse(txtIncrement.Text, out decimal increment))
            {
                MessageBox.Show("Please enter a valid percentage.");
                return;
            }

            increment /= 100;
            decimal totalSales = GetTotalSalesByYear(year);
            decimal incrementedSales = totalSales * (1 + increment);

            DataTable salesByState = GetSalesByYear(year);
            salesByState.Columns.Add("IncrementedSales", typeof(decimal));

            foreach (DataRow row in salesByState.Rows)
            {
                decimal stateSales = (decimal)row["TotalSales"];
                row["IncrementedSales"] = stateSales * (1 + increment);
            }

            lblIncrementedSales.Text = "Incremented Sales: " + incrementedSales.ToString("C");
            dgvSalesByState.DataSource = salesByState;
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            // Implement CSV Export Functionality
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                FileName = "ForecastedSales.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = dgvSalesByState.DataSource as DataTable;
                if (dt != null)
                {
                    ExportToCsv(dt, sfd.FileName);
                }
            }
        }

        private decimal GetTotalSalesByYear(int year)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetTotalSalesByYear", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Year", year);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return (decimal)cmd.ExecuteScalar();
            }
        }

        private DataTable GetSalesByYear(int year)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetSalesByYear", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Year", year);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }

        private void ExportToCsv(DataTable dt, string filePath)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                sb.AppendLine(string.Join(",", fields));
            }

            System.IO.File.WriteAllText(filePath, sb.ToString());
        }
    }
}
