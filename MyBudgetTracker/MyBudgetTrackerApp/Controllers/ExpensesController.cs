using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using MyBudgetTrackerApp.Models;

namespace MyBudgetTrackerApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpenseData _ExpenseData;

        public ExpensesController(IExpenseData ExpenseData)
        {
            _ExpenseData = ExpenseData;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Display(int Bank_ID)
        {
            ExpenseCreateModel expenseCreateModel = new ExpenseCreateModel();

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
            return RedirectToAction("Display", "Expenses", new { Bank_ID = ExpenseSingle.Bank_ID });
        }

        [HttpPost]
        public async Task<IActionResult> Update(ExpenseModel ExpenseSingle, string actionType)
        {
            switch (actionType)
            {
                //TODO
                case "Update":
                    TempData["Message"] = "Bank balance updated!";
                    break;

                //TODO
                case "Delete":
                    TempData["Message"] = "Bank balance deleted!";
                    break;

                default:
                    TempData["Message"] = "Unknown action.";
                    break;
            }

            return RedirectToAction("Display", "Expenses", new { Bank_ID = ExpenseSingle.Bank_ID });
        }
    }
}
