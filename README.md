Warehouse Management System - ASP.NET MVC Project
Overview
This Warehouse Management System (WMS) is built using ASP.NET MVC and provides a comprehensive solution for managing orders, inventory, customers, and suppliers in a streamlined and efficient manner. The system supports both English and Arabic, enhancing usability across different regions. It also features real-time inventory management, dynamic order creation, multi-language support, and a clean, user-friendly interface.

Key Features
Multi-Language Support: Fully supports English and Arabic with automatic RTL (Right-to-Left) layout adaptation.
Inventory Management: Real-time inventory updates, stock adjustments, and detailed reports.
Order Management: Dynamic order creation with product quantity and price updates without refreshing the page.
Customer & Supplier Accounts: Tracks all payments and balances, whether in cash or installments.
Financial Tracking: Detailed records of all payments with support for different payment methods.
Product Insights: Displays total purchased and sold quantities, and top customers for each product.
Technologies Used
ASP.NET MVC
Entity Framework
Bootstrap for responsive UI
SQL Server
Multi-language support using .resx files
Git for version control
Getting Started
Prerequisites
Visual Studio 2022 or later
.NET 6 SDK
SQL Server
Git
Installation
Clone the repository:
bash
نسخ الكود
git clone https://github.com/your-repo/warehouse-management-system.git
Navigate to the project directory:
bash
نسخ الكود
cd warehouse-management-system
Build the project:
bash
نسخ الكود
dotnet build
Run the project:
bash
نسخ الكود
dotnet run
Set up your database by running migrations:
bash
نسخ الكود
dotnet ef database update
Usage
Once the system is running, you can manage orders, customers, products, and inventory through the intuitive web interface. All changes to inventory or orders are tracked, and the system supports dynamic updates for better user experience.

