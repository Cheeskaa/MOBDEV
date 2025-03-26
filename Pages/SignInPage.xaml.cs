using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoFull_CHIZZZ;

namespace ToDoFull_CHIZZZ;

public partial class SignInPage : ContentPage
{
    public SignInPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void Button_SignIn(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new AppShell());
    }

    private void Button_SignUp(object? sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}