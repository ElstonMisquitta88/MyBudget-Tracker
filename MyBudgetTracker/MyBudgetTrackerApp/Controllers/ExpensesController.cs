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
        public async Task<IActionResult> Display(int id)
        {
            ExpenseCreateModel expenseCreateModel = new ExpenseCreateModel();

            ExpenseModel singobj = new ExpenseModel();
            singobj.Id = id;
            expenseCreateModel.ExpenseSingle = singobj;
            
            // TODO
            //expenseCreateModel.ExpenseList = await _ExpenseData.GetAll_ExpenseForMonth();
            return View(expenseCreateModel);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
