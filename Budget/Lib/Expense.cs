//using CloudKit;
using SQLite;
using System;

namespace Budget.Models;

public class Expense
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Note { get; set; }
    public DateTime Date { get; set; }

    public Expense()
    {
       
        Category = "";
        Note = "";
    }
}
