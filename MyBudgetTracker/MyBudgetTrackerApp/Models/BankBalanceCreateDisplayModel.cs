using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MyBudgetTrackerApp.Models;

public class BankBalanceCreateDisplayModel
{
    public BankBalanceModel BankBal { get; set; } = new BankBalanceModel();
    public List<BankBalanceModel> BankBalLst { get; set; } = new List<BankBalanceModel>();
}
