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
        private readonly ILogger<BankBalanceController> _logger;

        public BankBalanceController(IBankBalanceData BankData, ILogger<BankBalanceController> logger)
        {
            _BankData = BankData;
            _logger = logger;
        }
        public IActionResult Index()
        {
            
            return View();
        }


        public async Task<ActionResult> Create()
        {
            try
            {
                _logger.LogInformation("BankBalance Create GET called");
                BankBalanceCreateDisplayModel modeldt = new BankBalanceCreateDisplayModel();
                modeldt.BankBalLst = await _BankData.GetAll_BankBalanceForMonth();
                _logger.LogInformation("BankBalance Create GET Returned");
                return View(modeldt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in BankBalance Create GET");
                return View("Error");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(BankBalanceModel BankBal)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return View();
                }
                bool _result = await _BankData.CreateBankBalanceForMonth(BankBal);
                if (_result)
                {
                    _logger.LogInformation("BankBalance Create POST called");
                    ViewBag.Message = "Bank Balance Created Successfully";
                    TempData["SuccessMessage"] = "Bank Balance Added : " + BankBal.Month_Year;
                    ModelState.Clear();
                }
                else
                {
                    _logger.LogInformation("BankBalance Create POST called");
                    TempData["ErrorMessage"] = "Error in adding Bank Balance : " + BankBal.Month_Year;
                    ViewBag.Message = "Bank Balance Creation Failed";
                    ModelState.Clear();
                }
                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error in adding Bank Balance";
                _logger.LogError(ex, "Error in BankBalance Create POST");
                return View("Error");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Update(BankBalanceModel BankBal, string actionType)
        {
            try
            {
                switch (actionType)
                {
                    case "AddExpense":
                        // Move to Different View
                        _logger.LogInformation("BankBalance Add Expense called");
                        return RedirectToAction("Display", "Expenses", new { Bank_ID = BankBal.Id });

                    //TODO
                    case "Update":
                        _logger.LogInformation("BankBalance Update Expense called");
                        TempData["SuccessMessage"] = "Bank Balance Updated successfully!";
                        break;

                    //TODO
                    case "Delete":
                        _logger.LogInformation("BankBalance Delete Expense called");
                        TempData["SuccessMessage"] = "Bank Balance Deleted";
                        break;

                    default:
                        TempData["Message"] = "Unknown action.";
                        break;
                }

                return RedirectToAction("Create");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in BankBalance Update POST");
                return View("Error");
            }
        }


    }
}
