namespace Budget;

public partial class ExpensesListPage : ContentPage
{
    public ExpensesListPage()
    {
        InitializeComponent();
        _=LoadExpenses();
    }

    public async Task LoadExpenses()
    
    {
        var expenses = await App.Database.GetExpensesAsync();
        ExpensesCollection.ItemsSource = expenses;
    }
    private async void OnExportClicked(object sender, EventArgs e)
    {
        var expenses = await App.Database.GetExpensesAsync();
        var exporter = new Services.ExportService();
        var filePath = await exporter.ExportExpensesToExcelAsync(expenses);

#if ANDROID
    await Share.Default.RequestAsync(new ShareFileRequest
    {
        Title = "Izdevumu Excel fails",
        File = new ShareFile(filePath)
    });
#else
        await DisplayAlert("Eksport?ts", $"Fails saglab?ts:\n{filePath}", "Labi");
#endif
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var expense = (Models.Expense)button.BindingContext;

        var confirm = await DisplayAlert("Apstiprināt", "Vai tiešām vēlies dzēst šo izdevumu?", "Jā", "Nē");
        if (!confirm) return;

        if (App.Database != null)
        {
            await App.Database.DeleteExpenseAsync(expense);
            await LoadExpenses(); 
        }
    }

}
