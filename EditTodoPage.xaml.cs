using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace MauiApp9;

public partial class EditTodoPage : ContentPage
{
    public TodoItem EditingItem { get; set; }

    public EditTodoPage()
    {
        InitializeComponent();
        LoadSelectedItem();
    }

    private void LoadSelectedItem()
    {
        if (TodoService.SelectedItem != null)
        {
            EditingItem = TodoService.SelectedItem;
            TitleEntry.Text = EditingItem.Title;
            DescriptionEntry.Text = EditingItem.Description;
        }
    }

    private async void OnUpdateClicked(object sender, EventArgs e)
    {
        if (EditingItem != null)
        {
            EditingItem.Title = TitleEntry.Text;
            EditingItem.Description = DescriptionEntry.Text;
        }

        await Shell.Current.GoToAsync("//TodoPage");
    }

    private async void OnCompleteClicked(object sender, EventArgs e)
    {
        if (EditingItem != null)
        {
            TodoService.PendingTasks.Remove(EditingItem);
            EditingItem.IsCompleted = true;
            TodoService.CompletedTasks.Add(EditingItem);
        }

        await Shell.Current.GoToAsync("//CompletedTodoPage");
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (EditingItem != null)
        {
            TodoService.PendingTasks.Remove(EditingItem);
        }

        await Shell.Current.GoToAsync("//TodoPage");
    }

    private async void OnListClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//TodoPage");
    }

    private async void OnProfileClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ProfilePage");
    }
}
