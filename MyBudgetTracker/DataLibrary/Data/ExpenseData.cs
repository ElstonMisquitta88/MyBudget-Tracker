using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;

namespace DataLibrary.Data;

public class ExpenseData : IExpenseData
{
    private readonly IDataAccess _dataAccess;
    private readonly ConnectionStringData _connectionString;
    public ExpenseData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        _dataAccess = dataAccess;
        _connectionString = connectionString;
    }

    public async Task<bool> AddExpense(ExpenseModel _expdata)
    {
        DynamicParameters p = new DynamicParameters();
        p.Add("Bank_ID", _expdata.Bank_ID);
        p.Add("ExpenseDetails", _expdata.ExpenseDetails);
        p.Add("Amount", _expdata.Amount);
        await _dataAccess.SaveData("Proc_AddExpense", p, _connectionString.SqlConnectionName);
        return true;
    }

}
