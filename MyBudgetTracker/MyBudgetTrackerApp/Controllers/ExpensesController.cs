using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using MyBudgetTrackerApp.Models;

namespace MyBudgetTrackerApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseData _ExpenseData;
        private readonly IBankBalanceData _BankData;

        public ExpensesController(IExpenseData ExpenseData, IBankBalanceData BankData)
        {
            _ExpenseData = ExpenseData;
            _BankData = BankData;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Display(int Bank_ID)
        {
            ExpenseCreateModel expenseCreateModel = new ExpenseCreateModel();

            // (1) Bank Details
            var _bnkdetails = _BankData.Get_GetBankBalance_ByID(Bank_ID);
            expenseCreateModel.BankDetails = _bnkdetails.Result.FirstOrDefault();

            // (2) Expense Details
            ExpenseModel singobj = new ExpenseModel();
            singobj.Bank_ID = Bank_ID;
            expenseCreateModel.ExpenseSingle = singobj;
            expenseCreateModel.ExpenseList = await _ExpenseData.Get_Expense_ByBankID(Bank_ID);



            return View(expenseCreateModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(ExpenseModel ExpenseSingle)
        {
            bool _result = await _ExpenseData.AddExpense(ExpenseSingle);
            if (_result)
            {
                TempData["SuccessMessage"] = "Expense Updated successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Error updating expense.";
            }
            return RedirectToAction("Display", "Expenses", new { Bank_ID = ExpenseSingle.Bank_ID });
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExpenseModel ExpenseSingle, string actionType)
        {
            switch (actionType)
            {
                case "Update":
                    bool _result = await _ExpenseData.UpdateExpense(ExpenseSingle);
                    if (_result)
                    {
                        TempData["SuccessMessage"] = "Expense Updated successfully!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error updating expense.";
                    }
                    break;

               
                case "Delete":
                    bool _result_delete = true;  //TODO
                    if (_result_delete)
                    {
                        TempData["SuccessMessage"] = "Expense deleted successfully!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Error deleting expense.";
                    }
                    break;

                default:
                    TempData["Message"] = "Unknown action.";
                    break;
            }
            return RedirectToAction("Display", "Expenses", new { Bank_ID = ExpenseSingle.Bank_ID });
        }
    }
}
