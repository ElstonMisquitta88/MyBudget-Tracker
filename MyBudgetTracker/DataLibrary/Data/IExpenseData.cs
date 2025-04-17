using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IExpenseData
    {
        Task<bool> AddExpense(ExpenseModel _expdata);

        Task<List<ExpenseModel>> Get_Expense_ByBankID(int Bank_ID);

        Task<bool> UpdateExpense(ExpenseModel _expdata);
    }
}