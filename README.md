# 💰 MyBudgetTrackerApp

An ASP.NET Core MVC application for tracking **bank balances and expenses**, powered by a clean class library (`DataLibrary`) for data access and model separation. Includes robust logging with Serilog and real-time log viewing through SEQ.

---

## 🗂️ Project Structure

### 📁 MyBudgetTrackerApp (MVC Frontend)

```plaintext
Controllers/
│   ├── BankBalanceController.cs    # Handles bank balance CRUD actions
│   ├── ExpensesController.cs       # Handles expense display & input
│   └── HomeController.cs           # Home and error routing

Models/
│   ├── BankBalanceCreateDisplayModel.cs # ViewModel for creating and displaying balances
│   ├── ErrorViewModel.cs                # Error details for exception handling
│   └── ExpenseCreateModel.cs            # ViewModel for creating expenses

Views/
│
├── BankBalance/
│   └── Create.cshtml              # View to input new bank balances
│
├── Expenses/
│   └── Display.cshtml             # View to show expenses
│
└── Home/
    ├── Index.cshtml               # Home page
    └── Privacy.cshtml             # Privacy policy

```
---
### 📁 DataLibrary (Class Library)
```plaintext
Data/
│   ├── BankBalanceData.cs         # Service to handle bank balance DB operations
│   ├── ExpenseData.cs             # Service to handle expense DB operations
│   ├── IBankBalanceData.cs        # Interface for BankBalanceData
│   └── IExpenseData.cs            # Interface for ExpenseData

DB/
│   ├── ConnectionStringData.cs    # Holds DB connection string name
│   ├── IDataAccess.cs             # Generic Dapper interface
│   └── SqlDb.cs                   # Dapper-based implementation of IDataAccess

Models/
│   ├── BankBalanceModel.cs        # POCO for bank balance entity
│   └── ExpenseModel.cs            # POCO for expense entity

```
