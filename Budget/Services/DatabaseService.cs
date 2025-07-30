using SQLite;
using Budget.Models;

namespace Budget.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Expense>().Wait();
    }

    public Task<int> AddExpenseAsync(Expense expense)
    {
        return _db.InsertAsync(expense);
    }

    public Task<List<Expense>> GetExpensesAsync()
    {
        return _db.Table<Expense>().ToListAsync();
    }

    public Task<int> DeleteExpenseAsync(Expense expense)
    {
        return _db.DeleteAsync(expense);
    }
}
