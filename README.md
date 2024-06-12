**Sales Forecasting Application**

This application provides a sales forecasting tool that calculates and displays sales data based on selected years and optional percentage increases per state.

Table of Contents

1) Features

2) Prerequisites

3) Installation

4) Usage

5) SQL Database Setup

6) Proof of content

   
**Features**

Select Year: Choose a specific year to display sales data.

Apply Percentage Increase: Optionally apply a percentage increase to forecast sales.

Export Data: Export displayed data to CSV format.

Visualize Data: Display aggregated and breakdown charts of sales data.

**Prerequisites**

Before running the application, ensure you have the following installed:

Microsoft Visual Studio (for running and modifying the source code)

SQL Server Management Studio (for managing the SQL database)

**Installation**

Clone the repository:

bash
Copy code
**git clone <repository-url>**
Open the solution in Visual Studio.

Build the solution to restore NuGet packages and dependencies.

**Usage**

Update the connection string in App.config under <connectionStrings> to point to your SQL Server instance.

Run the Application:

Build and run the application in Visual Studio.

Select a year from the dropdown list and click on Get Sales to fetch sales data.

Optionally, enter a percentage in the text box and click Apply Percentage to forecast sales with an increase.

Click Export CSV to export displayed data to a CSV file.

Charts:

View aggregated and breakdown charts to visualize sales data.

**SQL Database Setup**

Database Schema:

The application assumes a database schema with tables Orders, Products, and OrdersReturns.
Modify the SQL queries in MainForm.cs to match your database schema if necessary.

**Proof Of Content**

