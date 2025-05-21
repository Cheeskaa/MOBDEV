using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp9;

public partial class AddTodoPage : ContentPage
{
    public ICommand NavigateBackCommand { get; private set; }
    public AddTodoPage()
    {
        InitializeComponent();
        BindingContext = this;
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string title = TitleEntry.Text;
        string description = DescriptionEntry.Text;

        if (!string.IsNullOrWhiteSpace(title))
        {
            TodoService.PendingTasks.Add(new TodoItem
            {
                Title = title,
                Description = description,
                IsCompleted = false
            });
        }
        // Clear the TitleEntry after saving the task
        TitleEntry.Text = string.Empty;
        DescriptionEntry.Text = string.Empty;
        await Shell.Current.GoToAsync("//TodoPage");
    }
}