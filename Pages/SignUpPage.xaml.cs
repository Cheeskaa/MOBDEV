using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoFull_CHIZ2;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private void Button_SignUp(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new SignInPage());
    }

    private void Button_SignIn(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new SignInPage());
    }
}