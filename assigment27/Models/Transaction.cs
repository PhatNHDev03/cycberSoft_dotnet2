using System;
using System.ComponentModel.DataAnnotations;
namespace assigment27.Models;

public class Transaction
{
    public int Id { get; set; }
    public string TypeTransaction { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
    public double Money { get; set; }
    public DateTime Date { get; set; }

}
