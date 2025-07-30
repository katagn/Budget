namespace Budget;

public partial class ExpensesPage : ContentPage
{
    public ExpensesPage()
    {
        InitializeComponent();
    }
private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (decimal.TryParse(AmountEntry.Text, out decimal amount))
        {
            var expense = new Models.Expense
            {
                Amount = amount,
                Category = CategoryPicker.SelectedItem?.ToString() ?? "Citi",
                Note = NoteEntry.Text,
                Date = DateTime.Now
            };

            if (App.Database == null)
            {
                await DisplayAlert("Kļūda", "Datubāzes serviss nav pieejams.", "Labi");
                return;
            }

            await App.Database.AddExpenseAsync(expense);

            await DisplayAlert("Saglabāts", "Izdevums pievienots", "Labi");

            AmountEntry.Text = "";
            
            NoteEntry.Text = "";
        }
        else
        {
            await DisplayAlert("Kļūda", "Lūdzu ievadi korektu summu", "Labi");
        }
    }
    private async void OnShowExpensesClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExpensesListPage());
    }


}
