using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface IBankBalanceData
    {
        Task<bool> CreateBankBalanceForMonth(BankBalanceModel _bankbal);

        Task<List<BankBalanceModel>> GetAll_BankBalanceForMonth();

        Task<List<BankBalanceModel>> Get_GetBankBalance_ByID(int Bank_ID);
    }
}