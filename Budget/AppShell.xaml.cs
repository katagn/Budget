namespace Budget
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ExpensesPage), typeof(ExpensesPage));
        }
    }
}
