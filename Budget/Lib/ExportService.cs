using System;
using System.IO;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Budget.Models;
//C:\Users\Agnese\AppData\Local\User Name\com.companyname.budget
namespace Budget.Services
{
    public class ExportService
    {
        public async Task<string> ExportExpensesToExcelAsync(List<Expense> expenses)
        {
            var fileName = $"Izdevumi_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
            var filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Izdevumi");

            
            worksheet.Cell(1, 1).Value = "Datums";
            worksheet.Cell(1, 2).Value = "Summa (€)";
            worksheet.Cell(1, 3).Value = "Kategorija";
            worksheet.Cell(1, 4).Value = "Piezīmes";

            for (int i = 0; i < expenses.Count; i++)
            {
                var e = expenses[i];
                worksheet.Cell(i + 2, 1).Value = e.Date.ToString("dd.MM.yyyy HH:mm");
                worksheet.Cell(i + 2, 2).Value = e.Amount;
                worksheet.Cell(i + 2, 3).Value = e.Category;
                worksheet.Cell(i + 2, 4).Value = e.Note;
            }

            workbook.SaveAs(filePath);
            return filePath;
        }
    }
}
