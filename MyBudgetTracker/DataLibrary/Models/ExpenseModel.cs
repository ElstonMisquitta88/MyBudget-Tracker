using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models;

public class ExpenseModel
{
    public int Id { get; set; }
    public string Bank_ID { get; set; }
    public string ExpenseDetails { get; set; }
    public decimal Amount { get; set; }
    public string Date { get; set; }

}
