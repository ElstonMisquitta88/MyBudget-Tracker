# 📦 DataLibrary (.NET Class Library)

A modular and testable class library that handles **data access and model definitions** for financial tracking apps using **Dapper** and clean architecture.

---

## 🗂️ Project Structure

```plaintext
DataLibrary/
│
├── Data/
│   ├── BankBalanceData.cs        # Handles DB ops for bank balances
│   ├── ExpenseData.cs            # Handles DB ops for expenses
│   ├── IBankBalanceData.cs       # Interface for BankBalanceData
│   └── IExpenseData.cs           # Interface for ExpenseData
│
├── DB/
│   ├── ConnectionStringData.cs   # Stores DB connection name
│   ├── IDataAccess.cs            # Dapper abstraction
│   └── SqlDb.cs                  # Dapper implementation
│
└── Models/
    ├── BankBalanceModel.cs       # POCO for bank balance
    └── ExpenseModel.cs           # POCO for expense



