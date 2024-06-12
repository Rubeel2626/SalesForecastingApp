using System.Windows.Forms;
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace SalesForecastingApp
{
    partial class SalesForm
    {
        private ComboBox cmbYear;
        private Button btnGetSales;
        private Label lblTotalSales;
        private DataGridView dgvSalesByState;
        private TextBox txtIncrement;
        private Button btnApplyIncrement;
        private Label lblIncrementedSales;
        private Button btnExportCsv;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesChart;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.btnGetSales = new System.Windows.Forms.Button();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.dgvSalesByState = new System.Windows.Forms.DataGridView();
            this.txtIncrement = new System.Windows.Forms.TextBox();
            this.btnApplyIncrement = new System.Windows.Forms.Button();
            this.lblIncrementedSales = new System.Windows.Forms.Label();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.salesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesByState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2018",
            "2019",
            "2020",
            "2021"});
            this.cmbYear.Location = new System.Drawing.Point(12, 12);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(121, 21);
            this.cmbYear.TabIndex = 0;
            // 
            // btnGetSales
            // 
            this.btnGetSales.Location = new System.Drawing.Point(150, 12);
            this.btnGetSales.Name = "btnGetSales";
            this.btnGetSales.Size = new System.Drawing.Size(75, 23);
            this.btnGetSales.TabIndex = 1;
            this.btnGetSales.Text = "Get Sales";
            this.btnGetSales.UseVisualStyleBackColor = true;
            this.btnGetSales.Click += new System.EventHandler(this.btnGetSales_Click);
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Location = new System.Drawing.Point(12, 50);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(63, 13);
            this.lblTotalSales.TabIndex = 2;
            this.lblTotalSales.Text = "Total Sales:";
            // 
            // dgvSalesByState
            // 
            this.dgvSalesByState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesByState.Location = new System.Drawing.Point(12, 80);
            this.dgvSalesByState.Name = "dgvSalesByState";
            this.dgvSalesByState.RowHeadersWidth = 51;
            this.dgvSalesByState.RowTemplate.Height = 24;
            this.dgvSalesByState.Size = new System.Drawing.Size(760, 250);
            this.dgvSalesByState.TabIndex = 3;
            // 
            // txtIncrement
            // 
            this.txtIncrement.Location = new System.Drawing.Point(12, 350);
            this.txtIncrement.Name = "txtIncrement";
            this.txtIncrement.Size = new System.Drawing.Size(100, 20);
            this.txtIncrement.TabIndex = 4;
            this.txtIncrement.Text = "0";
            // 
            // btnApplyIncrement
            // 
            this.btnApplyIncrement.Location = new System.Drawing.Point(130, 350);
            this.btnApplyIncrement.Name = "btnApplyIncrement";
            this.btnApplyIncrement.Size = new System.Drawing.Size(130, 23);
            this.btnApplyIncrement.TabIndex = 5;
            this.btnApplyIncrement.Text = "Apply Increment";
            this.btnApplyIncrement.UseVisualStyleBackColor = true;
            this.btnApplyIncrement.Click += new System.EventHandler(this.btnApplyIncrement_Click);
            // 
            // lblIncrementedSales
            // 
            this.lblIncrementedSales.AutoSize = true;
            this.lblIncrementedSales.Location = new System.Drawing.Point(12, 380);
            this.lblIncrementedSales.Name = "lblIncrementedSales";
            this.lblIncrementedSales.Size = new System.Drawing.Size(98, 13);
            this.lblIncrementedSales.TabIndex = 6;
            this.lblIncrementedSales.Text = "Incremented Sales:";
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(12, 410);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(100, 23);
            this.btnExportCsv.TabIndex = 7;
            this.btnExportCsv.Text = "Export CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // salesChart
            // 
            chartArea1.Name = "ChartArea1";
            this.salesChart.ChartAreas.Add(chartArea1);
            this.salesChart.Location = new System.Drawing.Point(12, 450);
            this.salesChart.Name = "salesChart";
            this.salesChart.Size = new System.Drawing.Size(760, 300);
            this.salesChart.TabIndex = 8;
            this.salesChart.Text = "Sales Chart";
            // 
            // SalesForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.btnGetSales);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.dgvSalesByState);
            this.Controls.Add(this.txtIncrement);
            this.Controls.Add(this.btnApplyIncrement);
            this.Controls.Add(this.lblIncrementedSales);
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.salesChart);
            this.Name = "SalesForm";
            this.Text = "Sales Forecasting";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesByState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

