using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using MyBudgetTrackerApp.Models;
using System.Collections.Generic;

namespace MyBudgetTrackerApp.Controllers
{
    public class BankBalanceController : Controller
    {
        private readonly IBankBalanceData _BankData;

       public BankBalanceController(IBankBalanceData BankData)
        {
            _BankData = BankData;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create()
        {
            BankBalanceCreateDisplayModel modeldt = new BankBalanceCreateDisplayModel();
            modeldt.BankBalLst = await _BankData.GetAll_BankBalanceForMonth();
            return View(modeldt);
        }


        [HttpPost]
        public async Task<IActionResult> Create(BankBalanceModel BankBal)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }
            bool _result = await _BankData.CreateBankBalanceForMonth(BankBal);
            if (_result)
            {
                ViewBag.Message = "Bank Balance Created Successfully";
                ModelState.Clear();
            }
            else
            {
                ViewBag.Message = "Bank Balance Creation Failed";
                ModelState.Clear();
            }
            return RedirectToAction("Create");
        }


        [HttpPost]
        public async Task<IActionResult> Update(BankBalanceModel BankBal, string actionType)
        {
            switch (actionType)
            {
                case "AddExpense":
                    // Move to Different View
                    return RedirectToAction("Display", "Expenses", new { Bank_ID = BankBal.Id });
                    break;

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

            return RedirectToAction("Create");
        }


    }
}
