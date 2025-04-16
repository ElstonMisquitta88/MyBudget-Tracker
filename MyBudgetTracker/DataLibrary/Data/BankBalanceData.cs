using Dapper;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLibrary.Data;

public class BankBalanceData : IBankBalanceData
{
    private readonly IDataAccess _dataAccess;
    private readonly ConnectionStringData _connectionString;

    public BankBalanceData(IDataAccess dataAccess, ConnectionStringData connectionString)
    {
        _dataAccess = dataAccess;
        _connectionString = connectionString;
    }

    public async Task<bool> CreateBankBalanceForMonth(BankBalanceModel _bankbal)
    {
        DynamicParameters p = new DynamicParameters();
        p.Add("Month_Year", _bankbal.Month_Year);
        p.Add("Amount", _bankbal.Amount);
        await _dataAccess.SaveData("Proc_AddBankBalance", p, _connectionString.SqlConnectionName); 
        return true;
    }

    public async Task<List<BankBalanceModel>> GetAll_BankBalanceForMonth()
    {
        var recs = await _dataAccess.LoadData<BankBalanceModel, dynamic>("Proc_GetAllBankBalance",
            new { },
            _connectionString.SqlConnectionName);
        return recs;
    }



}
