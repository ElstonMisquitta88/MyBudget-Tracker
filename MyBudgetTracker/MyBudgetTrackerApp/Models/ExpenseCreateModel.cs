using DataLibrary.Models;

namespace MyBudgetTrackerApp.Models;

public class ExpenseCreateModel
{
    public BankBalanceModel BankDetails { get; set; } = new BankBalanceModel();
    public ExpenseModel ExpenseSingle { get; set; } = new ExpenseModel();
    public List<ExpenseModel> ExpenseList { get; set; } = new List<ExpenseModel>();
}
