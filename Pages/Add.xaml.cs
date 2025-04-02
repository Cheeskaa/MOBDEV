using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ToDoFull_CHIZ2.Models;

namespace ToDoFull_CHIZ2;

public partial class Add : ContentPage
{
    public ObservableCollection<ToDoItem> ToDoItems { get; set; }
    public Add(ObservableCollection<ToDoItem> toDoItems)
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        ToDoItems = toDoItems; // Assign the passed list
    }

    private async void Button_OnClicked(object? sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(titleEntry.Text) && !string.IsNullOrWhiteSpace(descriptionEntry.Text))
        {
            ToDoItems.Add(new ToDoItem 
            { 
                Title = titleEntry.Text, 
                Description = descriptionEntry.Text, 
                IsCompleted = false 
            });

            // Clear input fields
            titleEntry.Text = string.Empty;
            descriptionEntry.Text = string.Empty;

            // Go back to ToDoPage
            await Navigation.PopAsync();
        }
    }
}