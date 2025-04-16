using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IBankBalanceData
    {
        Task<bool> BankBalanceForMonth(BankBalanceModel _bankbal);
    }
}