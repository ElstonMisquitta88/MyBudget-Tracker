using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IExpenseData
    {
        Task<bool> AddExpense(ExpenseModel _expdata);
    }
}