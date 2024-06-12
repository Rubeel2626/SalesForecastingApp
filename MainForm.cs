using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SalesForecastingApp
{
    public partial class MainForm : Form
    {
        private SqlConnection connection;

        public MainForm()
        {
            InitializeComponent();
            LoadYears();
            InitializeDatabaseConnection();
            LoadStates();
        }

        private void InitializeDatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SalesDB"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        private void LoadYears()
        {
            yearComboBox.Items.Add("2018");
            yearComboBox.Items.Add("2019");
            yearComboBox.Items.Add("2020");
            yearComboBox.Items.Add("2021");
        }

        private void LoadStates()
        {
            try
            {
                string query = "SELECT DISTINCT State FROM Orders";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable statesTable = new DataTable();
                adapter.Fill(statesTable);
                stateComboBox.Items.Add("All States");
                foreach (DataRow row in statesTable.Rows)
                {
                    stateComboBox.Items.Add(row["State"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading states: " + ex.Message);
            }
        }

        private void QueryButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (yearComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select a year before applying the percentage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string selectedYear = yearComboBox.SelectedItem.ToString();
                string selectedState = string.Empty;
                if (stateComboBox.SelectedItem == null)
                {
                    selectedState = string.Empty;
                }
                if (stateComboBox.SelectedItem != null)
                {
                    if (stateComboBox.SelectedItem.Equals("All States"))
                    {
                        selectedState = string.Empty;
                    }
                    else
                    {
                        selectedState = stateComboBox.SelectedItem?.ToString();
                    }
                }
               
                DisplaySalesData(selectedYear, selectedState);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void DisplaySalesData(string year, string state)
        {
            try
            {
                string query = @"
        WITH CTE_pro AS (
            SELECT 
                o.OrderId,
                o.State, 
                p.Sales AS TotalSales
            FROM  
                Products p
            INNER JOIN 
                Orders o ON o.OrderId = p.OrderId
            WHERE 
                YEAR(o.OrderDate) = @Year" +
                    (!string.IsNullOrEmpty(state) ? " AND o.State = @State" : "") +
                    @"
        ),
        CTE_ORD AS (
            SELECT 
                o.OrderId,
                o.State, 
                p.Sales AS TotalSales
            FROM 
                OrdersReturns r
            INNER JOIN 
                Products p ON r.OrderId = p.OrderId
            INNER JOIN 
                Orders o ON o.OrderId = p.OrderId
            WHERE 
                YEAR(o.OrderDate) = @Year" +
                    (!string.IsNullOrEmpty(state) ? " AND o.State = @State" : "") +
                    @"
        )
        SELECT 
            cte_pro.State,
            SUM(cte_pro.TotalSales) - COALESCE(SUM(cte_ord.TotalSales), 0) AS TotalSales           
        FROM 
            CTE_pro cte_pro
        LEFT JOIN 
            CTE_ORD cte_ord ON cte_pro.OrderId = cte_ord.OrderId
       
        " +
                    (!string.IsNullOrEmpty(state) ? "WHERE cte_pro.State = @State" : "") +
                    @"
        GROUP BY 
            cte_pro.State;";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Year", year);

                if (!string.IsNullOrEmpty(state))
                {
                    command.Parameters.AddWithValue("@State", state);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Display total sales and increased sales
                double totalSales = dataTable.AsEnumerable().Sum(row => row.Field<double>("TotalSales"));
                totalSalesLabel.Text = $"Total Sales: {totalSales:C}";

                salesDataGridView.DataSource = dataTable;

                if (!salesDataGridView.Columns.Contains("IncreasedSales"))
                {
                    salesDataGridView.Columns.Add("IncreasedSales", "Increased Sales");
                }

                salesDataGridView.Columns["TotalSales"].DefaultCellStyle.Format = "N2";

                PlotSalesData(dataTable, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching sales data: " + ex.Message);
            }
        }


        private void ApplyPercentageButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(percentageTextBox.Text, out decimal percentageIncrease))
            {
                ApplyPercentageIncrease(percentageIncrease);
                DataTable salesData = (DataTable)salesDataGridView.DataSource;
                if (salesData != null)
                {
                    PlotSalesData(salesData, (double)percentageIncrease);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid percentage.");
            }
        }

        private void ApplyPercentageIncrease(decimal percentage)
        {
            foreach (DataGridViewRow row in salesDataGridView.Rows)
            {
                if (row.Cells["TotalSales"].Value != null)
                {
                    decimal totalSales = Convert.ToDecimal(row.Cells["TotalSales"].Value);
                    decimal increasedSales = totalSales * (1 + percentage / 100);
                    row.Cells["IncreasedSales"].Value = increasedSales;
                }
            }
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            ExportToCSV();
        }

        private void ExportToCSV()
        {
            string filePath = "forecasted_data.csv";
            string fullFilePath = string.Empty;
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("State,Percentage Increase,Sales Value");
                    foreach (DataGridViewRow row in salesDataGridView.Rows)
                    {
                        if (row.Cells["State"].Value != null && row.Cells["IncreasedSales"].Value != null)
                        {
                            writer.WriteLine($"{row.Cells["State"].Value},{percentageTextBox.Text},{row.Cells["IncreasedSales"].Value}");
                        }
                    }
                    fullFilePath = Path.GetFullPath(filePath);
                }
                MessageBox.Show("Data exported successfully and stored at " + fullFilePath);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message);
            }
        }

        private void PlotSalesData(DataTable dataTable, double percentageIncrease)
        {
            aggregatedSalesChart.Series.Clear();
            salesBreakdownChart.Series.Clear();
            aggregatedSalesChart.Titles.Clear();
            salesBreakdownChart.Titles.Clear();

            aggregatedSalesChart.ChartAreas.Clear();
            salesBreakdownChart.ChartAreas.Clear();

            aggregatedSalesChart.Titles.Add("Aggregated Sales");
            salesBreakdownChart.Titles.Add("Sales Breakdown by State");

            aggregatedSalesChart.ChartAreas.Add(new ChartArea("MainChartArea"));
            salesBreakdownChart.ChartAreas.Add(new ChartArea("BreakdownChartArea"));

            Series seedingYearSeries = new Series("Seeding Year Sales")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double
            };

            Series forecastedYearSeries = new Series("Forecasted Year Sales")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double
            };

            Series seedingYearBreakdownSeries = new Series("Seeding Year Sales")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double
            };

            Series forecastedYearBreakdownSeries = new Series("Forecasted Year Sales")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                YValueType = ChartValueType.Double
            };

            double totalSeedingYearSales = 0;
            double totalForecastedYearSales = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                string state = row.Field<string>("State");
                double seedingYearSales = row.Field<double>("TotalSales");
                double forecastedYearSales = seedingYearSales * (1 + percentageIncrease / 100);

                totalSeedingYearSales += seedingYearSales;
                totalForecastedYearSales += forecastedYearSales;

                seedingYearBreakdownSeries.Points.AddXY(state, seedingYearSales);
                forecastedYearBreakdownSeries.Points.AddXY(state, forecastedYearSales);
            }

            seedingYearSeries.Points.AddXY("Seeding Year Sales", totalSeedingYearSales);
            forecastedYearSeries.Points.AddXY("Forecasted Year Sales", totalForecastedYearSales);

            aggregatedSalesChart.Series.Add(seedingYearSeries);
            aggregatedSalesChart.Series.Add(forecastedYearSeries);

            salesBreakdownChart.Series.Add(seedingYearBreakdownSeries);
            salesBreakdownChart.Series.Add(forecastedYearBreakdownSeries);
        }

     
    }
}
