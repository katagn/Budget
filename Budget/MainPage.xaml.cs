using System;
using Microsoft.Maui.Controls;

namespace Budget;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnEnterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ExpensesPage));

    }
}

