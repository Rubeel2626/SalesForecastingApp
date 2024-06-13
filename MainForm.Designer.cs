using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace SalesForecastingApp
{
    partial class MainForm
    { 
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox stateComboBox;
        private System.Windows.Forms.TextBox percentageTextBox;
        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.Button applyPercentageButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.DataGridView salesDataGridView;
        private System.Windows.Forms.Label totalSalesLabel;
        private System.Windows.Forms.Label selectYearLabel;
        private System.Windows.Forms.Label enterPercentageLabel;
        private System.Windows.Forms.Label selectStateLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart aggregatedSalesChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart salesBreakdownChart;

        private void InitializeComponent()
        {
            this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.stateComboBox = new System.Windows.Forms.ComboBox();
            this.percentageTextBox = new System.Windows.Forms.TextBox();
            this.queryButton = new System.Windows.Forms.Button();
            this.applyPercentageButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.salesDataGridView = new System.Windows.Forms.DataGridView();
            this.aggregatedSalesChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.salesBreakdownChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.totalSalesLabel = new System.Windows.Forms.Label();
            this.selectYearLabel = new System.Windows.Forms.Label();
            this.enterPercentageLabel = new System.Windows.Forms.Label();
            this.selectStateLabel = new System.Windows.Forms.Label();
            this.mainLayoutPanel.SuspendLayout();
            this.inputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggregatedSalesChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBreakdownChart)).BeginInit();
            this.SuspendLayout();
            // 
            // mainLayoutPanel
            // 
            this.mainLayoutPanel.ColumnCount = 1;
            this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayoutPanel.Controls.Add(this.inputGroupBox, 0, 0);
            this.mainLayoutPanel.Controls.Add(this.salesDataGridView, 0, 1);
            this.mainLayoutPanel.Controls.Add(this.aggregatedSalesChart, 0, 2);
            this.mainLayoutPanel.Controls.Add(this.salesBreakdownChart, 0, 3);
            this.mainLayoutPanel.Controls.Add(this.totalSalesLabel, 0, 4);
            this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutPanel.Name = "mainLayoutPanel";
            this.mainLayoutPanel.RowCount = 5;
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.mainLayoutPanel.Size = new System.Drawing.Size(800, 850);
            this.mainLayoutPanel.TabIndex = 0;
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Controls.Add(this.yearComboBox);
            this.inputGroupBox.Controls.Add(this.stateComboBox);
            this.inputGroupBox.Controls.Add(this.selectYearLabel);
            this.inputGroupBox.Controls.Add(this.enterPercentageLabel);
            this.inputGroupBox.Controls.Add(this.selectStateLabel);
            this.inputGroupBox.Controls.Add(this.queryButton);
            this.inputGroupBox.Controls.Add(this.percentageTextBox);
            this.inputGroupBox.Controls.Add(this.applyPercentageButton);
            this.inputGroupBox.Controls.Add(this.exportButton);
            this.inputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputGroupBox.Location = new System.Drawing.Point(3, 3);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(794, 144);
            this.inputGroupBox.TabIndex = 0;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Sales Forecasting Input";
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.Location = new System.Drawing.Point(10, 40);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(120, 21);
            this.yearComboBox.TabIndex = 0;
            // 
            // stateComboBox
            // 
            this.stateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stateComboBox.Location = new System.Drawing.Point(150, 40);
            this.stateComboBox.Name = "stateComboBox";
            this.stateComboBox.Size = new System.Drawing.Size(120, 21);
            this.stateComboBox.TabIndex = 1;
            // 
            // selectYearLabel
            // 
            this.selectYearLabel.Location = new System.Drawing.Point(10, 20);
            this.selectYearLabel.Name = "selectYearLabel";
            this.selectYearLabel.Size = new System.Drawing.Size(120, 20);
            this.selectYearLabel.TabIndex = 2;
            this.selectYearLabel.Text = "Select Year";
            // 
            // enterPercentageLabel
            // 
            this.enterPercentageLabel.Location = new System.Drawing.Point(10, 70);
            this.enterPercentageLabel.Name = "enterPercentageLabel";
            this.enterPercentageLabel.Size = new System.Drawing.Size(120, 20);
            this.enterPercentageLabel.TabIndex = 3;
            this.enterPercentageLabel.Text = "Enter Percentage";
            // 
            // selectStateLabel
            // 
            this.selectStateLabel.Location = new System.Drawing.Point(150, 20);
            this.selectStateLabel.Name = "selectStateLabel";
            this.selectStateLabel.Size = new System.Drawing.Size(120, 20);
            this.selectStateLabel.TabIndex = 4;
            this.selectStateLabel.Text = "Select State";
            // 
            // percentageTextBox
            // 
            this.percentageTextBox.Location = new System.Drawing.Point(10, 90);
            this.percentageTextBox.Multiline = true;
            this.percentageTextBox.Name = "percentageTextBox";
            this.percentageTextBox.Size = new System.Drawing.Size(120, 22);
            this.percentageTextBox.TabIndex = 6;
                       // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(290, 40);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(100, 23);
            this.queryButton.TabIndex = 8;
            this.queryButton.Text = "Get Sales";
            this.queryButton.UseVisualStyleBackColor = true;
            this.queryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // applyPercentageButton
            // 
            this.applyPercentageButton.Location = new System.Drawing.Point(150, 90);
            this.applyPercentageButton.Name = "applyPercentageButton";
            this.applyPercentageButton.Size = new System.Drawing.Size(120, 23);
            this.applyPercentageButton.TabIndex = 9;
            this.applyPercentageButton.Text = "Apply Percentage";
            this.applyPercentageButton.UseVisualStyleBackColor = true;
            this.applyPercentageButton.Click += new System.EventHandler(this.ApplyPercentageButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(290, 90);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 23);
            this.exportButton.TabIndex = 11;
            this.exportButton.Text = "Export CSV";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // salesDataGridView
            // 
            this.salesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.salesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesDataGridView.Location = new System.Drawing.Point(3, 153);
            this.salesDataGridView.Name = "salesDataGridView";
            this.salesDataGridView.Size = new System.Drawing.Size(794, 264);
            this.salesDataGridView.TabIndex = 12;
            // 
            // aggregatedSalesChart
            // 
            this.aggregatedSalesChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aggregatedSalesChart.Location = new System.Drawing.Point(3, 423);
            this.aggregatedSalesChart.Name = "aggregatedSalesChart";
            this.aggregatedSalesChart.Size = new System.Drawing.Size(794, 264);
            this.aggregatedSalesChart.TabIndex = 13;
            // 
            // salesBreakdownChart
            // 
            this.salesBreakdownChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesBreakdownChart.Location = new System.Drawing.Point(3, 693);
            this.salesBreakdownChart.Name = "salesBreakdownChart";
            this.salesBreakdownChart.Size = new System.Drawing.Size(794, 124);
            this.salesBreakdownChart.TabIndex = 14;
            // 
            // totalSalesLabel
            // 
            this.totalSalesLabel.AutoSize = true;
            this.totalSalesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalSalesLabel.Location = new System.Drawing.Point(3, 820);
            this.totalSalesLabel.Name = "totalSalesLabel";
            this.totalSalesLabel.Size = new System.Drawing.Size(0, 13);
            this.totalSalesLabel.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 850);
            this.Controls.Add(this.mainLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Sales Forecasting Application";
            this.mainLayoutPanel.ResumeLayout(false);
            this.mainLayoutPanel.PerformLayout();
            this.inputGroupBox.ResumeLayout(false);
            this.inputGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.salesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aggregatedSalesChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesBreakdownChart)).EndInit();
            this.ResumeLayout(false);
        }

    }
}