using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDoFull_CHIZ2.Models;

namespace ToDoFull_CHIZ2;

public partial class ToDoPage : ContentPage
{
    public ObservableCollection<ToDoItem> ToDoItems { get; set; }
    
    public ToDoPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        ToDoItems = new ObservableCollection<ToDoItem>();
        BindingContext = this;
    }

    private async void Button_AddToDo(object? sender, EventArgs e)
    {
        await Navigation.PushAsync(new Add(ToDoItems)); // Pass ToDoItems to Add page
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is ToDoItem task)
        {
            // Remove from ToDo list
            ToDoItems.Remove(task);

            // Pass the completed task to CompletedPage
            await Navigation.PushAsync(new CompletedPage(task));
        }
    }

    private void Button_Delete(object? sender, EventArgs e)
    {
        
    }
}