using System.IO;
using Budget.Services;

namespace Budget
{
    public partial class App : Application
    {
        public static DatabaseService? Database { get; private set; }

        public App()
        {
            InitializeComponent();
            // No longer set MainPage here — it's obsolete
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "expenses.db");
            Database = new DatabaseService(dbPath);

            return new Window(new AppShell());
        }
    }
}
