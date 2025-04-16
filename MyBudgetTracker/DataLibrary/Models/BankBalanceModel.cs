using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models;

public class BankBalanceModel
{
    public int Id { get; set; }

    [Required]
    [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for Name")]
    [MaxLength(20, ErrorMessage = "You need to keep the name to a max of 20 characters")]
    [DisplayName("Name for the Month_Year")]
    public string Month_Year { get; set; }


    [Required]
    [Range(1, 1000000, ErrorMessage = "Limit 10,00,000")]
    public decimal Amount { get; set; }
}
